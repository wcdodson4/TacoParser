using System;

namespace LoggingKata
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            if (line == null || line == "")
                return null;
            
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                logger.LogInfo("Array is less than length 3");
                return null; 
            }

            if (cells.Length > 3)
            {
                logger.LogInfo("Array is greater than length 3");
                return null;
            }

            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var name = cells[2];

            var newTBell = new TacoBell();
            newTBell.Name = name;
            newTBell.Location = new Point(longitude, latitude);
            
            return newTBell;
        }
    }
}