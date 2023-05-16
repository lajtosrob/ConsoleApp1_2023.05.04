using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;
//using ConsoleApp1_2023._05._04;

// SELECT gyártó, COUNT(*) AS darabSzám, MAX(ár) AS maxÁr, AVG(ár) AS Átlag FROM termékek WHERE " $"kategória = '{kategoria}'GROUP BY gyártó;

Console.WriteLine("Kérem a kategóriát!");
string kategoria = Console.ReadLine();

MySqlConnection SQLkapcsolat = new MySqlConnection("server=127.0.0.1;port=3306;database=hardver;username=root;password=;");

string SQLselect = "SELECT gyártó, " +
    "COUNT(*) AS darabSzám, " +
    "MAX(ár) AS maxÁr, " +
    "AVG(ár) AS Átlag " +
    "FROM termékek WHERE " +
    $"kategória = '{kategoria}'" +
    "GROUP BY gyártó;";

MySqlCommand SQLparancs = new MySqlCommand(SQLselect, SQLkapcsolat);
SQLkapcsolat.Open();

MySqlDataReader dataReader = SQLparancs.ExecuteReader();

while (dataReader.Read())
{
    Console.Write(dataReader.GetString("gyártó").PadRight(10, '.'));
    Console.Write(dataReader.GetString("darabSzám").PadLeft(3, ' ') + "db");
    Console.Write(dataReader.GetString("maxÁr").PadLeft(10, ' ') + "Ft");
    string atlagAr = $"{dataReader.GetDouble("Átlag"):f0}";
    Console.WriteLine(atlagAr.PadLeft(10) + "Ft");
}
