using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Download;
using Google.Apis.Util.Store;
using Newtonsoft.Json;

namespace Bovaljare.Util
{
  public class GoogleDrive
  {
    /* Global instance of the scopes required.
      If modifying these scopes, delete your previously saved token.json/ folder. */
    static string[] Scopes = { DriveService.Scope.DriveReadonly, DriveService.Scope.Drive, DriveService.Scope.DriveFile };
    static string ApplicationName = "Bostadsvaljare";

    public static MemoryStream GetFileStream(MemoryStream memStream, string project) {
      try
      {
        UserCredential credential;
        // Load client secrets.
        using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
        {
          /* The file token.json stores the user's access and refresh tokens, and is created
            automatically when the authorization flow completes for the first time. */
          string credPath = "token.json";
          credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
              GoogleClientSecrets.FromStream(stream).Secrets,
              Scopes,
              "user",
              CancellationToken.None,
              new FileDataStore(credPath, true)).Result;
          Console.WriteLine("Credential file saved to: " + credPath);
        }

        // Create Drive API service.
        var service = new DriveService(new BaseClientService.Initializer
        {
          HttpClientInitializer = credential,
          ApplicationName = ApplicationName
        });

        // File id for project.
        string realFileId = "";
        string contents = FileHandler.GetContents(@"wwwroot\data\projects\" + project + ".json");
        using (JsonTextReader reader = new JsonTextReader(new StringReader(contents))) {
          while (reader.Read()) {
            if (reader.Value != null  &&  reader.Value as string == "Drive_file-id") {
              reader.Read();
              realFileId = reader.Value as string;
              break;
            }
          }
        }
        FilesResource.GetRequest getRequest = service.Files.Get(realFileId);

        Google.Apis.Drive.v3.Data.File file = getRequest.Execute();

        // Add a handler which will be notified on progress changes.
        // It will notify on each chunk download and when the
        // download is completed or failed.
        getRequest.MediaDownloader.ProgressChanged +=
            progress => {
              switch (progress.Status)
              {
                case DownloadStatus.Downloading:
                  {
                    Console.WriteLine(progress.BytesDownloaded);
                    break;
                  }
                case DownloadStatus.Completed:
                  {
                    Console.WriteLine("Download complete.");
                    break;
                  }
                case DownloadStatus.Failed:
                  {
                    Console.WriteLine("Download failed.");
                    break;
                  }
              }
            };
        getRequest.Download(memStream);
      }
      catch (FileNotFoundException e)
      {
        Console.WriteLine(e.Message);
      }

      return memStream;
    }
  }
}
