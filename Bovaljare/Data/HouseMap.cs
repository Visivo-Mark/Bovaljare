﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bovaljare.Data
{
  public class HouseMap
  {
    private static Dictionary<string, Dictionary<string, List<HouseMap>>> data =
      new Dictionary<string, Dictionary<string, List<HouseMap>>>();
    private static readonly Dictionary<string, string> imageToVariant = new Dictionary<string, string> {
      { "IMG/WIJK/exterior/OversiktStora_medium.jpg", "view-1" },
      { "IMG/WIJK/exterior/Oversikt1-5_medium.jpg", "view-2" },
      { "IMG/WIJK/exterior/Oversikt_V2_medium.jpg", "view-3" },
      { "IMG/WIJK/exterior/Oversikt8_medium.jpg", "view-4" },
      { "IMG/WIJK/exterior/Oversikt11_medium.jpg", "view-5" },
      { "IMG/WIJK/exterior/OversiktStora_medium2.jpg", "view-6" },

      { "IMG/SolHav/exterior/solhav_PerspectiveMatch_oversikt.jpg", "view-1" },
      { "IMG/SolHav/exterior/SolHav_Oversikt_V3_BeautyElement.jpg", "view-2" },
      { "IMG/SolHav/exterior/solhav_PerspectiveMatch_oversikt2.jpg", "view-3" },

      { "IMG/Kilen/exterior/DJI_0227.jpg", "view-1" },
      { "IMG/Kilen/exterior/Oversikt_Bostadsväljare_3K.jpg", "view-2" },
    };

    public int ID { get; set; }
    public string HouseNumber { get; set; }
    public string IMCoords { get; set; }
    public string View { get; set; }

    public static Dictionary<string, List<HouseMap>> GetHouseMapData(string project)
    {
      if (!data.ContainsKey(project))
      {
        /// Create new HouseMap data from each view-X.json file.
        Dictionary<string, List<HouseMap>> projectData = new Dictionary<string, List<HouseMap>>();
        DirectoryInfo dir = new DirectoryInfo(@"wwwroot\data\views\" + project + @"\");
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
          projectData.Add(Path.GetFileNameWithoutExtension(filePath), houseMaps);
        }

        /// Get the id corresponding to a map's house number, in order to link each mapping to a house or apt.
        List<House> houseData = House.GetHouseData(project);
        foreach (KeyValuePair<string, List<HouseMap>> view in projectData)
        {
          foreach (HouseMap map in view.Value)
          {
            if (map.HouseNumber != null)
              map.ID = houseData.Find(x => x.HouseNumber == map.HouseNumber).ID;
            else
              map.ID = -1;
          }
        }

        data.Add(project, projectData);
      }

      return data[project];
    }

    public static string ImageNameToVariant(string fileName)
    {
      return imageToVariant[fileName];
    }
  }
}
