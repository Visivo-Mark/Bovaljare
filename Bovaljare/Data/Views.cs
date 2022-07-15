using System.Collections.Generic;

namespace Bovaljare.Data
{
  public class ViewData
  {
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string SourceImgName { get; set; }
    public Dictionary<string, string> SunStudies { get; set; }
    public string ImageMapName { get; set; }
    public bool Initialized { get; set; } = false;
  }

  public class Views {
    private List<ViewData> Data { get; set; }

    public ViewData this[int i] {
      get { return Data[i]; }
      set { Data[i] = value; }
    }
    public int Count { get { return Data.Count; } }

    public Views(List<ViewData> data)
    {
      Data = data;
    }

    public Views(params ViewData[] data)
    {
      Data = new List<ViewData>(data);
    }

    public List<ViewData> GetViewData() {
      return new List<ViewData>(Data);
    }

    public ViewData GetView(string name) {
      return Data.Find(view => view.Name == name);
    }
  }
}
