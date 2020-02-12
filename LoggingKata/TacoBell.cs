using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public TacoBell()
        {

        }
        public string Name 
        {
            get
            {
                return Name;
            }  
            set
            {
                value = Name;
            }
        }
        public Point Location
        {
            get
            {
                return Location;
            }   
            set
            {
                value = Location;
            }
        }
    }
}
