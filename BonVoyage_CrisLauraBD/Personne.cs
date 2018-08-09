using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage_CrisLauraMetier
{
    public class Personne
    {
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Adresse Adresse { get; set; }
        public string Telephone { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public int Age()
        {
            //A FAIRE!
            return 0;
            
        }
    }

}
