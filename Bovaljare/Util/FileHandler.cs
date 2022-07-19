using System.IO;
using System.Text;

namespace Bovaljare.Util
{
  public class FileHandler
  {
    public static string GetContents(string filePath) {
      string contents = "";
      using (FileStream fs = File.OpenRead(filePath)) {
        byte[] b = new byte[1024];
        UTF8Encoding encoder = new UTF8Encoding(true);

        while (fs.Read(b, 0, b.Length) > 0) {
          contents += encoder.GetString(b);
          b = new byte[1024];
        }
      }
      return contents;
    }
  }
}
