using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarSales.VehicleManagement.ReportGenerator.Factories;
using CarSales.VehicleManagement.ReportGenerator.Models;
using RestSharp;

namespace CarSales.VehicleManagement.Report
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to generate report");
            Console.ReadKey();

            Console.WriteLine("Generating report please wait...");

            var skip = 0;
            var pageSize = 10;

            var client = ApiClientFactory.Create();
            var stopLoop = false;

            var currentDir = Directory.GetCurrentDirectory();
            var reportPath = currentDir + $"/Reports/report-{Guid.NewGuid()}.txt";
            Directory.CreateDirectory(currentDir + "/Reports");

            using (StreamWriter streamWritter = File.CreateText(reportPath))
            {
                do
                {
                    var request = new RestRequest(Method.GET);
                    request.AddQueryParameter("PageSize", pageSize.ToString());
                    request.AddQueryParameter("Skip", skip.ToString());

                    request.Resource = "/api/vehicle/list";

                    var result = client.Execute<IEnumerable<Car>>(request).Data;

                    foreach (var car in result)
                    {
                        foreach (var prop in car.GetType().GetProperties())
                        {
                            var value = prop.GetValue(car)?.ToString();

                            streamWritter.WriteLine(prop.Name + $": {value}");
                        }
                        streamWritter.WriteLine("----------------------------------------------------");
                        streamWritter.WriteLine("");
                    }


                    if (!result.Any())
                    {
                        stopLoop = true;
                    }

                    skip++;

                } while (!stopLoop);
            }

        }
    }
}
