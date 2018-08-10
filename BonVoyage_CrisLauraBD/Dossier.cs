using System.Collections.Generic;

namespace BoVoyage_CrisLauraMetier
{
   
    public class Dossier
    {
        //private const string[] etats = new string[4] { "EN ATTENTE", "EN COURS", "REFUSEE", "ACEPTEE" };

        public Client Client { get; set; }
        public List<Accompagnant> Accompagnants { get; set; }
        public Voyage Voyage { get; set; }
        public string Etats { get; set; }
        public double PrixTotal{get;set;}
    }
}
