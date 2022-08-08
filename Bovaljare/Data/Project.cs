using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Bovaljare.Util;

namespace Bovaljare.Data
{
  public class Project
  {
    private readonly static Dictionary<string, Project> Projects = new();

    public string Name { get; set; }
    public bool IsSunStudy { get; set; } = false;
    public bool DisplayRent { get; set; } = false;
    public bool DisplayLandArea { get; set; } = false;
    public Dictionary<string, double> GPS { get; set; }

    public static Project GetProject(string uri)
    {
      if (!Projects.ContainsKey(uri)) {
        string json = FileHandler.GetContents(@"wwwroot\data\projects\" + uri + ".json");
        Projects.Add(uri, JsonConvert.DeserializeObject<Project>(json));
      }

      return Projects[uri];
    }
  }
}
