using System.Collections.Generic;
using System.Numerics;

namespace Bovaljare.Data
{
  public enum ImageType
  {
    Image,
    Panorama,
    VR,
    Roundme
  }

  public class HouseType
  {
    private static Dictionary<string, HouseType> data;

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

    public static HouseType GetData(string type)
    {
      if (data == null)
      {
        data = new Dictionary<string, HouseType> {
          { "150", new HouseType {
            Floorplans = new List<Floorplan> {
              new Floorplan { Source = "IMG/interior/Hus_150_Plan_1.png", Rooms = new List<Floorplan.Room> {
                //new Floorplan.Room { RoomID = 6, Left = "63.5%", Top="54%", IconClass="fas fa-street-view" },
                //new Floorplan.Room { RoomID = 4, Left = "56%", Top="60%", IconClass="fas fa-camera" },
                //new Floorplan.Room { RoomID = 2, Left = "63%", Top="30%", IconClass="fas fa-camera" },
                //new Floorplan.Room { RoomID = 5, Left = "74%", Top="42%", IconClass="fas fa-street-view" },
                //new Floorplan.Room { RoomID = 3, Left = "63%", Top="41%", IconClass="fas fa-camera" },
                //new Floorplan.Room { RoomID = 7, Left = "36%", Top="45%", IconClass="fas fa-camera" },
                //new Floorplan.Room { RoomID = 8, Left = "31%", Top="59%", IconClass="fas fa-video" },
              }},
              new Floorplan { Source = "IMG/interior/Hus_150_Plan_2.png", Rooms = new List<Floorplan.Room> {
              }}
            },
            Images = new List<Image> {
              new Image { Source="IMG/interior/220630_SolHav_Kitchen_3K_JPG.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/220630_SolHav_KitchenZoomed_3K_JPG.jpg", Type=ImageType.Image },
              new Image { Source="IMG/exterior/220607_SolHav_Gatubild_BeautyElement.jpg", Type=ImageType.Image },
              new Image { Source="IMG/exterior/SolHav_Moodbild__beauty element.jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/G3G3kt-Område-11Gata_25.jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/Ext1-5grey.jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/G3kfloor1sofa.jpg", Type=ImageType.Image},
              //new Image { Source="IMG/interior/G3kfloor1livingAndKitchen.jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/Adjust-KitchenG3KT2.jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/Livingroom_Extra_Ready50.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/5KtHD5XRR9URI3CE0W2V", RoomName="vardagsrum" },
              //new Image { Source="IMG/interior/360Iconplaceholder-g3k-living.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/zbbOja9JGWDzc5v1WVZe", RoomName="kok" },
              //new Image { Source="IMG/interior/Bathroom_1-(G3_Floor-1).jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/Livingroom_Extra_Ready_25_VR.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525519517", RoomName="kok" },
              //new Image { Source="IMG/interior/G3_Sovrum.jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/G3-G2_Badrum.jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/G3_Sovrum_vr25.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525570276", RoomName="kok" },
              //new Image { Source="IMG/interior/G3kfloor3sofa.jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/panoplaceholderaddict25.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/6CquaWdm6YJXayR1DK9v", RoomName="vind" },
              //new Image { Source="IMG/interior/G3kfloor3workAndplay.jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/g3kfloor3workandplay_vr_25.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525540496", RoomName="kok" },
              //new Image { Source="IMG/interior/20210121_Uterum-1_1_25.jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/G3(kt)-Plan-1_3D_medium.jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/G3(kt)-Plan-2_3D_medium.jpg", Type=ImageType.Image },
              //new Image { Source="IMG/interior/G3(kt)-Plan-3_3D_medium.jpg", Type=ImageType.Image },
            },
            Comment = "Nån lämplig kommentar..."
          }},

          { "150 SP", new HouseType {
            Floorplans = new List<Floorplan> {
              new Floorplan { Source = "IMG/interior/Hus_150_Plan_1.png", Rooms = new List<Floorplan.Room> {
              }},
              new Floorplan { Source = "IMG/interior/Hus_150_Plan_2.png", Rooms = new List<Floorplan.Room> {
              }}
            },
            Images = new List<Image> {
              new Image { Source="IMG/interior/220630_SolHav_Kitchen_3K_JPG.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/220630_SolHav_KitchenZoomed_3K_JPG.jpg", Type=ImageType.Image },
              new Image { Source="IMG/exterior/220607_SolHav_Gatubild_BeautyElement.jpg", Type=ImageType.Image },
              new Image { Source="IMG/exterior/SolHav_Moodbild__beauty element.jpg", Type=ImageType.Image },
            },
            Comment = "Nån lämplig kommentar..."
          }},

          { "120 typ 1", new HouseType {
            Floorplans = new List<Floorplan> {
              new Floorplan { Source = "IMG/interior/Hus_120_TYP_1_Plan_1.png", Rooms = new List<Floorplan.Room> {
              }},
            },
            Images = new List<Image> {
              new Image { Source="IMG/interior/220630_SolHav_Kitchen_3K_JPG.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/220630_SolHav_KitchenZoomed_3K_JPG.jpg", Type=ImageType.Image },
              new Image { Source="IMG/exterior/220607_SolHav_Gatubild_BeautyElement.jpg", Type=ImageType.Image },
              new Image { Source="IMG/exterior/SolHav_Moodbild__beauty element.jpg", Type=ImageType.Image },
            },
            Comment = "Nån lämplig kommentar..."
          }},

          { "120 typ 1 SP", new HouseType {
            Floorplans = new List<Floorplan> {
              new Floorplan { Source = "IMG/interior/Hus_120_TYP_1_SP_Plan_1.png", Rooms = new List<Floorplan.Room> {
              }},
            },
            Images = new List<Image> {
              new Image { Source="IMG/interior/220630_SolHav_Kitchen_3K_JPG.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/220630_SolHav_KitchenZoomed_3K_JPG.jpg", Type=ImageType.Image },
              new Image { Source="IMG/exterior/220607_SolHav_Gatubild_BeautyElement.jpg", Type=ImageType.Image },
              new Image { Source="IMG/exterior/SolHav_Moodbild__beauty element.jpg", Type=ImageType.Image },
            },
            Comment = "Nån lämplig kommentar..."
          }},

          { "120 typ 2", new HouseType {
            Floorplans = new List<Floorplan> {
              new Floorplan { Source = "IMG/interior/Hus_120_TYP_2_Plan_1.png", Rooms = new List<Floorplan.Room> {
              }},
            },
            Images = new List<Image> {
              new Image { Source="IMG/interior/220630_SolHav_Kitchen_3K_JPG.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/220630_SolHav_KitchenZoomed_3K_JPG.jpg", Type=ImageType.Image },
              new Image { Source="IMG/exterior/220607_SolHav_Gatubild_BeautyElement.jpg", Type=ImageType.Image },
              new Image { Source="IMG/exterior/SolHav_Moodbild__beauty element.jpg", Type=ImageType.Image },
            },
            Comment = "Nån lämplig kommentar..."
          }},

          { "120 typ 2 SP", new HouseType {
            Floorplans = new List<Floorplan> {
              new Floorplan { Source = "IMG/interior/Hus_120_TYP_2_SP_Plan_1.png", Rooms = new List<Floorplan.Room> {
              }},
            },
            Images = new List<Image> {
              new Image { Source="IMG/interior/220630_SolHav_Kitchen_3K_JPG.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/220630_SolHav_KitchenZoomed_3K_JPG.jpg", Type=ImageType.Image },
              new Image { Source="IMG/exterior/220607_SolHav_Gatubild_BeautyElement.jpg", Type=ImageType.Image },
              new Image { Source="IMG/exterior/SolHav_Moodbild__beauty element.jpg", Type=ImageType.Image },
            },
            Comment = "Nån lämplig kommentar..."
          }},
        };
      }

      return data[type];
    }
  }
}
