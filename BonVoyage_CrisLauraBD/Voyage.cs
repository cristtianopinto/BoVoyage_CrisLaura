using System;

namespace BonVoyage_CrisLauraMetier
{
    public class Voyage 
    {
        public Destination Destination { get; set; }
        public double Prix { get; set; }
        public DateTime DateAller { get; set; }
        public DateTime DateRetour { get; set; }
    }
}
