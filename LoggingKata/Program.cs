using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogError("Zero lines", new NullReferenceException());
            }

            if (lines.Length == 1)
            {
                logger.LogWarning("You are only entering one line.");
            }

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();

            var A = new TacoBell();
            var B = new TacoBell();
            A = null;
            B = null;
            
            double distance = 0;

            logger.LogInfo("Finding the distances between any two Taco Bell locations, and returning the greatest distance to find which" +
                " two Taco Bell locations are the farthest from each other.");
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                for(int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    var testDistance = corA.GetDistanceTo(corB);
                    if (testDistance > distance)
                    {
                        distance = testDistance;
                        A = (TacoBell)locA;
                        B = (TacoBell)locB;
                    }
                }
            }
            Console.WriteLine($"The two Taco Bells farthest away from each other are {A.Name} and {B.Name}, which are" +
                $" {Math.Round((distance * 0.0006213710), 1)} miles apart from each other.");
        }
    }
}