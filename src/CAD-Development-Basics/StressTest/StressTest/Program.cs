using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Core;
using Kompas;
using Microsoft.VisualBasic.Devices;

namespace StressTest
{
    class Program
    {
        static void Main()
        {
            var parameters = new Parameters();
            parameters.HeightBody = 350;
            parameters.HeightEdge = 110;
            parameters.DiameterArea = 600;
            parameters.DiameterBoltHeadHoles = 72;
            parameters.DiameterBoltThreadHoles = 34;

            
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var streamWriter = new StreamWriter("log.txt", true);
            var count = 0;

            while (true)
            {
                var builder = new Builder(parameters);
                builder.BuildModel();
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory -
                                  computerInfo.AvailablePhysicalMemory) / Math.Pow(1024, 3);
                streamWriter.WriteLine(
                    $"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
                streamWriter.Flush();
            }
        }
    }
}
