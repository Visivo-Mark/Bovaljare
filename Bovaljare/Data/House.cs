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

    private static Dictionary<string, List<House>> houseData =
      new Dictionary<string, List<House>>();

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
      return new House { ID = 0, Sqm = "148 m²", LandArea = "-", Price = "-", Rent = "-", HouseNumber = "0", Status = StatusType.Available, Housetype = "V2-color" };
    }

    public static StatusType GetStatusType(string status) {
      foreach (KeyValuePair<StatusType, string> statusPair in StatusDisplayName) {
        if (statusPair.Value == status)
          return statusPair.Key;
      }

      return StatusType.Available;
    }

    public static List<House> GetHouseData(string project)
    {
      if (true) //true so that the data is loaded at real time, TODO fix so it only needs to redownload when updated...
      {
        if (!houseData.ContainsKey(project))
          houseData.Add(project, null);
        List<House> houses = null;

        if (project == "WIJK")
        {
          int id = 1;
          houses = new List<House> {
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "1", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr1.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "2", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr2.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "3", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr3.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "4", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr4.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "5", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr5.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "6", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr6.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "7", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr7.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "8", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr8.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "9", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr9.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "10", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr10.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "11", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr11.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "12", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Brf1Husnr12.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "13", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr13.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "14", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr14.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "5 450 kr/mån", PropertyType = "Bostadsrätt", HouseNumber = "15", Status = StatusType.Sold, Housetype="G3K-red", HouseFact="Brf1Husnr15.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="-", Price = "-", Rent = "-", HouseNumber = "16", Status = StatusType.Showcase, Housetype="G3K-grey", HouseFact="Ag3Husnr16.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="309 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "17", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr17.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="350 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "18", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr18.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="553 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "19", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr19.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="313 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "20", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr20.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="239 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "21", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr21.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="308 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "22", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr22.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="362 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "23", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="Ag3Husnr23.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="265 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "24", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_24.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="153 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "25", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_25.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="153 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "26", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_26.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="153 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "27", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_27.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="203 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "28", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_28.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="205 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "29", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_29.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="154 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "30", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_30.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="154 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "31", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_31.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="151 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "32", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_32.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="227 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "33", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_33.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="327 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "34", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="BRF2_34.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="167 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "35", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="BRF2_35.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="179 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "36", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="BRF2_36.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="283 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "37", Status = StatusType.Sold, Housetype="G3K-grey", HouseFact="BRF2_37.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="307 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "38", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_38.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="244 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "39", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_39.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="238 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "40", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_40.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="232 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "41", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_41.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="225 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "42", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_42.pdf" },
            new House { ID = id++, Sqm = "151 m²", LandArea="305 m²", Price = "-", Rent = "5 500 kr/mån", HouseNumber = "43", Status = StatusType.Sold, Housetype="G2", HouseFact="BRF2_43.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="606 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "44", Status = StatusType.Sold, Housetype="V2-red", HouseFact="Ag1Husnr44.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="-", Price = "-", Rent = "-", HouseNumber = "45", PropertyType = "Äganderätt", Status = StatusType.Showcase, Housetype="V2-grey", HouseFact="Ag1Husnr45.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="570 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "46", Status = StatusType.Sold, Housetype="V2-grey", HouseFact="Ag1Husnr46.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="445 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "47", Status = StatusType.Sold, Housetype="V2-red", HouseFact="Ag1Husnr47.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="381 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "48", Status = StatusType.Sold, Housetype="V2-grey", HouseFact="Ag1Husnr48.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="439 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "49", Status = StatusType.Sold, Housetype="V2-red", HouseFact="Ag1Husnr49.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="380 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "50", Status = StatusType.Sold, Housetype="V2-grey", HouseFact="Ag1Husnr50.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="414 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "51", Status = StatusType.Sold, Housetype="V2-green", HouseFact="Ag1Husnr51.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="387 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "52", Status = StatusType.Sold, Housetype="V2-green", HouseFact="Ag1Husnr52.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="380 m²", Price = "7 880 000 kr", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "53", Status = StatusType.Available, Housetype="V2-green", HouseFact="Ag1Husnr53.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="384 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "54", Status = StatusType.Sold, Housetype="V2-green", HouseFact="Ag1Husnr54.pdf" },
            new House { ID = id++, Sqm = "150 m²", LandArea="474 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "55", Status = StatusType.Sold, Housetype="V2-green", HouseFact="Ag1Husnr55.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="380 m²", Price = "7 070 000 kr", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "56", Status = StatusType.Available, Housetype="G3K-top-red", HouseFact="ag2_56.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="272 m²", Price = "6 820 000 kr", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "57", Status = StatusType.Available, Housetype="G3K-top-red", HouseFact="ag2_57.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="357 m²", Price = "6 970 000 kr", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "58", Status = StatusType.Available, Housetype="G3K-top-red", HouseFact="ag2_58.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="410 m²", Price = "7 170 000 kr", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "59", Status = StatusType.Available, Housetype="G3K-top-red", HouseFact="ag2_59.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="345 m²", Price = "6 850 000 kr", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "60", Status = StatusType.Booked, Housetype="G3K-top-red", HouseFact="ag2_60.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="380 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "61", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_61.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="225 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "62", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_62.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="221 m²", Price = "6 870 000 kr", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "63", Status = StatusType.Available, Housetype="G3K-top-grey", HouseFact="ag2_63.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="296 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "64", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_64.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="191 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "65", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_65.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="169 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "66", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_66.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="182 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "67", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_67.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="196 m²", Price = "6 070 000 kr", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "68", Status = StatusType.Available, Housetype="G3K-top-grey", HouseFact="ag2_68.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="209 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "69", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_69.pdf" },
            new House { ID = id++, Sqm = "148 m²", LandArea="343 m²", Price = "-", Rent = "-", PropertyType = "Äganderätt", HouseNumber = "70", Status = StatusType.Sold, Housetype="G3K-top-grey", HouseFact="ag2_70.pdf" },
          };
        } else if (project == "SolHav") {
          using (var memStream = new MemoryStream()) {

            GoogleDrive.GetFileStream(memStream);
            var excel = new XLWorkbook(memStream);
            var sheet = excel.Worksheet("Projekt1");
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
                Housetype = sheet.Cell(row, 8).GetString(),
                Status = GetStatusType(sheet.Cell(row, 9).GetString()),
                HouseFact = sheet.Cell(row, 10).GetString(),
              });
            }
          }
        } else if (project == "Kilen") {
          int id = 1;
          houses = new List<House> {
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "1", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "2", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "3", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "4", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "5", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "6", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "7", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "8", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "9", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "10", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "11", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "12", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "13", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "14", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "15", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "16", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "17", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "18", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "19", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "20", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "21", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "22", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "23", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "24", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "25", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "26", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "27", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "28", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
            new House { ID = id++, Sqm = "154 m²", Price = "-", Rent = "-", PropertyType = "Bostadsrätt", HouseNumber = "29", Status = StatusType.Available, Housetype="lgh", HouseFact = "Bofaktablad-Kilen_LGHA1.pdf" },
          };
        }
        houseData[project] = houses;
      }

      return houseData[project];
    }
  }
}
