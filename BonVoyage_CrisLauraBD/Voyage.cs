using System;

namespace BoVoyage_CrisLauraMetier
{
    public class Voyage 
    {
        public int Id { get; set; }//A cause du fichier je besoin d'un Id
        public Destination Destination { get; set; }
        public double Prix { get; set; }
        public DateTime DateAller { get; set; }
        public DateTime DateRetour { get; set; }
        public int NombrePlace { get; set; }
    }
}
