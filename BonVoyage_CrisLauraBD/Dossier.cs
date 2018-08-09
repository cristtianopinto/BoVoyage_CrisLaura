using System.Collections.Generic;

namespace BonVoyage_CrisLauraMetier
{
    public class Dossier
    {
        public Client Client { get; set; }
        public List<Accompagnant> Accompagnants { get; set; }
        public Voyage Voyage { get; set; }
    }
}
