using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bovaljare.Data
{
  public class HouseMap
  {
    private static Dictionary<string, List<HouseMap>> data;
    private static readonly Dictionary<string, string> imageToVariant = new Dictionary<string, string> {
      { "IMG/exterior/solhav_PerspectiveMatch_oversikt.jpg", "view-1" },
      { "IMG/exterior/SolHav_Oversikt_V3_BeautyElement.jpg", "view-2" },
      { "IMG/exterior/solhav_PerspectiveMatch_oversikt2.jpg", "view-3" },
    };

    public int ID { get; set; }
    public string HouseNumber { get; set; }
    public string IMCoords { get; set; }
    public string View { get; set; }

    public static Dictionary<string, List<HouseMap>> GetHouseMapData()
    {
      if (data == null)
      {
        /// Create new HouseMap data from each view-X.json file.
        data = new Dictionary<string, List<HouseMap>>();
        DirectoryInfo dir = new DirectoryInfo(@"wwwroot\data\views\");
        FileInfo[] filenames = dir.GetFiles("*.json");

        foreach (FileInfo filename in filenames) {
          string filePath = filename.FullName;
          string json = "";
          using (FileStream fs = File.OpenRead(filePath)) {
            byte[] b = new byte[1024];
            UTF8Encoding encoder = new UTF8Encoding(true);

            while (fs.Read(b, 0, b.Length) > 0) {
              json += encoder.GetString(b);
              b = new byte[1024];
            }
          }
          List<HouseMap> houseMaps = new List<HouseMap>();
          JsonTextReader reader = new JsonTextReader(new StringReader(json));

          while (reader.Read()) {
            // For each read key-value pair, there is another that should follow:
            // first is either "HouseNumber" or "View",
            // second are the coordinates.
            if (reader.Value != null) {
              bool isHouseNumber = reader.Value.ToString() == "HouseNumber";
              reader.Read();
              string idValue = reader.Value.ToString();
              reader.Read();
              reader.Read();
              houseMaps.Add(isHouseNumber
                          ? new HouseMap { HouseNumber = idValue, IMCoords = reader.Value.ToString() }
                          : new HouseMap { View = idValue, IMCoords = reader.Value.ToString() }
              );
            }
          }
          data.Add(Path.GetFileNameWithoutExtension(filePath), houseMaps);
        }

        /// Get the id corresponding to a map's house number, in order to link each mapping to a house or apt.
        List<House> houseData = House.GetHouseData();
        foreach (KeyValuePair<string, List<HouseMap>> view in data)
        {
          foreach (HouseMap map in view.Value)
          {
            if (map.HouseNumber != null)
              map.ID = houseData.Find(x => x.HouseNumber == map.HouseNumber).ID;
            else
              map.ID = -1;
          }
        }
      }

      return data;
    }

    public static string ImageNameToVariant(string fileName)
    {
      return imageToVariant[fileName];
    }
  }
}
