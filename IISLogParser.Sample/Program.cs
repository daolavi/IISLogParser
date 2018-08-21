using System;

namespace IISLogParser.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var appLogic = new AppLogic();
            appLogic.ExecuteTask(args);
        }
    }
}
