#if DEBUG || RELEASE
#define RUN_DBX
#define FROM_XL
#endif
#undef RUN_DBX

using System.Collections.Generic;
using ClosedXML.Excel;
#if RUN_DBX
using System.Threading.Tasks;
using Bovaljare.Util;
#endif

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

    public static readonly Dictionary<StatusType, string> StatusDisplayName = new() {
      { StatusType.Available, "Ledig" },
      { StatusType.Booked, "Reserverad" },
      { StatusType.Sold, "Såld" },
      { StatusType.Upcoming, "Kommande etapp" },
      { StatusType.Showcase, "Visningshus" },
    };

    private static readonly Dictionary<string, List<House>> houseData = new();
#if RUN_DBX
    private static readonly Dictionary<string, Dbx> dbx = new();
#endif

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


    public static House Get(int id, string project)
    {
      return houseData[project].Find(house => house.ID == id);
    }

    public static House GetColor(string houseNumber)
    {
      return new House { ID = 0, Sqm = "148 m²", HouseNumber = "0", Status = StatusType.Available, Housetype = "V2-color" };
    }

    public static StatusType GetStatusType(string status) {
      foreach (KeyValuePair<StatusType, string> statusPair in StatusDisplayName) {
        if (statusPair.Value == status)
          return statusPair.Key;
      }

      return StatusType.Available;
    }

    public static List<House> GetHouseDataCopy(string project)
    {
      List<House> houses = GetHouseData(project);
      List<House> copy = new(houses.Count);

      foreach (House house in houses) {
        copy.Add(new House {
          ID = house.ID,
          HouseNumber = house.HouseNumber,
          Address = house.Address,
          Area = house.Area,
          Housetype = house.Housetype,
          Sqm = house.Sqm,
          Price = house.Price,
          Rent = house.Rent,
          LandArea = house.LandArea,
          Status = house.Status,
          PropertyType = house.PropertyType,
          HouseFact = house.HouseFact,
        });
      }

      return copy;
    }

    public string DisplaySqm(string def = null)
    {
      if (!string.IsNullOrEmpty(Sqm))
        return Sqm + " m²";
      else
        return def ?? "";
    }

    public string DisplayLandArea(string def = null)
    {
      if (!string.IsNullOrEmpty(LandArea))
        return LandArea + " m²";
      else
        return def ?? "";
    }

    public string DisplayPrice(string def = null)
    {
      if (!string.IsNullOrEmpty(Price))
        return string.Format("{0:# ### ### ###} kr", int.Parse(Price));
      else
        return def ?? "";
    }

    public string DisplayRent(string def = null)
    {
      if (!string.IsNullOrEmpty(Rent))
        return string.Format("{0:# ### ### ###} kr/mån", int.Parse(Rent));
      else
        return def ?? "";
    }

    public bool DisplayInfo()
    {
      return Status == StatusType.Available || Status == StatusType.Booked;
    }

#if RUN_DBX
    public static async Task<List<House>> GetHouseData(string project)
    {
      if (true) //house data is always loaded, TODO: fix so it only needs to redownload when updated...
      {
        if (!houseData.ContainsKey(project)) {
          houseData.Add(project, null);
          dbx.Add(project, new Dbx(project));
        }
        List<House> houses = null;

        using (var excel = await dbx[project].DownloadExcelFile()) {
          var sheet = excel.Worksheet(1);
          int totalHouses = sheet.LastRowUsed().RowNumber() - 1;

          houses = new List<House>(totalHouses);
          for (int id = 1; id <= totalHouses; id++) {
            int row = id + 1;
            houses.Add(new House {
              ID = id,
              HouseNumber = sheet.Cell(row, 1).GetString(),
              Address = sheet.Cell(row, 2).GetString(),
              Sqm = sheet.Cell(row, 3).GetString(),
              LandArea = sheet.Cell(row, 4).GetString(),
              Price = sheet.Cell(row, 5).GetFormattedString(),
              Rent = sheet.Cell(row, 6).GetFormattedString(),
              PropertyType = sheet.Cell(row, 7).GetString(),
              Status = GetStatusType(sheet.Cell(row, 8).GetString()),
              Housetype = sheet.Cell(row, 9).GetString(),
              HouseFact = sheet.Cell(row, 10).GetString(),
            });
          }
        }
        houseData[project] = houses;
      }

      return houseData[project];
    }
#elif FROM_XL
    public static List<House> GetHouseData(string project)
    {
      if (!houseData.ContainsKey(project)) {
        houseData.Add(project, new List<House>());
      }
      List<House> houses;

      using (var excel = new XLWorkbook(@"wwwroot\data\houses\" + project + ".xlsx")) {
        var sheet = excel.Worksheet(1);
        int totalHouses = sheet.LastRowUsed().RowNumber() - 1;

        houses = new List<House>(totalHouses);
        for (int id = 1; id <= totalHouses; id++) {
          int row = id + 1;
          houses.Add(new House {
            ID = id,
            HouseNumber = sheet.Cell(row, 1).GetString(),
            Address = sheet.Cell(row, 2).GetString(),
            Sqm = sheet.Cell(row, 3).GetString(),
            LandArea = sheet.Cell(row, 4).GetString(),
            Price = sheet.Cell(row, 5).GetString(),
            Rent = sheet.Cell(row, 6).GetString(),
            PropertyType = sheet.Cell(row, 7).GetString(),
            Status = GetStatusType(sheet.Cell(row, 8).GetString()),
            Housetype = sheet.Cell(row, 9).GetString(),
            HouseFact = sheet.Cell(row, 10).GetString(),
          });
        }
        houseData[project] = houses;
      }

      return houseData[project];
    }
#else
    public static List<House> GetHouseData(string project)
    {
      if (!houseData.ContainsKey(project)) {
        List<House> houses = null;
        if (project == "WIJK") {
          int id = 1;
          houses = new List<House> {
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "1", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr1.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "2", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr2.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "3", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr3.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "4", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr4.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "5", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr5.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "6", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr6.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "7", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr7.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "8", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr8.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "9", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr9.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "10", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr10.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "11", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr11.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "12", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr12.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "13", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr13.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "14", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr14.pdf" },
            new House { ID = id++, Sqm = "148 m²", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "15", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr15.pdf" },
            new House { ID = id++, Sqm = "148 m²", HouseNumber = "16", Status = StatusType.Showcase, Housetype="G3K-grey", HouseFact="Ag3Husnr16.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="309 m²", PropertyType = "Äganderätt", HouseNumber = "17", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr17.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="350 m²", PropertyType = "Äganderätt", HouseNumber = "18", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr18.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="553 m²", PropertyType = "Äganderätt", HouseNumber = "19", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr19.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="313 m²", PropertyType = "Äganderätt", HouseNumber = "20", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr20.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="239 m²", PropertyType = "Äganderätt", HouseNumber = "21", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr21.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="308 m²", PropertyType = "Äganderätt", HouseNumber = "22", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr22.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="362 m²", PropertyType = "Äganderätt", HouseNumber = "23", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr23.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="265 m²", Rent = "5 500 kr/mån", HouseNumber = "24", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_24.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="153 m²", Rent = "5 500 kr/mån", HouseNumber = "25", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_25.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="153 m²", Rent = "5 500 kr/mån", HouseNumber = "26", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_26.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="153 m²", Rent = "5 500 kr/mån", HouseNumber = "27", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_27.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="203 m²", Rent = "5 500 kr/mån", HouseNumber = "28", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_28.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="205 m²", Rent = "5 500 kr/mån", HouseNumber = "29", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_29.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="154 m²", Rent = "5 500 kr/mån", HouseNumber = "30", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_30.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="154 m²", Rent = "5 500 kr/mån", HouseNumber = "31", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_31.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="151 m²", Rent = "5 500 kr/mån", HouseNumber = "32", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_32.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="227 m²", Rent = "5 500 kr/mån", HouseNumber = "33", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_33.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="327 m²", Rent = "5 500 kr/mån", HouseNumber = "34", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="BRF2_34.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="167 m²", Rent = "5 500 kr/mån", HouseNumber = "35", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="BRF2_35.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="179 m²", Rent = "5 500 kr/mån", HouseNumber = "36", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="BRF2_36.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="283 m²", Rent = "5 500 kr/mån", HouseNumber = "37", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="BRF2_37.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="307 m²", Rent = "5 500 kr/mån", HouseNumber = "38", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_38.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="244 m²", Rent = "5 500 kr/mån", HouseNumber = "39", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_39.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="238 m²", Rent = "5 500 kr/mån", HouseNumber = "40", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_40.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="232 m²", Rent = "5 500 kr/mån", HouseNumber = "41", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_41.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="225 m²", Rent = "5 500 kr/mån", HouseNumber = "42", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_42.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="305 m²", Rent = "5 500 kr/mån", HouseNumber = "43", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_43.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="606 m²", PropertyType = "Äganderätt", HouseNumber = "44", Status = StatusType.Sold, Housetype="V2-red", HouseFact="Ag1Husnr44.pdf" },
            new House { ID = id++, Sqm = "150 m²", HouseNumber = "45", PropertyType = "Äganderätt", Status = StatusType.Showcase, Housetype="V2-grey", HouseFact="Ag1Husnr45.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="570 m²", PropertyType = "Äganderätt", HouseNumber = "46", Status = StatusType.Sold, Housetype="V2-grey", HouseFact="Ag1Husnr46.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="445 m²", PropertyType = "Äganderätt", HouseNumber = "47", Status = StatusType.Sold, Housetype="V2-red", HouseFact="Ag1Husnr47.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="381 m²", PropertyType = "Äganderätt", HouseNumber = "48", Status = StatusType.Sold, Housetype="V2-grey", HouseFact="Ag1Husnr48.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="439 m²", PropertyType = "Äganderätt", HouseNumber = "49", Status = StatusType.Sold, Housetype="V2-red", HouseFact="Ag1Husnr49.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="380 m²", PropertyType = "Äganderätt", HouseNumber = "50", Status = StatusType.Sold, Housetype="V2-grey", HouseFact="Ag1Husnr50.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="414 m²", PropertyType = "Äganderätt", HouseNumber = "51", Status = StatusType.Sold, Housetype="V2-green", HouseFact="Ag1Husnr51.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="387 m²", PropertyType = "Äganderätt", HouseNumber = "52", Status = StatusType.Sold, Housetype="V2-green", HouseFact="Ag1Husnr52.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="380 m²", Price = "7 880 000 kr", PropertyType = "Äganderätt", HouseNumber = "53", Status = StatusType.Available, Housetype="V2-green", HouseFact="Ag1Husnr53.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="384 m²", PropertyType = "Äganderätt", HouseNumber = "54", Status = StatusType.Sold, Housetype="V2-green", HouseFact="Ag1Husnr54.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="474 m²", PropertyType = "Äganderätt", HouseNumber = "55", Status = StatusType.Sold, Housetype="V2-green", HouseFact="Ag1Husnr55.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="380 m²", Price = "7 070 000 kr", PropertyType = "Äganderätt", HouseNumber = "56", Status = StatusType.Available, Housetype="G3K-top-red", HouseFact="ag2_56.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="272 m²", Price = "6 820 000 kr", PropertyType = "Äganderätt", HouseNumber = "57", Status = StatusType.Available, Housetype="G3K-top-red", HouseFact="ag2_57.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="357 m²", Price = "6 970 000 kr", PropertyType = "Äganderätt", HouseNumber = "58", Status = StatusType.Available, Housetype="G3K-top-red", HouseFact="ag2_58.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="410 m²", Price = "7 170 000 kr", PropertyType = "Äganderätt", HouseNumber = "59", Status = StatusType.Available, Housetype="G3K-top-red", HouseFact="ag2_59.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="345 m²", Price = "6 850 000 kr", PropertyType = "Äganderätt", HouseNumber = "60", Status = StatusType.Booked, Housetype="G3K-top-red", HouseFact="ag2_60.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="380 m²", PropertyType = "Äganderätt", HouseNumber = "61", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_61.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="225 m²", PropertyType = "Äganderätt", HouseNumber = "62", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_62.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="221 m²", Price = "6 870 000 kr", PropertyType = "Äganderätt", HouseNumber = "63", Status = StatusType.Available, Housetype="G3K-top-grey", HouseFact="ag2_63.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="296 m²", PropertyType = "Äganderätt", HouseNumber = "64", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_64.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="191 m²", PropertyType = "Äganderätt", HouseNumber = "65", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_65.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="169 m²", PropertyType = "Äganderätt", HouseNumber = "66", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_66.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="182 m²", PropertyType = "Äganderätt", HouseNumber = "67", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_67.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="196 m²", Price = "6 070 000 kr", PropertyType = "Äganderätt", HouseNumber = "68", Status = StatusType.Available, Housetype="G3K-top-grey", HouseFact="ag2_68.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="209 m²", PropertyType = "Äganderätt", HouseNumber = "69", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_69.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="343 m²", PropertyType = "Äganderätt", HouseNumber = "70", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_70.pdf" },
          };
        } else if (project == "SolHav" || project == "solhav") {
          int id = 1;
          houses = new List<House> {
            new House { ID = id++, Address = "Ostronvägen 1", Sqm = "154 m²", LandArea="401 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "132", Status = StatusType.Available, Housetype="150 SP", HouseFact="BOFAKTABLAD_Hus 150-SP.pdf" },
            new House { ID = id++, Address = "Ostronvägen 2", Sqm = "154 m²", LandArea="360 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "125", Status = StatusType.Sold, Housetype="150", HouseFact="BOFAKTABLAD_Hus 150.pdf" },
            new House { ID = id++, Address = "Ostronvägen 3", Sqm = "154 m²", LandArea="234 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "131", Status = StatusType.Available, Housetype="150 SP", HouseFact="BOFAKTABLAD_Hus 150-SP.pdf" },
            new House { ID = id++, Address = "Ostronvägen 4", Sqm = "154 m²", LandArea="307 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "124", Status = StatusType.Available, Housetype="150", HouseFact="BOFAKTABLAD_Hus 150.pdf" },
            new House { ID = id++, Address = "Ostronvägen 5", Sqm = "154 m²", LandArea="324 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "130", Status = StatusType.Available, Housetype="150 SP", HouseFact="BOFAKTABLAD_Hus 150-SP.pdf" },
            new House { ID = id++, Address = "Ostronvägen 6", Sqm = "154 m²", LandArea="307 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "123", Status = StatusType.Available, Housetype="150", HouseFact="BOFAKTABLAD_Hus 150.pdf" },
            new House { ID = id++, Address = "Ostronvägen 7", Sqm = "154 m²", LandArea="324 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "129", Status = StatusType.Available, Housetype="150 SP", HouseFact="BOFAKTABLAD_Hus 150-SP.pdf" },
            new House { ID = id++, Address = "Ostronvägen 8", Sqm = "154 m²", LandArea="307 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "122", Status = StatusType.Available, Housetype="150", HouseFact="BOFAKTABLAD_Hus 150.pdf" },
            new House { ID = id++, Address = "Ostronvägen 9", Sqm = "154 m²", LandArea="324 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "128", Status = StatusType.Available, Housetype="150 SP", HouseFact="BOFAKTABLAD_Hus 150-SP.pdf" },
            new House { ID = id++, Address = "Ostronvägen 10", LandArea="307 m²", HouseNumber = "121", Status = StatusType.Showcase, Housetype="120 typ 1 SP", HouseFact="BOFAKTABLAD_Hus 120_TYP 1-SP.pdf" },
            new House { ID = id++, Address = "Ostronvägen 11", LandArea="324 m²", HouseNumber = "127", Status = StatusType.Showcase, Housetype="120 typ 1", HouseFact="BOFAKTABLAD_Hus 120_TYP 1.pdf" },
            new House { ID = id++, Address = "Ostronvägen 12", Sqm = "120,5 m²", LandArea="344 m²", Price = "5 650 000  kr", PropertyType = "Äganderätt", HouseNumber = "120", Status = StatusType.Available, Housetype="120 typ 2 SP", HouseFact="BOFAKTABLAD_Hus 120_TYP 2-SP.pdf" },
            new House { ID = id++, Address = "Ostronvägen 13", Sqm = "120,5 m²", LandArea="359 m²", Price = "5 650 000  kr", PropertyType = "Äganderätt", HouseNumber = "126", Status = StatusType.Available, Housetype="120 typ 2", HouseFact="BOFAKTABLAD_Hus 120_TYP 2.pdf" },
            new House { ID = id++, Address = "Räkvägen 1", Sqm = "154 m²", LandArea="389 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "147", Status = StatusType.Available, Housetype="150 SP", HouseFact="BOFAKTABLAD_Hus 150-SP.pdf" },
            new House { ID = id++, Address = "Räkvägen 2", Sqm = "154 m²", LandArea="462 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "140", Status = StatusType.Available, Housetype="150", HouseFact="BOFAKTABLAD_Hus 150.pdf" },
            new House { ID = id++, Address = "Räkvägen 3", Sqm = "154 m²", LandArea="310 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "146", Status = StatusType.Available, Housetype="150 SP", HouseFact="BOFAKTABLAD_Hus 150-SP.pdf" },
            new House { ID = id++, Address = "Räkvägen 4", Sqm = "154 m²", LandArea="356 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "139", Status = StatusType.Available, Housetype="150", HouseFact="BOFAKTABLAD_Hus 150.pdf" },
            new House { ID = id++, Address = "Räkvägen 5", Sqm = "154 m²", LandArea="312 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "145", Status = StatusType.Available, Housetype="150 SP", HouseFact="BOFAKTABLAD_Hus 150-SP.pdf" },
            new House { ID = id++, Address = "Räkvägen 6", Sqm = "154 m²", LandArea="339 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "138", Status = StatusType.Available, Housetype="150", HouseFact="BOFAKTABLAD_Hus 150.pdf" },
            new House { ID = id++, Address = "Räkvägen 7", Sqm = "154 m²", LandArea="313 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "144", Status = StatusType.Available, Housetype="150 SP", HouseFact="BOFAKTABLAD_Hus 150-SP.pdf" },
            new House { ID = id++, Address = "Räkvägen 8", Sqm = "154 m²", LandArea="325 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "137", Status = StatusType.Available, Housetype="150", HouseFact="BOFAKTABLAD_Hus 150.pdf" },
            new House { ID = id++, Address = "Räkvägen 9", Sqm = "154 m²", LandArea="309 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "143", Status = StatusType.Available, Housetype="150 SP", HouseFact="BOFAKTABLAD_Hus 150-SP.pdf" },
            new House { ID = id++, Address = "Räkvägen 10", Sqm = "154 m²", LandArea="319 m²", Price = "6 454 000 kr", PropertyType = "Äganderätt", HouseNumber = "136", Status = StatusType.Booked, Housetype="150", HouseFact="BOFAKTABLAD_Hus 150.pdf" },
            new House { ID = id++, Address = "Räkvägen 11", LandArea="309 m²", HouseNumber = "142", Status = StatusType.Showcase, Housetype="120 typ 1", HouseFact="BOFAKTABLAD_Hus 120_TYP 1.pdf" },
            new House { ID = id++, Address = "Räkvägen 12", LandArea="316 m²", HouseNumber = "135", Status = StatusType.Showcase, Housetype="120 typ 1 SP", HouseFact="BOFAKTABLAD_Hus 120_TYP 1-SP.pdf" },
            new House { ID = id++, Address = "Räkvägen 13", Sqm = "120,5 m²", LandArea="356 m²", Price = "5 650 000 kr", PropertyType = "Äganderätt", HouseNumber = "141", Status = StatusType.Sold, Housetype="120 typ 2", HouseFact="BOFAKTABLAD_Hus 120_TYP 2.pdf" },
            new House { ID = id++, Address = "Räkvägen 14", LandArea="314 m²", HouseNumber = "134", Status = StatusType.Showcase, Housetype="120 typ 1 SP", HouseFact="BOFAKTABLAD_Hus 120_TYP 1-SP.pdf" },
            new House { ID = id++, Address = "Räkvägen 16", Sqm = "120,5 m²", LandArea="360 m²", Price = "5 650 000 kr", PropertyType = "Äganderätt", HouseNumber = "133", Status = StatusType.Sold, Housetype="120 typ 2 SP", HouseFact="BOFAKTABLAD_Hus 120_TYP 2-SP.pdf" },
          };
        } else if (project == "Kilen") {
          int id = 1;
          houses = new List<House> {
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "1", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "2", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "3", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "4", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "5", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "6", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "7", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "8", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "9", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "10", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "11", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "12", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "13", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "14", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "15", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "16", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "17", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "18", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "19", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "20", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "21", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "22", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "23", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "24", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "25", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "26", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "27", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "28", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", PropertyType = "Bostadsrätt", HouseNumber = "29", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
          };
        }
        houseData[project] = houses;
      }
      return houseData[project];
    }
#endif
      }
}
