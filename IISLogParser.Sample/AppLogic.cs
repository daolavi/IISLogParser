using IISLogParser.Models;
using IISLogParser.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IISLogParser.Sample
{
    public class AppLogic
    {
        public void ExecuteTask(string[] args)
        {
            var reader = new Reader(File.OpenText("Data/iis.log"));
            var logRecords = reader.Read().ToList();
            while (true)
            {
                Console.WriteLine("1. Type : totalcount");
                Console.WriteLine("2. Type : average");
                Console.WriteLine("3. Type 'exit' to end");
                Console.WriteLine("----------------------");

                var input = Console.ReadLine().ToLower();
                if (input == "totalcount")
                {
                    TotalCount(logRecords);
                }
                else if (input == "average")
                {
                    Average(logRecords);
                }
                else if (input == "exit")
                {
                    break;
                }
            }
        }

        public void TotalCount(List<LogEvent> logRecords)
        {
            var groups = logRecords.GroupBy(x => x.ServerIpAddress);
            foreach (var group in groups)
            {
                var info = $"{group.Key} - Count : {group.Count()}";

                Console.WriteLine(info);
            }
            Console.WriteLine("----------------------");
        }

        public void Average(List<LogEvent> logRecords)
        {
            var count = logRecords.Count;
            var totalTimeTaken = logRecords.Sum(x => x.TimeTaken);
            var averageTimeTaken = totalTimeTaken / (double)count;
            Console.WriteLine($"Average TimeTaken : {averageTimeTaken}");

            Console.WriteLine("----------------------");
        }
    }
}
