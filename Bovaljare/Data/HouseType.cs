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
          { "SH-1", new HouseType {
            Floorplans = new List<Floorplan> {
              new Floorplan { Source = "IMG/interior/G3(kt)-Plan-1-50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 6, Left = "63.5%", Top="54%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 4, Left = "56%", Top="60%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 2, Left = "63%", Top="30%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 5, Left = "74%", Top="42%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 3, Left = "63%", Top="41%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 7, Left = "36%", Top="45%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 8, Left = "31%", Top="59%", IconClass="fas fa-video" },
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

          { "SH-2", new HouseType {
            Floorplans = new List<Floorplan> {
              new Floorplan { Source = "IMG/interior/G3(kt)-Plan-1-50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 6, Left = "63.5%", Top="54%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 4, Left = "56%", Top="60%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 2, Left = "63%", Top="30%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 5, Left = "74%", Top="42%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 3, Left = "63%", Top="41%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 7, Left = "36%", Top="45%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 8, Left = "31%", Top="59%", IconClass="fas fa-video" },
              }},
              new Floorplan { Source = "IMG/interior/G3(kt)-Plan-2-50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 9, Left = "34%", Top="52%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 10, Left = "59%", Top="53%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 11, Left = "47%", Top="34%", IconClass="fas fa-video" },
              }},
              new Floorplan { Source = "IMG/interior/G3(kt)-Plan-3-a50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 12, Left = "44%", Top="52%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 13, Left = "53%", Top="44%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 14, Left = "64%", Top="33%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 15, Left = "47%", Top="31%", IconClass="fas fa-video" },
              }},
            },
            Images = new List<Image> {
              new Image { Source="IMG/interior/Ext1-5redAndgrey.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Ext1-5red.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3kfloor1sofa.jpg", Type=ImageType.Image},
              new Image { Source="IMG/interior/G3kfloor1livingAndKitchen.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Adjust-KitchenG3KT2.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Livingroom_Extra_Ready50.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/5KtHD5XRR9URI3CE0W2V", RoomName="vardagsrum" },
              new Image { Source="IMG/interior/360Iconplaceholder-g3k-living.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/zbbOja9JGWDzc5v1WVZe", RoomName="kok" },
              new Image { Source="IMG/interior/Bathroom_1-(G3_Floor-1).jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Livingroom_Extra_Ready_25_VR.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525519517", RoomName="kok" },
              new Image { Source="IMG/interior/G3_Sovrum.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3-G2_Badrum.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3_Sovrum_vr25.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525570276", RoomName="kok" },
              new Image { Source="IMG/interior/G3kfloor3sofa.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/panoplaceholderaddict25.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/6CquaWdm6YJXayR1DK9v", RoomName="vind" },
              new Image { Source="IMG/interior/G3kfloor3workAndplay.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/g3kfloor3workandplay_vr_25.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525540496?background=1", RoomName="kok" },
              new Image { Source="IMG/interior/20210121_Uterum-1_1_25.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3(kt)-Plan-1_3D_medium.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3(kt)-Plan-2_3D_medium.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3(kt)-Plan-3_3D_medium.jpg", Type=ImageType.Image },
            },
            Comment = "Med sin kubistiska utformning och minimalistiska formspråk sticker lägenheten ut från mängden. Här är det de anspråkslösa detaljerna som väcker intresset. Det stilrent takade entrépartiet följs upp invändigt av ett effektfullt ljusschakt med full takhöjd genom båda våningsplanen och ett högt glasparti."
          }},

          { "SH-3", new HouseType {
            Floorplans = new List<Floorplan> {
              new Floorplan { Source = "IMG/interior/G3(kt)-Plan-1-50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 6, Left = "63.5%", Top="54%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 4, Left = "56%", Top="60%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 2, Left = "63%", Top="30%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 5, Left = "74%", Top="42%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 3, Left = "63%", Top="41%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 7, Left = "36%", Top="45%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 8, Left = "31%", Top="59%", IconClass="fas fa-video" },
              }},
              new Floorplan { Source = "IMG/interior/G3(kt)-Plan-2-50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 9, Left = "34%", Top="52%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 10, Left = "59%", Top="53%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 11, Left = "47%", Top="34%", IconClass="fas fa-video" },
              }},
              new Floorplan { Source = "IMG/interior/G3(kt)-Plan-3-a50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 12, Left = "44%", Top="52%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 13, Left = "53%", Top="44%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 14, Left = "64%", Top="33%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 15, Left = "47%", Top="31%", IconClass="fas fa-video" },
              }},
            },
            Images = new List<Image> {
              new Image { Source="IMG/interior/G3G3kt-Område-11Gata_25.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Ext1-5grey.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3kfloor1sofa.jpg", Type=ImageType.Image},
              new Image { Source="IMG/interior/G3kfloor1livingAndKitchen.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Adjust-KitchenG3KT2.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Livingroom_Extra_Ready50.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/5KtHD5XRR9URI3CE0W2V", RoomName="vardagsrum" },
              new Image { Source="IMG/interior/360Iconplaceholder-g3k-living.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/zbbOja9JGWDzc5v1WVZe", RoomName="kok" },
              new Image { Source="IMG/interior/Bathroom_1-(G3_Floor-1).jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Livingroom_Extra_Ready_25_VR.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525519517", RoomName="kok" },
              new Image { Source="IMG/interior/G3_Sovrum.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3-G2_Badrum.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3_Sovrum_vr25.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525570276", RoomName="kok" },
              new Image { Source="IMG/interior/G3kfloor3sofa.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/panoplaceholderaddict25.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/6CquaWdm6YJXayR1DK9v", RoomName="vind" },
              new Image { Source="IMG/interior/G3kfloor3workAndplay.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/g3kfloor3workandplay_vr_25.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525540496", RoomName="kok" },
              new Image { Source="IMG/interior/20210121_Uterum-1_1_25.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3(kt)-Plan-1_3D_medium.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3(kt)-Plan-2_3D_medium.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3(kt)-Plan-3_3D_medium.jpg", Type=ImageType.Image },
            },
            Comment = "Med sin kubistiska utformning och minimalistiska formspråk sticker lägenheten ut från mängden. Här är det de anspråkslösa detaljerna som väcker intresset. Det stilrent takade entrépartiet följs upp invändigt av ett effektfullt ljusschakt med full takhöjd genom båda våningsplanen och ett högt glasparti."
          }},

          { "SH-4", new HouseType {
            Floorplans = new List<Floorplan> {
              new Floorplan { Source = "IMG/interior/G3(kt)-Plan-1-50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 6, Left = "63.5%", Top="54%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 4, Left = "56%", Top="60%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 2, Left = "63%", Top="30%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 5, Left = "74%", Top="42%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 3, Left = "63%", Top="41%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 7, Left = "36%", Top="45%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 8, Left = "31%", Top="59%", IconClass="fas fa-video" },
              }},
              new Floorplan { Source = "IMG/interior/G3(kt)-Plan-2-50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 9, Left = "34%", Top="52%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 10, Left = "59%", Top="53%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 11, Left = "47%", Top="34%", IconClass="fas fa-video" },

              }},
              new Floorplan { Source = "IMG/interior/G3(kt)-Plan-3-a50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 12, Left = "44%", Top="52%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 13, Left = "53%", Top="44%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 14, Left = "64%", Top="33%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 15, Left = "47%", Top="31%", IconClass="fas fa-video" },
              }},
            },
            Images = new List<Image> {
              new Image { Source="IMG/interior/G3G3kt-Område-11Gata_25.jpg", Type=ImageType.Image},
              new Image { Source="IMG/interior/Ext1-5red.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3kfloor1sofa.jpg", Type=ImageType.Image},
              new Image { Source="IMG/interior/G3kfloor1livingAndKitchen.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Adjust-KitchenG3KT2.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Livingroom_Extra_Ready50.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/5KtHD5XRR9URI3CE0W2V", RoomName="vardagsrum" },
              new Image { Source="IMG/interior/360Iconplaceholder-g3k-living.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/zbbOja9JGWDzc5v1WVZe", RoomName="kok" },
              new Image { Source="IMG/interior/Bathroom_1-(G3_Floor-1).jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Livingroom_Extra_Ready_25_VR.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525519517", RoomName="kok" },
              new Image { Source="IMG/interior/G3_Sovrum.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3-G2_Badrum.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3_Sovrum_vr25.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525570276", RoomName="kok" },
              new Image { Source="IMG/interior/G3kfloor3sofa.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/panoplaceholderaddict25.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/6CquaWdm6YJXayR1DK9v", RoomName="vind" },
              new Image { Source="IMG/interior/G3kfloor3workAndplay.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/g3kfloor3workandplay_vr_25.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525540496", RoomName="kok" },
              new Image { Source="IMG/interior/20210121_Uterum-1_1_25.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3(kt)-Plan-1_3D_medium.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3(kt)-Plan-2_3D_medium.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3(kt)-Plan-3_3D_medium.jpg", Type=ImageType.Image },
            },
            Comment = "Med sin kubistiska utformning och minimalistiska formspråk sticker lägenheten ut från mängden. Här är det de anspråkslösa detaljerna som väcker intresset. Det stilrent takade entrépartiet följs upp invändigt av ett effektfullt ljusschakt med full takhöjd genom båda våningsplanen och ett högt glasparti."
          }},

          { "SH-5", new HouseType {
            Floorplans = new List<Floorplan> {
              new Floorplan { Source = "IMG/interior/G3(kt)-Plan-1-50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 6, Left = "63.5%", Top="54%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 4, Left = "56%", Top="60%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 2, Left = "63%", Top="30%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 5, Left = "74%", Top="42%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 3, Left = "63%", Top="41%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 7, Left = "36%", Top="45%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 8, Left = "31%", Top="59%", IconClass="fas fa-video" },
              }},
              new Floorplan { Source = "IMG/interior/G3(kt)-Plan-2-50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 9, Left = "34%", Top="52%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 10, Left = "59%", Top="53%", IconClass="fas fa-camera" },
                new Floorplan.Room { RoomID = 11, Left = "59%", Top="34%", IconClass="fas fa-video" },
              }},
              new Floorplan { Source = "IMG/interior/G2-Plan-3-50.png", Rooms = new List<Floorplan.Room> {
                new Floorplan.Room { RoomID = 12, Left = "50%", Top="35%", IconClass="fas fa-street-view" },
                new Floorplan.Room { RoomID = 13, Left = "55%", Top="41%", IconClass="fas fa-video" },
              }},
            },
            Images = new List<Image> {
              new Image { Source="IMG/interior/G2_Backside_25.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G2-Hus_medium.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3kfloor1sofa.jpg", Type=ImageType.Image},
              new Image { Source="IMG/interior/G3kfloor1livingAndKitchen.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Adjust-KitchenG3KT2.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Livingroom_Extra_Ready50.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/5KtHD5XRR9URI3CE0W2V", RoomName="vardagsrum" },
              new Image { Source="IMG/interior/360Iconplaceholder-g3k-living.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/zbbOja9JGWDzc5v1WVZe", RoomName="kok" },
              new Image { Source="IMG/interior/Bathroom_1-(G3_Floor-1).jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/Livingroom_Extra_Ready_25_VR.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525519517", RoomName="kok" },
              new Image { Source="IMG/interior/G3_Sovrum.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3-G2_Badrum.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3_Sovrum_vr25.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/525570276", RoomName="kok" },
              new Image { Source="IMG/interior/360placeholderG2vind.jpg", Type=ImageType.Roundme, Link="https://roundme.com/embed/JKgK4Wb7OeqM4tfrHu6Y", RoomName="vind" },
              new Image { Source="IMG/interior/360placeholderG2vindCopy.jpg", Type=ImageType.Roundme, Link="https://player.vimeo.com/video/526129528", RoomName="kok" },
              new Image { Source="IMG/interior/G3(kt)-Plan-1_3D_medium.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G3(kt)-Plan-2_3D_medium.jpg", Type=ImageType.Image },
              new Image { Source="IMG/interior/G2-Plan-3_3D_medium.jpg", Type=ImageType.Image },
            },
            Comment = "Med sin kubistiska utformning och minimalistiska formspråk sticker lägenheten ut från mängden. Här är det de anspråkslösa detaljerna som väcker intresset. Det stilrent takade entrépartiet följs upp invändigt av ett effektfullt ljusschakt med full takhöjd genom båda våningsplanen och ett högt glasparti."
          }},
        };
      }

      return data[type];
    }
  }
}
