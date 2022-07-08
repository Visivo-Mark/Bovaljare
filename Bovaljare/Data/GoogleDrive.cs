using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Download;
using Google.Apis.Util.Store;

namespace Bovaljare.Data
{
  public class GoogleDrive
  {
    /* Global instance of the scopes required.
      If modifying these scopes, delete your previously saved token.json/ folder. */
    static string[] Scopes = { DriveService.Scope.DriveReadonly, DriveService.Scope.Drive, DriveService.Scope.DriveFile };
    static string ApplicationName = "Bostadsvaljare";

    public static MemoryStream GetFileStream(MemoryStream memStream) {
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

        // File id for SolHav.xlsx.
        string realFileId = "1K7MpS5PL15a4RzSw7rlIeE8_wzmJFZlR";
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
