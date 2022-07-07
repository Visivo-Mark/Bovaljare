using System.Collections.Generic;

namespace Bovaljare.Data
{
  public class House
  {
    public enum StatusType {
      Available,
      Booked,
      Sold,
      Upcoming,
      Showcase
    }

    public static Dictionary<StatusType, string> StatusDisplayName = new Dictionary<StatusType, string> {
      { StatusType.Available, "Ledig" },
      { StatusType.Booked, "Reserverad" },
      { StatusType.Sold, "Såld" },
      { StatusType.Upcoming, "Kommande etapp" },
      { StatusType.Showcase, "Visningshus" },
    };

    private static List<House> houseData;

    public int ID { get; set; }
    public string HouseNumber { get; set; }
    public string Address { get; set; }
    public int Area { get; set; }
    public string Housetype { get; set; }
    public string Sqm { get; set; }
    public string Price { get; set; }
    public string Rent { get; set; }
    public string LandArea { get; set; }
    public StatusType Status { get; set; }
    public string PropertyType { get; set; }
    public string HouseFact { get; set; }

    public static House Get(int id)
    {
      return houseData.Find(house => house.ID == id);
    }

    public static House GetColor(string houseNumber)
    {
      return new House { ID = 0, Sqm = "148 m²", LandArea = "-", Price = "-", Rent = "-", HouseNumber = "0", Status = StatusType.Available, Housetype = "V2-color" };
    }

    public static List<House> GetHouseData()
    {
      if (houseData == null)
      {
        int id = 1;
        houseData = new List<House> {
          new House { ID = id++, HouseNumber = "132", Sqm = "154 m²", LandArea = "401 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Ostronvägen 1", Status = StatusType.Available, Housetype="SH-1", HouseFact="Brf1Husnr13.pdf" },
          new House { ID = id++, HouseNumber = "125", Sqm = "154 m²", LandArea = "360 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Ostronvägen 2", Status = StatusType.Available, Housetype="SH-1", HouseFact="Brf1Husnr6.pdf" },
          new House { ID = id++, HouseNumber = "131", Sqm = "154 m²", LandArea = "234 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Ostronvägen 3", Status = StatusType.Available, Housetype="SH-1", HouseFact="Brf1Husnr12.pdf" },
          new House { ID = id++, HouseNumber = "124", Sqm = "154 m²", LandArea = "307 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Ostronvägen 4", Status = StatusType.Available, Housetype="SH-1", HouseFact="Brf1Husnr5.pdf" },
          new House { ID = id++, HouseNumber = "130", Sqm = "154 m²", LandArea = "324 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Ostronvägen 5", Status = StatusType.Available, Housetype="SH-1", HouseFact="Brf1Husnr11.pdf" },
          new House { ID = id++, HouseNumber = "123", Sqm = "154 m²", LandArea = "307 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Ostronvägen 6", Status = StatusType.Available, Housetype="SH-1", HouseFact="Brf1Husnr4.pdf" },
          new House { ID = id++, HouseNumber = "129", Sqm = "154 m²", LandArea = "324 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Ostronvägen 7", Status = StatusType.Available, Housetype="SH-1", HouseFact="Brf1Husnr10.pdf" },
          new House { ID = id++, HouseNumber = "122", Sqm = "154 m²", LandArea = "307 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Ostronvägen 8", Status = StatusType.Available, Housetype="SH-1", HouseFact="Brf1Husnr3.pdf" },
          new House { ID = id++, HouseNumber = "128", Sqm = "154 m²", LandArea = "324 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Ostronvägen 9", Status = StatusType.Available, Housetype="SH-1", HouseFact="Brf1Husnr9.pdf" },
          new House { ID = id++, HouseNumber = "121", LandArea = "307 m²", Address = "Ostronvägen 10", Status = StatusType.Showcase, Housetype="SH-1", HouseFact="Brf1Husnr2.pdf" },
          new House { ID = id++, HouseNumber = "127", LandArea = "324 m²", Address = "Ostronvägen 11", Status = StatusType.Showcase, Housetype="SH-1", HouseFact="Brf1Husnr8.pdf" },
          new House { ID = id++, HouseNumber = "120", Sqm = "120,5 m²", LandArea = "344 m²", Price = "5 650 000 kr", PropertyType = "Äganderätt", Address = "Ostronvägen 12", Status = StatusType.Available, Housetype="SH-1", HouseFact="Brf1Husnr1.pdf" },
          new House { ID = id++, HouseNumber = "126", Sqm = "120,5 m²", LandArea = "359 m²", Price = "5 650 000 kr", PropertyType = "Äganderätt", Address = "Ostronvägen 13", Status = StatusType.Available, Housetype="SH-1", HouseFact="Brf1Husnr7.pdf" },
          new House { ID = id++, HouseNumber = "147", Sqm = "154 m²", LandArea = "389 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Räkvägen 1", Status = StatusType.Available, Housetype="SH-1", HouseFact="BRF2_28.pdf" },
          new House { ID = id++, HouseNumber = "140", Sqm = "154 m²", LandArea = "462 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Räkvägen 2", Status = StatusType.Available, Housetype="SH-1", HouseFact="Ag3Husnr21.pdf" },
          new House { ID = id++, HouseNumber = "146", Sqm = "154 m²", LandArea = "310 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Räkvägen 3", Status = StatusType.Available, Housetype="SH-1", HouseFact="BRF2_27.pdf" },
          new House { ID = id++, HouseNumber = "139", Sqm = "154 m²", LandArea = "356 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Räkvägen 4", Status = StatusType.Available, Housetype="SH-1", HouseFact="Ag3Husnr20.pdf" },
          new House { ID = id++, HouseNumber = "145", Sqm = "154 m²", LandArea = "312 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Räkvägen 5", Status = StatusType.Available, Housetype="SH-1", HouseFact="BRF2_26.pdf" },
          new House { ID = id++, HouseNumber = "138", Sqm = "154 m²", LandArea = "339 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Räkvägen 6", Status = StatusType.Available, Housetype="SH-1", HouseFact="Ag3Husnr19.pdf" },
          new House { ID = id++, HouseNumber = "144", Sqm = "154 m²", LandArea = "313 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Räkvägen 7", Status = StatusType.Available, Housetype="SH-1", HouseFact="BRF2_25.pdf" },
          new House { ID = id++, HouseNumber = "137", Sqm = "154 m²", LandArea = "325 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Räkvägen 8", Status = StatusType.Available, Housetype="SH-1", HouseFact="Ag3Husnr18.pdf" },
          new House { ID = id++, HouseNumber = "143", Sqm = "154 m²", LandArea = "309 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Räkvägen 9", Status = StatusType.Available, Housetype="SH-1", HouseFact="BRF2_24.pdf" },
          new House { ID = id++, HouseNumber = "136", Sqm = "154 m²", LandArea = "319 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", Address = "Räkvägen 10", Status = StatusType.Available, Housetype="SH-1", HouseFact="Ag3Husnr17.pdf" },
          new House { ID = id++, HouseNumber = "142", LandArea = "309 m²", Address = "Räkvägen 11", Status = StatusType.Showcase, Housetype="SH-1", HouseFact="Ag3Husnr23.pdf" },
          new House { ID = id++, HouseNumber = "135", LandArea = "316 m²", Address = "Räkvägen 12", Status = StatusType.Showcase, Housetype="SH-1", HouseFact="Ag3Husnr16.pdf" },
          new House { ID = id++, HouseNumber = "141", Sqm = "120,5 m²", LandArea = "356 m²", Price = "5 650 000 kr", PropertyType = "Äganderätt", Address = "Räkvägen 13", Status = StatusType.Available, Housetype="SH-1", HouseFact="Ag3Husnr22.pdf" },
          new House { ID = id++, HouseNumber = "134", LandArea = "314 m²", Address = "Räkvägen 14", Status = StatusType.Showcase, Housetype="SH-1", HouseFact="Brf1Husnr15.pdf" },
          new House { ID = id++, HouseNumber = "133", Sqm = "120,5 m²", LandArea = "360 m²", Price = "5 650 000 kr", PropertyType = "Äganderätt", Address = "Räkvägen 16", Status = StatusType.Available, Housetype="SH-1", HouseFact="Brf1Husnr14.pdf" },
        };
      }

      return houseData;
    }
  }
}
