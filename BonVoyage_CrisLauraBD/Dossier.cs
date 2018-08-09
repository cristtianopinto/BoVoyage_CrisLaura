using System.Collections.Generic;

namespace BoVoyage_CrisLauraMetier
{
    public class Dossier
    {
        public Client Client { get; set; }
        public List<Accompagnant> Accompagnants { get; set; }
        public Voyage Voyage { get; set; }
        public string[] etats = new string[4] {"EN ATTENTE","EN COURS","REFUSEE","ACEPTEE"};
        public double PrixTotal{get;set;}
    }
}
