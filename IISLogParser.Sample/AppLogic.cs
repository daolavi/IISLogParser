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
            var logEvents = reader.Read().ToList();
            while (true)
            {
                Console.WriteLine("1. Type : totalcount");
                Console.WriteLine("2. Type : average");
                Console.WriteLine("3. Type 'exit' to end");
                Console.WriteLine("----------------------");

                var input = Console.ReadLine().ToLower();
                if (input == "totalcount")
                {
                    TotalCount(logEvents);
                }
                else if (input == "average")
                {
                    Average(logEvents);
                }
                else if (input == "exit")
                {
                    break;
                }
            }
        }

        public void TotalCount(List<LogEvent> logEvents)
        {
            var groups = logEvents.GroupBy(x => x.ServerIpAddress);
            foreach (var group in groups)
            {
                var info = $"{group.Key} - Count : {group.Count()}";

                Console.WriteLine(info);
            }
            Console.WriteLine("----------------------");
        }

        public void Average(List<LogEvent> logEvents)
        {
            var count = logEvents.Count;
            var totalTimeTaken = logEvents.Sum(x => x.TimeTaken);
            var averageTimeTaken = totalTimeTaken / (double)count;
            Console.WriteLine($"Average TimeTaken : {averageTimeTaken}");

            Console.WriteLine("----------------------");
        }
    }
}
