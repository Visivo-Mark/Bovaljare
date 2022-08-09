using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using Bovaljare.Util;

namespace Bovaljare.Data
{
  public enum ImageType
  {
    Image = 0,
    Panorama = 1,
    VR = 2,
    Roundme = 3
  }

  public class HouseType
  {
    private static readonly Dictionary<string, Dictionary<string, HouseType>> data = new();

    public class Image
    {
      public string Thumbnail { get; set; }
      public string Source { get; set; }
      public ImageType Type { get; set; }
      public string Link { get; set; }
      public string RoomName { get; set; }
    }

    public class Floorplan
    {
      public class Room
      {
        public int RoomID { get; set; }
        public Vector2 Coords { get; set; }
        public string Top { get; set; }
        public string Left { get; set; }
        public string IconClass { get; set; }
      }

      public string Source { get; set; }
      public List<Room> Rooms { get; set; }
    }


    public List<Floorplan> Floorplans { get; set; }
    public List<Image> Images { get; set; }
    public string Comment { get; set; }

    public static HouseType GetData(string type, string project)
    {
      if (!data.ContainsKey(project)) {
        string json = FileHandler.GetContents(@"wwwroot\data\housetypes\" + project + ".json");
        data.Add(project, JsonConvert.DeserializeObject<Dictionary<string, HouseType>>(json));
      }

      return data[project][type];
    }
  }
}
