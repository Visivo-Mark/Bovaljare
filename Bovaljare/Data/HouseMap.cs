﻿using Syncfusion.Blazor.PivotView;
using System.Collections.Generic;

namespace Bovaljare.Data
{
  public class HouseMap
  {
    private static Dictionary<string, List<HouseMap>> data;
    private static readonly Dictionary<string, string> imageToVariant = new Dictionary<string, string> {
      { "IMG/OversiktStora_medium.jpg", "view-1" },
      { "IMG/Oversikt1-5_medium.jpg", "view-2" },
      //{ "IMG/SolHav_Overview_V3_BeautyElement.jpg", "view-2" },
      { "IMG/Oversikt_V2_medium.jpg", "view-3" },
      { "IMG/Oversikt8_medium.jpg", "view-4" },
      { "IMG/Oversikt11_medium.jpg", "view-5" },
      { "IMG/OversiktStora_medium2.jpg", "view-6" },
    };

    public int ID { get; set; }
    public string HouseNumber { get; set; }
    public string IMCoords { get; set; }
    public int View { get; set; }

    public static Dictionary<string, List<HouseMap>> GetHouseMapData()
    {
      if (data == null)
      {
        data = new Dictionary<string, List<HouseMap>> {
          { "view-1", new List<HouseMap> {
            new HouseMap { View=1, HouseNumber = "59", IMCoords = "1414, 885, 1298, 670, 1243, 604, 1223, 567, 1195, 522, 1179, 500, 1156, 430, 1149, 402, 1100, 401, 1096, 366, 1090, 365, 1090, 368, 997, 375, 994, 371, 996, 411, 884, 416, 902, 513, 892, 520, 882, 511, 875, 511, 874, 516, 855, 538, 838, 541, 817, 527, 814, 520, 804, 521, 804, 527, 780, 559, 780, 569, 751, 580, 749, 588, 697, 588, 653, 591, 649, 572, 610, 550, 609, 546, 600, 546, 600, 552, 577, 583, 537, 562, 537, 555, 528, 556, 529, 562, 505, 594, 467, 573, 464, 567, 456, 568, 455, 573, 433, 604, 392, 582, 390, 575, 381, 575, 381, 582, 356, 615, 316, 593, 315, 586, 305, 587, 305, 594, 282, 624, 241, 604, 239, 598, 229, 598, 230, 605, 207, 636, 163, 614, 161, 610, 150, 611, 151, 616, 128, 649, 123, 681, 41, 707, 57, 804, 77, 907, 97, 1041, 129, 1240, 264, 1322, 460, 1357, 883, 905, 1223, 926" },
            new HouseMap { View=2, HouseNumber = "56", IMCoords = "1515, 808, 1668, 804, 1709, 771, 1752, 805, 1875, 803, 1920, 767, 1959, 803, 2089, 797, 2129, 762, 2168, 799, 2245, 798, 2224, 698, 2352, 702, 2380, 698, 2397, 673, 2529, 685, 2529, 712, 2674, 724, 2684, 812, 2971, 1214, 2834, 1329, 2648, 1471, 1726, 1457, 1600, 1276, 1591, 1225, 1553, 1173, 1515, 815" },
            new HouseMap { View=3, HouseNumber = "63", IMCoords = "1440, 816, 1353, 675, 1336, 613, 1251, 488, 1240, 463, 1306, 451, 1306, 415, 1313, 398, 1318, 400, 1406, 388, 1408, 380, 1410, 381, 1421, 414, 1428, 412, 1430, 407, 1433, 409, 1441, 431, 1474, 428, 1912, 454, 1937, 479, 1956, 478, 1963, 543, 1998, 621, 2018, 621, 2024, 631, 2062, 632, 2066, 621, 2086, 620, 2093, 632, 2129, 632, 2131, 642, 2138, 642, 2143, 635, 2162, 633, 2171, 636, 2209, 623, 2210, 644, 2214, 695, 2222, 695, 2249, 802, 2163, 797, 2131, 763, 2086, 797, 1952, 799, 1919, 768, 1872, 804, 1744, 803, 1709, 773, 1666, 806" },
            new HouseMap { View=4, HouseNumber = "57", IMCoords = "2575, 686, 2531, 563, 2479, 281, 2363, 280, 2363, 255, 2345, 258, 2344, 238, 2249, 242, 2234, 292, 2173, 295, 2142, 307, 2121, 311, 2118, 315, 2051, 316, 2042, 315, 2036, 329, 2015, 326, 1917, 455, 1933, 478, 1951, 477, 1963, 531, 1991, 611, 2011, 613, 2088, 619, 2164, 631, 2178, 635, 2212, 624, 2297, 631, 2361, 669, 2576, 690" },
          }},
          { "view-2", new List<HouseMap> {
            /*new HouseMap { HouseNumber = "1", IMCoords = "2002,1820,2119,1693,2233,1745,2448,1487,2249,1412,2246,1369,2026,1282,1981,1319,1959,1311,1958,1282,1735,1473,1735,1592,1669,1654,1859,1740,1854,1751" },
            new HouseMap { HouseNumber = "2", IMCoords = "1856,1181,1660,1102,1615,1131,1613,1110,1382,1277,1385,1391,1326,1438,1488,1513,1488,1523,1618,1584,1955,1282,1960,1309,1976,1314,1997,1298,2000,1274,1902,1237,1883,1256,1856,1237" },
            new HouseMap { HouseNumber = "3", IMCoords = "1281,1380,1379,1309,1377,1274,1613,1107,1613,1126,1652,1102,1578,1075,1560,1086,1528,1069,1528,1019,1350,950,1321,971,1321,961,1085,1104,1088,1208,1030,1256,1175,1322,1175,1332" },
            */
            new HouseMap { HouseNumber = "38", IMCoords="1320, 272, 1351, 281, 1395, 249, 1394, 235, 1408, 235, 1409, 246, 1459, 308, 1513, 317, 1559, 283, 1560, 272, 1573, 272, 1575, 282, 1625, 344, 1810, 388, 1927, 382, 1961, 369, 2062, 392, 2148, 409, 2157, 402, 2162, 404, 2160, 414, 2177, 447, 2174, 482, 2428, 544, 2998, 252, 2999, 197, 2958, 183, 2969, 133, 2905, 48, 2856, 70, 2825, 62, 2816, 61, 2794, 67, 2770, 82, 2726, 69, 2712, 76, 2704, 102, 2672, 90, 2659, 100, 2654, 119, 2622, 112, 2605, 121, 2604, 122, 2604, 121, 2602, 130, 2560, 139, 2487, 155, 2373, 104, 2379, 58, 2361, 34, 2361, 23, 2335, 1, 2256, 2, 2214, 20, 2206, 17, 2131, 46, 2052, 15, 1652, 107, 1634, 82, 1634, 74, 1625, 72, 1623, 80, 1582, 111, 1542, 64, 1542, 57, 1532, 55, 1531, 64, 1465, 105, 1456, 103, 1454, 114, 1414, 150, 1414, 203, 1406, 202"},
            new HouseMap { HouseNumber = "23", IMCoords ="872, 424, 687, 365, 887, 288, 888, 282, 911, 272, 909, 250, 941, 216, 942, 203, 953, 202, 953, 206, 1066, 163, 1065, 151, 1076, 151, 1076, 165, 1119, 223, 1121, 237, 1087, 250, 1083, 244, 1076, 254, 1046, 292, 1044, 314, 1019, 326, 1023, 371, 976, 395" },
            new HouseMap { HouseNumber = "22", IMCoords ="1018, 326, 1022, 373, 975, 396, 872, 427, 1011, 470, 1098, 466, 1151, 449, 1167, 413, 1308, 317, 1254, 300, 1254, 265, 1212, 203, 1212, 197, 1201, 195, 1201, 204, 1121, 239, 1093, 249, 1082, 245, 1078, 256, 1044, 294, 1045, 314" },
            new HouseMap { HouseNumber = "21", IMCoords ="1456, 352, 1455, 305, 1406, 246, 1408, 236, 1393, 234, 1390, 249, 1313, 301, 1305, 297, 1306, 309, 1258, 350, 1256, 361, 1168, 414, 1149, 451, 1220, 487, 1338, 484, 1404, 407" },
            new HouseMap { HouseNumber = "20", IMCoords ="1467, 529, 1603, 564, 1702, 488, 1704, 481, 1663, 473, 1707, 439, 1678, 405, 1638, 393, 1623, 385, 1622, 342, 1573, 280, 1573, 270, 1558, 269, 1557, 282, 1557, 282, 1487, 335, 1472, 331, 1474, 345, 1459, 354, 1404, 409, 1399, 513" },
            new HouseMap { HouseNumber = "15", IMCoords ="1527, 636, 1611, 574, 1613, 567, 1467, 525, 1468, 446, 1442, 417, 1439, 407, 1429, 413, 1265, 377, 1264, 365, 1253, 373, 1254, 384, 1238, 429, 1210, 481, 1150, 453, 1097, 467, 1012, 471, 1003, 481, 1181, 540, 1236, 429, 1368, 456, 1377, 448, 1378, 460, 1407, 491, 1408, 562, 1455, 579, 1455, 621" },
            new HouseMap { HouseNumber = "14", IMCoords ="1468, 685, 1394, 670, 1397, 624, 1347, 610, 1342, 541, 1164, 489, 1096, 575, 986, 544, 1004, 482, 1136, 526, 1165, 488, 1189, 428, 1190, 417, 1198, 409, 1200, 421, 1369, 457, 1377, 449, 1379, 461, 1408, 492, 1410, 563, 1456, 581, 1455, 619, 1525, 639, 1472, 685" },
            new HouseMap { HouseNumber = "13", IMCoords ="1360, 761, 949, 648, 985, 549, 1094, 578, 1091, 545, 1119, 473, 1119, 462, 1130, 457, 1132, 467, 1305, 503, 1311, 497, 1314, 499, 1315, 509, 1343, 543, 1348, 613, 1396, 627, 1396, 668, 1469, 686, 1366, 764" },
            new HouseMap { HouseNumber = "19", IMCoords ="2483, 712, 2576, 602, 2168, 505, 2174, 443, 2158, 415, 2159, 402, 2149, 406, 2148, 412, 1971, 373, 1971, 365, 1959, 369, 1961, 377, 1935, 453, 1928, 551, 1927, 574" },
            new HouseMap { HouseNumber = "18", IMCoords ="2345, 776, 2496, 716, 2094, 613, 2101, 519, 2082, 489, 2083, 475, 2074, 478, 2072, 483, 1890, 443, 1890, 433, 1879, 435, 1879, 449, 1850, 528, 1843, 637" },
            new HouseMap { HouseNumber = "17", IMCoords ="2172, 850, 2343, 780, 2014, 689, 2022, 589, 2002, 559, 2003, 546, 1994, 549, 1991, 557, 1802, 513, 1802, 500, 1792, 503, 1791, 517, 1762, 598, 1757, 725" },
            new HouseMap { HouseNumber = "16", IMCoords ="1512, 809, 1537, 859, 1613, 893, 1628, 907, 1810, 975, 2004, 941, 2187, 859, 2160, 846, 1927, 777, 1935, 675, 1912, 643, 1911, 629, 1900, 636, 1704, 591, 1704, 577, 1692, 585, 1694, 598, 1663, 685, 1662, 709, 1621, 699, 1561, 750, 1559, 769, 1530, 792" },
            new HouseMap { HouseNumber = "5", IMCoords ="1851, 1213, 1999, 1211, 2012, 1069, 2018, 1056, 2295, 1068, 2296, 1097, 2322, 1095, 2443, 1219, 2340, 1219, 2339, 1184, 2324, 1182, 2324, 1146, 2315, 1147, 2314, 1165, 2303, 1162, 2306, 1098, 2294, 1098, 2294, 1069, 2285, 1065, 2286, 987, 2287, 974, 2281, 963, 2277, 979, 2160, 975, 2144, 959, 2067, 972, 2017, 971, 2012, 957, 1998, 997, 1843, 1031" },
            new HouseMap { HouseNumber = "4", IMCoords ="1999, 1215, 1845, 1217, 1849, 1303, 2005, 1309, 2021, 1157, 2304, 1162, 2305, 1186, 2339, 1186, 2342, 1223, 2444, 1223, 2547, 1310, 2359, 1307, 2359, 1278, 2322, 1275, 2324, 1185, 2304, 1186, 2304, 1161, 2302, 1054, 2297, 1053, 2297, 1070, 2018, 1060, 2010, 1078" },
            new HouseMap { HouseNumber = "3", IMCoords ="1854, 1404, 1855, 1303, 2006, 1311, 2016, 1165, 2026, 1135, 2032, 1133, 2032, 1154, 2304, 1165, 2316, 1164, 2316, 1149, 2324, 1148, 2325, 1161, 2326, 1267, 2325, 1284, 2360, 1282, 2360, 1308, 2559, 1310, 2675, 1409, 2679, 1417, 2339, 1399, 2345, 1281, 2324, 1283, 2325, 1266, 2028, 1257, 2020, 1323, 2020, 1333, 2012, 1419" },
            new HouseMap { HouseNumber = "2", IMCoords ="2014, 1417, 1855, 1409, 1852, 1519, 2086, 1528, 2098, 1387, 2120, 1355, 2124, 1368, 2348, 1377, 2354, 1510, 2814, 1531, 2679, 1417, 2344, 1403, 2348, 1282, 2352, 1268, 2341, 1250, 2335, 1270, 2031, 1260, 2022, 1325" },
            new HouseMap { HouseNumber = "1", IMCoords ="2941, 1645, 2628, 1799, 2201, 1829, 1904, 1779, 1899, 1765, 1874, 1754, 1808, 1687, 1843, 1572, 1853, 1522, 2086, 1527, 2097, 1389, 2115, 1356, 2120, 1355, 2120, 1366, 2425, 1381, 2428, 1366, 2436, 1365, 2438, 1381, 2440, 1500, 2471, 1502, 2469, 1516, 2468, 1525, 2810, 1535" },
            new HouseMap { HouseNumber = "12", IMCoords ="1188, 901, 1295, 811, 1299, 791, 1134, 738, 1130, 681, 1094, 653, 1091, 640, 1080, 644, 1069, 645, 902, 602, 901, 593, 889, 598, 890, 609, 864, 675, 1055, 744, 1059, 818, 1108, 837, 1115, 882" },
            new HouseMap { HouseNumber = "11", IMCoords ="1110, 973, 1186, 905, 1115, 880, 1109, 839, 1061, 819, 1055, 745, 1023, 717, 1011, 701, 1005, 708, 877, 678, 822, 661, 818, 649, 803, 657, 806, 671, 772, 748, 973, 813, 982, 879, 1029, 905, 1035, 940" },
            new HouseMap { HouseNumber = "10", IMCoords ="1028, 1039, 1110, 972, 1035, 940, 1032, 904, 982, 880, 974, 802, 934, 774, 929, 763, 918, 772, 788, 735, 733, 718, 729, 706, 714, 714, 717, 728, 683, 805, 884, 870, 893, 947, 954, 973, 955, 1019" },
            new HouseMap { HouseNumber = "9", IMCoords ="950, 1111, 1031, 1038, 953, 1015, 949, 970, 895, 946, 888, 864, 843, 831, 840, 820, 831, 826, 695, 793, 640, 776, 636, 764, 621, 772, 624, 786, 590, 863, 791, 928, 800, 1005, 861, 1031, 862, 1077" },
            new HouseMap { HouseNumber = "8", IMCoords ="855, 1185, 946, 1107, 863, 1081, 860, 1031, 804, 1009, 795, 927, 746, 901, 742, 889, 736, 894, 590, 858, 538, 839, 536, 829, 524, 834, 524, 850, 495, 927, 696, 1002, 705, 1079, 766, 1105, 767, 1151" },
            new HouseMap { HouseNumber = "7", IMCoords ="760, 1260, 855, 1183, 768, 1152, 765, 1104, 709, 1081, 700, 1004, 644, 977, 645, 963, 632, 967, 494, 927, 438, 910, 433, 901, 418, 905, 401, 970, 371, 996, 395, 1007, 595, 1079, 608, 1161, 664, 1187, 672, 1239" },
            new HouseMap { HouseNumber = "6", IMCoords ="760, 1263, 629, 1395, 464, 1424, 82, 1339, 70, 1337, 75, 1313, 98, 1279, 220, 1093, 251, 1075, 288, 1039, 307, 993, 306, 982, 316, 972, 322, 982, 373, 999, 390, 1007, 524, 1047, 532, 1040, 538, 1049, 593, 1081, 608, 1162, 663, 1188, 673, 1240" },
            
          }},
          { "view-3", new List<HouseMap> {
            new HouseMap { HouseNumber = "55", IMCoords ="2522, 766, 2326, 689, 2363, 671, 2376, 608, 2455, 501, 2684, 582, 2706, 647, 2704, 655, 2696, 681, 2999, 795, 3000, 913, 2915, 930" },
            new HouseMap { HouseNumber = "54", IMCoords ="2784, 1060, 2114, 747, 2179, 695, 2263, 568, 2508, 654, 2536, 723, 2522, 767, 2915, 932" },
            new HouseMap { HouseNumber = "53", IMCoords ="2624, 1212, 1912, 869, 1956, 828, 1990, 799, 2022, 771, 2034, 766, 2106, 659, 2364, 773, 2404, 838, 2395, 881, 2784, 1061" },
            new HouseMap { HouseNumber = "52", IMCoords ="1707, 1057, 1803, 979, 1867, 830, 2203, 943, 2227, 1004, 2224, 1016, 2222, 1019, 2624, 1212, 2432, 1407, 1688, 1072" },
            new HouseMap { HouseNumber = "51", IMCoords ="2095, 1744, 1379, 1654, 1490, 1161, 1600, 1141, 1646, 1032, 1844, 1114, 1855, 1107, 1915, 1132, 1916, 1143, 1912, 1146, 2021, 1186, 2064, 1223, 2061, 1241, 2432, 1408" },
            new HouseMap { HouseNumber = "44", IMCoords ="223, 985, 72, 753, 100, 731, 316, 639, 315, 602, 590, 531, 659, 652, 765, 674, 770, 684, 715, 705, 797, 761" },
            new HouseMap { HouseNumber = "47", IMCoords ="402, 1264, 368, 1238, 225, 987, 502, 878, 485, 831, 498, 767, 801, 667, 881, 809, 886, 819, 963, 869, 966, 893, 1065, 954" },
            new HouseMap { HouseNumber = "49", IMCoords ="1340, 1156, 1183, 1602, 1138, 1619, 863, 1589, 405, 1267, 462, 1237, 738, 1109, 722, 1055, 760, 999, 1092, 859, 1187, 1027, 1228, 1064, 1235, 1060, 1263, 1082, 1266, 1107, 1317, 1144, 1318, 1135, 1341, 1139" },
            new HouseMap { HouseNumber = "50", IMCoords ="1493, 644, 1570, 594, 1572, 548, 1645, 483, 1785, 425, 1851, 534, 2110, 631, 1866, 721, 1842, 736, 1706, 732" },
            new HouseMap { HouseNumber = "48", IMCoords ="1274, 550, 1496, 642, 1571, 595, 1573, 548, 1645, 487, 1667, 478, 1585, 445, 1529, 350, 1382, 398, 1330, 457, 1333, 519" },
            new HouseMap { HouseNumber = "46", IMCoords ="1332, 460, 1369, 415, 1383, 400, 1407, 392, 1364, 369, 1317, 289, 1170, 331, 1133, 385, 1030, 421, 1219, 501, 1208, 506, 1228, 514, 1231, 531, 1275, 550, 1334, 520" },
            new HouseMap { HouseNumber = "45", IMCoords ="867, 658, 882, 659, 1230, 532, 1228, 515, 1210, 508, 1219, 503, 1133, 468, 1130, 451, 1055, 393, 934, 349, 879, 441, 882, 456, 464, 577" },
          }},
          { "view-4", new List<HouseMap> {
            new HouseMap { HouseNumber = "38", IMCoords="2180, 1866, 2562, 1869, 2384, 1362, 2414, 1305, 2420, 1310, 2422, 1303, 2402, 974, 2285, 943, 2250, 941, 2222, 863, 2146, 863, 2130, 924, 2093, 925, 2084, 897, 2032, 897, 2026, 912, 2034, 941, 2091, 978, 2114, 1304, 2084, 1395, 2106, 1496, 2087, 1539" },
            new HouseMap { HouseNumber = "39", IMCoords="1850, 1869, 2180, 1871, 2089, 1541, 2107, 1494, 2085, 1394, 2116, 1303, 2090, 979, 2034, 940, 2024, 903, 1966, 903, 1960, 861, 1882, 864, 1873, 921, 1861, 920, 1862, 895, 1811, 896, 1810, 911, 1762, 909, 1762, 950, 1780, 944, 1816, 983, 1824, 1305, 1806, 1400, 1813, 1498, 1807, 1537" },
            new HouseMap { HouseNumber = "40", IMCoords="1846, 1871, 1808, 1540, 1813, 1497, 1805, 1402, 1821, 1318, 1812, 985, 1776, 947, 1749, 949, 1750, 925, 1741, 928, 1703, 927, 1693, 873, 1620, 873, 1620, 902, 1594, 904, 1590, 911, 1523, 911, 1518, 926, 1526, 946, 1526, 1307, 1525, 1388, 1531, 1871" },
            new HouseMap { HouseNumber = "41", IMCoords="1223, 1869, 1531, 1870, 1525, 1388, 1526, 948, 1520, 929, 1436, 931, 1432, 873, 1358, 873, 1355, 911, 1302, 910, 1302, 949, 1266, 947, 1240, 993, 1237, 1307, 1246, 1409, 1237, 1503, 1244, 1553" },
            new HouseMap { HouseNumber = "42", IMCoords="1302, 933, 1210, 933, 1206, 913, 1178, 911, 1174, 881, 1101, 881, 1086, 957, 992, 957, 994, 957, 951, 997, 950, 1318, 972, 1407, 954, 1501, 965, 1546, 900, 1867, 1223, 1867, 1242, 1553, 1236, 1503, 1248, 1403, 1236, 1321, 1240, 995, 1273, 950, 1304, 950" },
            new HouseMap { HouseNumber = "43", IMCoords="948, 1315, 951, 995, 994, 958, 1085, 960, 1088, 934, 1002, 938, 994, 910, 942, 911, 926, 919, 916, 883, 841, 881, 834, 914, 796, 917, 780, 956, 668, 996, 658, 1291, 452, 1872, 900, 1870, 964, 1547, 953, 1499, 974, 1404" },
            new HouseMap { HouseNumber = "24", IMCoords="2373, 745, 2820, 741, 2545, 482, 2551, 477, 2534, 264, 2320, 263, 2344, 477, 2321, 553, 2342, 613, 2326, 663" },
            new HouseMap { HouseNumber = "25", IMCoords="2174, 751, 2374, 747, 2326, 667, 2341, 613, 2319, 555, 2344, 477, 2322, 265, 2136, 265, 2147, 471, 2128, 555, 2146, 609, 2136, 649" },
            new HouseMap { HouseNumber = "26", IMCoords="1970, 750, 2172, 749, 2136, 650, 2146, 611, 2127, 555, 2147, 473, 2136, 266, 1948, 267, 1954, 475, 1938, 550, 1953, 615, 1944, 671" },
            new HouseMap { HouseNumber = "27", IMCoords="1758, 753, 1970, 751, 1942, 672, 1952, 616, 1938, 552, 1951, 475, 1943, 275, 1742, 275, 1749, 486, 1744, 564, 1752, 621, 1750, 661" },
            new HouseMap { HouseNumber = "28", IMCoords="1742, 565, 1749, 484, 1740, 278, 1556, 278, 1547, 329, 1530, 329, 1539, 757, 1755, 754, 1748, 664, 1750, 624" },
            new HouseMap { HouseNumber = "30", IMCoords="1046, 762, 1242, 757, 1244, 667, 1241, 629, 1249, 576, 1244, 497, 1242, 290, 1051, 291, 1047, 496, 1058, 577, 1052, 629, 1061, 672" },
            new HouseMap { HouseNumber = "29", IMCoords="1242, 762, 1467, 758, 1464, 669, 1464, 623, 1465, 329, 1446, 328, 1438, 290, 1241, 291, 1243, 496, 1250, 576, 1241, 631, 1243, 667" },
            new HouseMap { HouseNumber = "32", IMCoords="666, 749, 844, 772, 870, 674, 862, 635, 874, 579, 854, 498, 866, 297, 674, 297, 664, 499, 664, 509, 691, 585, 671, 632, 682, 677" },
            new HouseMap { HouseNumber = "31", IMCoords="849, 773, 1047, 763, 1060, 672, 1052, 630, 1059, 577, 1045, 499, 1053, 300, 864, 297, 854, 499, 854, 509, 875, 582, 861, 632, 872, 677" },
            new HouseMap { HouseNumber = "33", IMCoords="512, 266, 699, 268, 756, 299, 698, 299, 676, 298, 667, 469, 666, 509, 692, 585, 671, 633, 682, 677, 666, 751, 440, 723, 421, 719, 382, 625, 497, 487, 496, 472" },
          }},
          { "view-5", new List<HouseMap> {
            new HouseMap {HouseNumber = "56", IMCoords="2373, 837, 2456, 835, 2466, 809, 2582, 734, 2588, 717, 2623, 717, 2618, 735, 2688, 812, 2688, 823, 2730, 885, 2755, 905, 2812, 903, 2999, 1127, 2998, 1313, 2508, 1425, 2402, 1186, 2430, 1081, 2324, 843" },
            new HouseMap {HouseNumber = "57", IMCoords="2154, 1504, 2506, 1424, 2420, 1235, 2401, 1187, 2453, 1041, 2350, 810, 2275, 733, 2276, 717, 2248, 718, 2247, 735, 2133, 812, 2129, 839, 2075, 837, 2068, 857, 2040, 857, 2082, 1025, 2051, 1182" },
            new HouseMap {HouseNumber = "58", IMCoords="1690, 1562, 2008, 1601, 2150, 1503, 2064, 1238, 2052, 1183, 2081, 1028, 2025, 809, 1941, 729, 1938, 715, 1912, 714, 1912, 731, 1805, 809, 1803, 819, 1804, 835, 1782, 834, 1779, 853, 1635, 853" },
            new HouseMap {HouseNumber = "59", IMCoords="1257, 1511, 1687, 1563, 1632, 830, 1432, 827, 1419, 807, 1328, 748, 1325, 735, 1299, 741, 1300, 755, 1215, 851, 1215, 873, 1183, 880, 1185, 900, 1124, 915, 1197, 1149, 1210, 1255, 1233, 1306" },
            new HouseMap {HouseNumber = "60", IMCoords="772, 979, 606, 1089, 484, 1364, 1257, 1511, 1234, 1307, 1212, 1256, 1194, 1095, 1103, 875, 998, 820, 993, 805, 968, 811, 970, 831, 888, 925, 889, 938, 891, 968, 800, 987, 788, 998" },
            new HouseMap {HouseNumber = "61", IMCoords="2173, 727, 2480, 729, 2572, 654, 2580, 619, 2392, 411, 2310, 304, 2310, 290, 2290, 289, 2289, 305, 2199, 374, 2191, 413, 2133, 412, 2156, 573, 2152, 586, 2166, 627, 2156, 665" },
            new HouseMap {HouseNumber = "62", IMCoords="1894, 723, 2172, 727, 2156, 668, 2165, 629, 2156, 578, 2172, 501, 2116, 368, 2052, 304, 2052, 295, 2033, 295, 2033, 309, 1949, 374, 1939, 420, 1881, 419, 1887, 561, 1888, 581, 1895, 629, 1889, 667" },
            new HouseMap {HouseNumber = "63", IMCoords="1621, 423, 1698, 424, 1701, 371, 1780, 302, 1780, 292, 1797, 292, 1798, 304, 1867, 367, 1880, 423, 1899, 496, 1887, 583, 1895, 629, 1890, 677, 1894, 725, 1630, 725" },
            new HouseMap {HouseNumber = "64", IMCoords="1630, 723, 1624, 579, 1628, 494, 1616, 367, 1544, 304, 1545, 293, 1524, 293, 1524, 308, 1453, 369, 1449, 427, 1252, 424, 1264, 447, 1294, 492, 1300, 579, 1384, 725, 1412, 720" },
            new HouseMap {HouseNumber = "65", IMCoords="1186, 763, 1378, 721, 1299, 579, 1293, 497, 1260, 447, 1252, 428, 1220, 379, 1146, 324, 1148, 314, 1125, 319, 1128, 328, 1071, 401, 1131, 529, 1139, 613, 1156, 655, 1163, 700" },
            new HouseMap {HouseNumber = "66", IMCoords="1019, 799, 1186, 763, 1162, 703, 1157, 659, 1140, 615, 1130, 528, 1070, 405, 992, 353, 991, 342, 968, 344, 970, 358, 915, 429, 962, 555, 974, 640, 991, 687, 997, 735" },
            new HouseMap {HouseNumber = "67", IMCoords="842, 832, 1016, 795, 998, 737, 992, 688, 976, 642, 965, 557, 913, 433, 828, 376, 826, 364, 806, 366, 810, 381, 770, 433, 741, 428, 736, 426, 750, 457, 784, 584, 805, 671, 819, 722, 825, 763" },
            new HouseMap {HouseNumber = "68", IMCoords="669, 867, 842, 832, 825, 762, 818, 717, 807, 673, 786, 585, 751, 457, 736, 430, 662, 403, 660, 391, 641, 393, 641, 408, 623, 431, 586, 431, 586, 485, 609, 617, 632, 703, 641, 749, 652, 791" },
            new HouseMap {HouseNumber = "69", IMCoords="488, 900, 670, 866, 654, 792, 641, 749, 633, 705, 609, 617, 586, 485, 590, 431, 492, 429, 490, 415, 463, 417, 466, 433, 450, 435, 446, 465, 414, 510, 418, 651, 470, 803, 470, 831, 480, 841" },
            new HouseMap {HouseNumber = "70", IMCoords="223, 427, 177, 945, 191, 969, 282, 953, 487, 903, 480, 843, 466, 835, 470, 799, 454, 747, 419, 643, 413, 508, 445, 463, 446, 429" },
          }},
          { "view-6", new List<HouseMap> {
            new HouseMap { HouseNumber = "70", IMCoords="2198, 333, 2169, 296, 2236, 293, 2245, 251, 2256, 244, 2342, 240, 2343, 255, 2363, 254, 2364, 277, 2379, 276, 2385, 283, 2480, 282, 2480, 312, 2419, 315, 2405, 317, 2406, 294, 2381, 297, 2382, 281, 2364, 277, 2361, 255, 2274, 259, 2264, 275, 2254, 326" },
            new HouseMap { HouseNumber = "69", IMCoords="2207, 349, 2196, 333, 2252, 326, 2261, 276, 2274, 260, 2363, 257, 2365, 277, 2365, 280, 2382, 280, 2384, 297, 2407, 295, 2408, 316, 2483, 315, 2485, 334, 2434, 341, 2419, 315, 2407, 321, 2404, 295, 2384, 295, 2380, 278, 2364, 278, 2294, 279, 2280, 298, 2269, 345" },
            new HouseMap { HouseNumber = "68", IMCoords="2229, 370, 2210, 350, 2270, 346, 2280, 298, 2294, 281, 2382, 281, 2385, 298, 2408, 299, 2408, 319, 2420, 316, 2434, 341, 2447, 339, 2487, 336, 2490, 356, 2448, 360, 2445, 342, 2434, 341, 2421, 315, 2407, 321, 2409, 297, 2385, 298, 2310, 301, 2298, 317, 2293, 351, 2291, 369" },
            new HouseMap { HouseNumber = "67", IMCoords="2251, 396, 2231, 371, 2290, 370, 2292, 353, 2299, 317, 2311, 303, 2405, 300, 2408, 320, 2420, 318, 2432, 343, 2445, 345, 2449, 360, 2490, 359, 2492, 378, 2449, 380, 2449, 359, 2449, 342, 2435, 342, 2420, 318, 2409, 320, 2333, 324, 2321, 340, 2313, 372, 2310, 394" },
            new HouseMap { HouseNumber = "66", IMCoords="2270, 421, 2252, 398, 2310, 394, 2314, 372, 2322, 341, 2335, 325, 2422, 320, 2431, 344, 2449, 343, 2453, 378, 2453, 382, 2493, 379, 2496, 395, 2495, 402, 2448, 404, 2454, 375, 2445, 345, 2357, 348, 2340, 362, 2329, 418" },
            new HouseMap { HouseNumber = "65", IMCoords="2502, 439, 2495, 399, 2450, 399, 2448, 345, 2357, 350, 2339, 364, 2329, 419, 2269, 422, 2293, 447, 2454, 437" },
            new HouseMap { HouseNumber = "64", IMCoords="2300, 447, 2356, 442, 2363, 421, 2371, 393, 2373, 396, 2476, 405, 2473, 435, 2502, 441, 2515, 497, 2295, 481, 2298, 456, 2294, 448" },
            new HouseMap { HouseNumber = "63", IMCoords="2294, 524, 2525, 543, 2515, 498, 2474, 489, 2480, 445, 2372, 436, 2363, 452, 2357, 487, 2296, 483" },
            new HouseMap { HouseNumber = "62", IMCoords="2538, 592, 2295, 570, 2297, 527, 2355, 531, 2364, 495, 2374, 477, 2484, 488, 2481, 529, 2480, 543, 2524, 545" },
            new HouseMap { HouseNumber = "61", IMCoords="2567, 683, 2361, 669, 2295, 627, 2296, 572, 2356, 577, 2360, 556, 2368, 529, 2374, 523, 2490, 534, 2483, 593, 2497, 595, 2542, 597" },
            new HouseMap { HouseNumber = "60", IMCoords="2142, 348, 2137, 312, 2045, 317, 2035, 328, 2017, 330, 1966, 396, 2001, 400, 2014, 397, 2020, 406, 2031, 408, 2140, 392" },
            new HouseMap { HouseNumber = "59", IMCoords="2219, 470, 2219, 441, 2180, 392, 2169, 392, 2165, 348, 2072, 354, 2060, 368, 2055, 404, 2033, 404, 2028, 407, 2019, 407, 2015, 399, 2004, 399, 2002, 400, 2001, 403, 1967, 396, 1935, 426, 1969, 441, 1974, 446" },
            new HouseMap { HouseNumber = "58", IMCoords="2214, 528, 2219, 472, 2168, 464, 2174, 422, 2071, 414, 2066, 451, 1971, 443, 1935, 429, 1915, 455, 1930, 474, 1973, 486, 2031, 494, 2033, 504, 2053, 503, 2065, 452, 2167, 463, 2165, 498, 2164, 520" },
            new HouseMap { HouseNumber = "57", IMCoords="2213, 570, 2184, 569, 2160, 565, 2161, 542, 2161, 507, 2053, 498, 2044, 549, 2021, 548, 2025, 539, 1958, 531, 1935, 476, 1973, 488, 2031, 497, 2032, 505, 2051, 505, 2056, 494, 2064, 454, 2166, 464, 2165, 499, 2164, 521, 2190, 524, 2215, 528" },
            new HouseMap { HouseNumber = "56", IMCoords="2212, 581, 2208, 623, 2179, 635, 2166, 632, 2166, 640, 2043, 631, 1996, 629, 1959, 531, 2025, 541, 2024, 549, 2045, 550, 2056, 499, 2163, 510, 2162, 541, 2160, 565, 2184, 568, 2212, 569" },
            new HouseMap { HouseNumber = "55", IMCoords="2344, 791, 2323, 723, 2337, 716, 2338, 706, 2373, 696, 2377, 695, 2396, 676, 2529, 684, 2529, 714, 2670, 726, 2680, 803, 2564, 799, 2351, 784" },
            new HouseMap { HouseNumber = "54", IMCoords="2373, 881, 2347, 794, 2352, 785, 2399, 788, 2400, 775, 2422, 754, 2561, 763, 2564, 799, 2677, 805, 2683, 819, 2733, 889, 2380, 870" },
            new HouseMap { HouseNumber = "53", IMCoords="2798, 975, 2733, 889, 2633, 883, 2635, 849, 2487, 843, 2462, 861, 2456, 874, 2384, 870, 2376, 883, 2385, 915, 2444, 983, 2460, 977" },
            new HouseMap { HouseNumber = "52", IMCoords="2567, 1125, 2445, 983, 2459, 974, 2590, 974, 2613, 972, 2612, 966, 2638, 963, 2644, 967, 2741, 955, 2745, 975, 2798, 973, 2871, 1065, 2871, 1066" },
            new HouseMap { HouseNumber = "51", IMCoords="2833, 1320, 2590, 1187, 2594, 1154, 2568, 1125, 2655, 1114, 2657, 1100, 2663, 1086, 2750, 1073, 2759, 1081, 2856, 1069, 2869, 1067, 2964, 1206" },
            new HouseMap { HouseNumber = "50", IMCoords="2089, 955, 2245, 954, 2279, 923, 2246, 793, 2162, 793, 2129, 763, 2090, 793, 2024, 795" },
            new HouseMap { HouseNumber = "48", IMCoords="1868, 961, 2087, 957, 2024, 795, 1950, 797, 1920, 766, 1875, 800, 1825, 800" },
            new HouseMap { HouseNumber = "46", IMCoords="1826, 799, 1868, 962, 1822, 962, 1820, 950, 1805, 953, 1800, 939, 1537, 958, 1518, 810, 1670, 802, 1707, 771, 1741, 800, 1745, 803" },
            new HouseMap { HouseNumber = "45", IMCoords="1865, 1134, 1594, 1216, 1560, 1165, 1538, 959, 1644, 948, 1653, 929, 1805, 925, 1806, 954, 1820, 953" },
            new HouseMap { HouseNumber = "44", IMCoords="2109, 1452, 1729, 1439, 1605, 1268, 1814, 1206, 1813, 1193, 1881, 1144, 1941, 1192, 1948, 1219, 1975, 1218, 1975, 1208, 2048, 1206" },
            new HouseMap { HouseNumber = "47", IMCoords="2422, 1455, 2112, 1454, 2050, 1206, 2099, 1206, 2100, 1192, 2174, 1141, 2230, 1192, 2238, 1214, 2325, 1206" },
            new HouseMap { HouseNumber = "49", IMCoords="2545, 1212, 2788, 1349, 2672, 1434, 2422, 1455, 2326, 1204, 2381, 1208, 2387, 1189, 2465, 1139, 2515, 1192, 2526, 1217, 2545, 1212" },
            new HouseMap { HouseNumber = "43", IMCoords="1905, 630, 1994, 627, 1960, 533, 1954, 477, 1930, 477, 1915, 456, 1846, 449, 1850, 478, 1885, 478, 1898, 539, 1895, 567, 1899, 584, 1898, 602" },
            new HouseMap { HouseNumber = "42", IMCoords="1840, 630, 1905, 629, 1897, 604, 1899, 586, 1894, 570, 1898, 541, 1884, 479, 1850, 480, 1846, 450, 1786, 447, 1793, 478, 1828, 477, 1828, 481, 1832, 540, 1831, 571, 1835, 585, 1833, 598" },
            new HouseMap { HouseNumber = "41", IMCoords="1777, 629, 1840, 629, 1834, 601, 1835, 586, 1830, 572, 1833, 541, 1827, 478, 1792, 479, 1787, 449, 1727, 444, 1732, 478, 1765, 479, 1770, 542, 1769, 569, 1770, 586, 1772, 600" },
            new HouseMap { HouseNumber = "40", IMCoords="1708, 632, 1778, 629, 1771, 601, 1771, 586, 1768, 571, 1770, 543, 1764, 480, 1732, 480, 1728, 445, 1667, 441, 1674, 478, 1702, 477, 1704, 541, 1703, 570, 1707, 588, 1707, 599" },
            new HouseMap { HouseNumber = "39", IMCoords="1648, 632, 1710, 631, 1707, 601, 1707, 587, 1703, 570, 1704, 542, 1701, 478, 1680, 480, 1673, 479, 1668, 442, 1610, 438, 1618, 480, 1640, 480, 1643, 543, 1641, 574, 1643, 589, 1644, 604" },
            new HouseMap { HouseNumber = "38", IMCoords="1571, 630, 1544, 433, 1612, 438, 1619, 481, 1639, 481, 1642, 544, 1641, 575, 1643, 589, 1643, 604, 1647, 633, 1571, 633" },
            new HouseMap { HouseNumber = "33", IMCoords="2150, 794, 2245, 794, 2218, 695, 2211, 692, 2206, 647, 2170, 647, 2162, 632, 2141, 634, 2140, 648, 2130, 651, 2137, 706, 2129, 763" },
            new HouseMap { HouseNumber = "32", IMCoords="2055, 633, 2063, 633, 2066, 620, 2086, 618, 2093, 633, 2126, 631, 2135, 706, 2127, 762, 2150, 794, 2082, 795, 2066, 768, 2067, 753, 2060, 740, 2061, 705" },
            new HouseMap { HouseNumber = "31", IMCoords="2010, 797, 2081, 795, 2066, 769, 2067, 756, 2059, 742, 2062, 706, 2056, 634, 2023, 635, 2017, 620, 1997, 622, 1995, 635, 1987, 636, 1993, 705, 1989, 745, 1996, 757, 1993, 771" },
            new HouseMap { HouseNumber = "30", IMCoords="1944, 802, 2009, 797, 1994, 771, 1996, 759, 1989, 746, 1994, 705, 1987, 631, 1952, 632, 1947, 619, 1928, 620, 1928, 635, 1914, 634, 1921, 705, 1919, 744, 1924, 756, 1924, 769" },
            new HouseMap { HouseNumber = "29", IMCoords="1810, 669, 1853, 804, 1943, 801, 1924, 769, 1924, 756, 1918, 744, 1921, 707, 1915, 635, 1883, 635, 1880, 621, 1860, 621, 1859, 636, 1845, 637, 1830, 650, 1830, 665, 1822, 669" },
            new HouseMap { HouseNumber = "28", IMCoords="1741, 804, 1824, 802, 1807, 722, 1807, 705, 1802, 631, 1770, 632, 1767, 619, 1745, 619, 1746, 634, 1731, 634, 1735, 709, 1734, 745, 1740, 761, 1738, 774" },
            new HouseMap { HouseNumber = "27", IMCoords="1660, 636, 1676, 636, 1677, 623, 1697, 622, 1700, 636, 1730, 635, 1734, 710, 1733, 745, 1739, 761, 1736, 773, 1743, 803, 1671, 803, 1667, 766, 1661, 746, 1662, 707" },
            new HouseMap { HouseNumber = "26", IMCoords="1598, 806, 1671, 803, 1666, 768, 1661, 746, 1662, 707, 1658, 634, 1629, 634, 1626, 621, 1606, 621, 1607, 637, 1588, 637, 1588, 637, 1592, 749, 1595, 759, 1594, 773" },
            new HouseMap { HouseNumber = "25", IMCoords="1520, 813, 1600, 809, 1591, 775, 1591, 751, 1589, 637, 1558, 637, 1556, 622, 1536, 623, 1537, 637, 1516, 637" },
            new HouseMap { HouseNumber = "24", IMCoords="1354, 668, 1439, 818, 1521, 813, 1516, 637, 1489, 639, 1488, 624, 1468, 624, 1468, 639, 1445, 639, 1441, 655, 1442, 663" },
            new HouseMap { HouseNumber = "37", IMCoords="1260, 499, 1238, 463, 1309, 450, 1308, 412, 1315, 400, 1411, 385, 1419, 417, 1422, 433, 1474, 428, 1545, 433, 1546, 464, 1435, 470, 1419, 417, 1326, 440, 1326, 477, 1300, 483, 1301, 495" },
            new HouseMap { HouseNumber = "36", IMCoords="1280, 529, 1260, 500, 1299, 496, 1304, 503, 1302, 484, 1326, 477, 1326, 442, 1422, 419, 1432, 415, 1454, 473, 1546, 465, 1549, 488, 1455, 495, 1438, 440, 1347, 467, 1346, 499, 1322, 509, 1322, 520" },
            new HouseMap { HouseNumber = "35", IMCoords="1553, 517, 1550, 489, 1482, 497, 1468, 498, 1453, 439, 1358, 454, 1346, 469, 1345, 501, 1322, 510, 1321, 522, 1282, 529, 1305, 563, 1340, 557, 1339, 536, 1366, 533, 1366, 496, 1464, 479, 1477, 529" },
            new HouseMap { HouseNumber = "34", IMCoords="1566, 592, 1554, 520, 1490, 529, 1476, 466, 1376, 481, 1364, 497, 1364, 529, 1366, 534, 1340, 538, 1341, 559, 1306, 565, 1339, 614, 1394, 635, 1432, 634, 1429, 604, 1568, 607" },
            new HouseMap { HouseNumber = "23", IMCoords="897, 465, 887, 415, 997, 410, 994, 374, 1094, 369, 1101, 401, 1147, 399, 1159, 449, 1135, 452, 1003, 470, 983, 477, 978, 465" },
            new HouseMap { HouseNumber = "22", IMCoords="898, 468, 979, 469, 982, 475, 1005, 471, 999, 417, 1104, 408, 1110, 443, 1132, 442, 1136, 453, 1160, 450, 1174, 495, 1016, 514, 985, 525, 908, 514" },
            new HouseMap { HouseNumber = "21", IMCoords="1011, 586, 1053, 576, 1048, 537, 1058, 521, 1152, 505, 1166, 502, 1178, 549, 1208, 545, 1174, 495, 1149, 498, 1136, 457, 1033, 479, 1027, 491, 1028, 511, 1011, 513, 986, 526, 988, 532" },
            new HouseMap { HouseNumber = "20", IMCoords="1049, 666, 1173, 651, 1167, 633, 1213, 631, 1242, 608, 1209, 547, 1178, 550, 1166, 504, 1060, 523, 1051, 538, 1056, 579, 1032, 583, 1011, 586" },
            new HouseMap { HouseNumber = "15", IMCoords="955, 680, 944, 651, 939, 625, 934, 581, 915, 537, 946, 503, 982, 529, 989, 533, 1046, 669" },
            new HouseMap { HouseNumber = "6", IMCoords="106, 819, 56, 803, 41, 710, 126, 674, 128, 649, 151, 611, 161, 609, 204, 641, 201, 691, 211, 734, 213, 751, 220, 763, 216, 778, 222, 796" },
            new HouseMap { HouseNumber = "7", IMCoords="203, 639, 230, 599, 240, 599, 281, 629, 280, 680, 291, 720, 293, 738, 298, 753, 299, 784, 223, 794, 215, 778, 219, 761, 213, 748, 211, 730, 202, 689" },
            new HouseMap { HouseNumber = "8", IMCoords="300, 784, 298, 751, 294, 737, 292, 718, 281, 678, 279, 629, 305, 588, 315, 587, 356, 615, 358, 667, 369, 706, 370, 723, 375, 742, 379, 770" },
            new HouseMap { HouseNumber = "9", IMCoords="355, 613, 379, 577, 391, 576, 433, 606, 437, 657, 446, 698, 448, 715, 450, 732, 455, 758, 380, 770, 376, 739, 371, 722, 370, 704, 359, 666" },
            new HouseMap { HouseNumber = "10", IMCoords="432, 603, 455, 568, 465, 566, 504, 595, 512, 648, 520, 687, 523, 704, 525, 718, 531, 748, 456, 758, 450, 730, 448, 714, 446, 695, 436, 655" },
            new HouseMap { HouseNumber = "11", IMCoords="503, 592, 529, 557, 538, 556, 576, 586, 585, 636, 594, 676, 599, 690, 602, 705, 609, 734, 533, 747, 526, 717, 524, 703, 521, 685, 513, 647" },
            new HouseMap { HouseNumber = "12", IMCoords="609, 733, 725, 717, 693, 585, 651, 589, 650, 574, 609, 546, 598, 547, 576, 585, 585, 635, 593, 674, 600, 690, 602, 704" },
            new HouseMap { HouseNumber = "1", IMCoords="460, 1354, 272, 1319, 132, 1240, 118, 1156, 126, 1146, 125, 1139, 160, 1103, 222, 1086, 248, 1043, 246, 1036, 260, 1032, 261, 1038, 312, 1054, 378, 1124, 393, 1178, 413, 1193, 520, 1293, 465, 1354" },
            new HouseMap { HouseNumber = "2", IMCoords="296, 1038, 324, 991, 324, 983, 335, 980, 338, 987, 386, 1003, 451, 1068, 467, 1121, 483, 1135, 581, 1226, 520, 1293, 413, 1191, 393, 1177, 377, 1123" },
            new HouseMap { HouseNumber = "3", IMCoords="633, 1169, 582, 1224, 483, 1133, 466, 1118, 450, 1066, 385, 1001, 410, 956, 411, 947, 420, 944, 424, 950, 470, 966, 536, 1029, 553, 1080, 637, 1157" },
            new HouseMap { HouseNumber = "4", IMCoords="640, 1155, 553, 1079, 535, 1025, 468, 963, 494, 921, 494, 913, 504, 909, 505, 917, 550, 931, 615, 989, 634, 1045, 654, 1065, 697, 1097" },
            new HouseMap { HouseNumber = "5", IMCoords="802, 951, 771, 928, 665, 902, 640, 911, 626, 899, 586, 883, 583, 876, 573, 880, 574, 888, 550, 929, 616, 987, 634, 1046, 655, 1065, 698, 1096, 811, 960" },
            new HouseMap { HouseNumber = "16", IMCoords="788, 739, 747, 762, 738, 795, 724, 865, 724, 878, 829, 907, 963, 915, 938, 821, 929, 759, 913, 701, 871, 675, 870, 670, 863, 673, 862, 679, 832, 713, 835, 745, 796, 749, 791, 739" },
            new HouseMap { HouseNumber = "17", IMCoords="920, 731, 952, 725, 949, 694, 982, 659, 980, 655, 990, 653, 991, 659, 1029, 683, 1049, 739, 1057, 801, 1063, 815, 1101, 904, 964, 914, 936, 820, 929, 758" },
            new HouseMap { HouseNumber = "18", IMCoords="1102, 904, 1220, 925, 1232, 921, 1179, 798, 1174, 784, 1169, 723, 1144, 667, 1107, 643, 1106, 637, 1096, 637, 1097, 644, 1068, 679, 1068, 697, 1061, 699, 1062, 710, 1041, 714, 1049, 737, 1057, 798, 1064, 813" },
            new HouseMap { HouseNumber = "19", IMCoords="1231, 920, 1410, 889, 1294, 666, 1266, 667, 1255, 651, 1221, 625, 1221, 619, 1210, 619, 1209, 628, 1182, 657, 1182, 679, 1170, 682, 1169, 691, 1156, 692, 1168, 721, 1172, 783, 1178, 798" },
            new HouseMap { HouseNumber = "13", IMCoords="889, 685, 879, 664, 877, 649, 872, 633, 867, 595, 849, 547, 810, 523, 781, 557, 782, 569, 748, 582, 779, 696, 782, 707, 890, 690" },
            new HouseMap { HouseNumber = "14", IMCoords="849, 548, 879, 514, 916, 539, 933, 585, 940, 626, 944, 652, 954, 680, 954, 683, 891, 693, 880, 664, 877, 649, 872, 633, 867, 594" },
          }},
        };

        List<House> houseData = House.GetHouseData();
        foreach (KeyValuePair<string, List<HouseMap>> view in data)
        {
          foreach (HouseMap map in view.Value)
          {
            map.ID = houseData.Find(x => x.HouseNumber == map.HouseNumber).ID;
          }
        }
      }

      return data;
    }

    public static string ImageNameToVariant(string fileName)
    {
      return imageToVariant[fileName];
    }
  }
}
