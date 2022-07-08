using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;

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

    public static StatusType GetStatusType(string status) {
      foreach (KeyValuePair<StatusType, string> statusPair in StatusDisplayName) {
        if (statusPair.Value == status)
          return statusPair.Key;
      }

      return StatusType.Available;
    }

    public static List<House> GetHouseData()
    {
      if (houseData == null)
      {
        using (var memStream = new MemoryStream()) {
          
          GoogleDrive.GetFileStream(memStream);

          var excel = new XLWorkbook(memStream);
          var sheet = excel.Worksheet("Projekt1");
          int totalHouses = sheet.LastRowUsed().RowNumber() - 1;

          houseData = new List<House>(totalHouses);
          for (int id = 1; id <= totalHouses; id++) {
            int row = id + 1;
            houseData.Add(new House {
              ID = id,
              HouseNumber = sheet.Cell(row, 1).GetString(),
              Address = sheet.Cell(row, 2).GetString(),
              Sqm = sheet.Cell(row, 3).GetString(),
              LandArea = sheet.Cell(row, 4).GetString(),
              Price = sheet.Cell(row, 5).GetFormattedString(),
              Rent = sheet.Cell(row, 6).GetFormattedString(),
              PropertyType = sheet.Cell(row, 7).GetString(),
              Housetype = sheet.Cell(row, 8).GetString(),
              Status = GetStatusType(sheet.Cell(row, 9).GetString()),
              HouseFact = sheet.Cell(row, 10).GetString(),
            });
          }
        }
      }

      return houseData;
    }
  }
}
