using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage_CrisLauraMetier
{
    public class Program
    {
        public static List<Voyage> voyage_agence = new List<Voyage>();
        public static List<Voyage> voyage_site = new List<Voyage>();
        public static List<Accompagnant> accompagnant = new List<Accompagnant>();
        public static List<Commercial> commercial = new List<Commercial>();
        public static List<Client> clients = new List<Client>();
        static void Main(string[] args)
        {
            //TEST LECTURE DE FICHIER
            Console.WriteLine("Commercial!");
            Console.WriteLine("Clients");
            GererFichier.RecupererFichier(clients);
            foreach (Client c in clients)
            {
                Console.WriteLine(c.Nom);
            }
            Console.WriteLine("Voyage");

            GererFichier.RecupererFichier(voyage_agence);
            foreach (Voyage v in voyage_agence)
            {
                Console.WriteLine(v.Destination.Pays);
            }
            Console.WriteLine("Accompagnants");
            GererFichier.RecupererFichier(accompagnant);
            foreach (Accompagnant a in accompagnant)
            {
                Console.WriteLine(a.Nom);
            }
            Console.WriteLine("Commercial");
            GererFichier.RecupererFichier(commercial);
            foreach (Commercial c in commercial)
            {
                Console.WriteLine(c.Nom);
            }
            Console.ReadKey();
            //FIN: TEST LECTURE DE FICHIER
        }
    }
}
