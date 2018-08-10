using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BoVoyage_CrisLauraMetier;

namespace BoVoyage_CrisLaura_Commercial
{
    class Program
    {
        public static List<Voyage> voyage_agence = new List<Voyage>();
        public static List<Voyage> voyage_site = new List<Voyage>();
        public static List<Accompagnant> accompagnant = new List<Accompagnant>();
        public static List<Commercial> commercial = new List<Commercial>();
        public static List<Client> clients = new List<Client>();
        static Commercial CommercialUser = new Commercial();
        //public static List<Dossier> dossier = new List<Dossier>();

        private static void PrintSingleVoyage(Voyage voyage)
        {
            Console.WriteLine($" Identifient: {voyage.Id}\n" +
                              $" Continent: {voyage.Destination.Continent}\n" +
                              $" PAYS: {voyage.Destination.Pays}\n" +
                              $" Region: {voyage.Destination.Region}\n" +
                              $" Date Aller: {voyage.DateAller.ToString()}\n" +
                              $" Date Retour: {voyage.DateRetour.ToString()}\n" +
                              $" Place Disponible: {voyage.NombrePlace}\n" +
                              $" Prix: {voyage.Prix}\n" +
                              $" Description: {voyage.Destination.Description}\n" +
                              $" ═════════════════════\n");
        }
        static void ListerVoyage(List<Voyage> voyages, int option)
        {
            Console.Clear();
            int consoleWidth = Console.WindowWidth;
            if(option== 1)
            {
                OutilsConsole.PrintMenu("Liste voyage - AGENCE", "Lister");
            }
            else if(option == 2)
            {
                OutilsConsole.PrintMenu("Liste voyage - SITE", "Lister");
            }
            
            Console.WriteLine("\t[Vous avez {0} voyages]", voyages.Count);            
            for (int i = 0; i <= voyages.Count - 1; i++)
            {
                PrintSingleVoyage(voyages[i]);
            }
            Console.ReadKey();
        }

        private static void PrintSingleClient(Client client)
        {
            Console.WriteLine($" Identifiant: {client.Id}\n" +
                              $" Nom: {client.Nom}\n" +
                              $" Prenom: {client.Prenom}\n" +
                              $" Adresse: {client.Adresse}\n" +
                              $" CarteBancaire {client.CarteBancaire}\n" +

                              $" ═════════════════════\n");
        }

        static void ListerClient(List<Client> client)
        {
            Console.Clear();
           
                OutilsConsole.PrintMenu("Liste des clients", "Lister");
            

            Console.WriteLine("\t[Vous avez {0} clients]", client.Count);
            for (int i = 0; i <= client.Count - 1; i++)
            {
                PrintSingleClient(client[i]);
            }
            Console.ReadKey();
        }

        static void GererClient()
        {
            bool sortir = false;
            List<string> MenuOption = new List<string>();
            MenuOption.Add("[1] Gerer Dossier");
            MenuOption.Add("[2] Consulter la Liste des Clients");
            MenuOption.Add("[3] Sortir");

            while (!sortir)
            {
                OutilsConsole.PrintMenu("Gerer Client", "Add");
                //Console.WriteLine($"Bienvenue! {CommercialUser.Nom},{CommercialUser.Prenom} ");
                OutilsConsole.AfficherOpction(MenuOption);
                int op = OutilsConsole.SaisirEntierObligatoire("Tapez l'option:", "SVP un nombre!");

                switch (op)
                {
                    case 1:
                        Console.ReadKey();
                        break;
                    case 2:
                        ListerClient(clients);
                        Console.ReadKey();
                        break;
                    case 3:
                        sortir = true;
                        //Console.WriteLine($"Bye Bye! {CommercialUser.Nom},{CommercialUser.Prenom} ");
                        
                        break;
                    default:
                        OutilsConsole.Visual("Danger");
                        Console.WriteLine("Option invalide!");
                        OutilsConsole.Visual("Normal");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void GererVoyage()
        {
            bool sortir = false;
            List<string> MenuOption = new List<string>();
            MenuOption.Add("[1] Consulter la liste des voyages invendus par les AGENCE");
            MenuOption.Add("[2] Consulter la Liste des voyages de BoVoyage");
            MenuOption.Add("[3] Changer prix des voyages");
            MenuOption.Add("[4] Sortir");

            while (!sortir)
            {
                OutilsConsole.PrintMenu("Gerer Voyage", "Add");
                //Console.WriteLine($"Bienvenue! {CommercialUser.Nom},{CommercialUser.Prenom} ");
                OutilsConsole.AfficherOpction(MenuOption);
                int op = OutilsConsole.SaisirEntierObligatoire("Tapez l'option:", "SVP un nombre!");

                switch (op)
                {
                    case 1:
                        ListerVoyage(voyage_agence,1);                        
                        break;
                    case 2:
                        ListerVoyage(voyage_site,2);
                        
                        break;
                    case 3:
                        
                        //Console.WriteLine($"Bye Bye! {CommercialUser.Nom},{CommercialUser.Prenom} ");
                        Console.ReadKey();
                        break;
                    case 4:
                        sortir = true;
                        //Console.WriteLine($"Bye Bye! {CommercialUser.Nom},{CommercialUser.Prenom} ");
                        
                        break;
                    default:
                        OutilsConsole.Visual("Danger");
                        Console.WriteLine("Option invalide!");
                        OutilsConsole.Visual("Normal");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void LancerApplication()
        {
            Console.Title = "BoVoyage";            
            Console.SetWindowSize(Console.LargestWindowWidth/2, Console.LargestWindowHeight/2);
            GererFichier.RecupererFichier(clients);
            GererFichier.RecupererFichier(voyage_agence,GererFichier.DirFileVoyageAgence);
            GererFichier.RecupererFichier(voyage_site,GererFichier.DirFileVoyageSite);
            GererFichier.RecupererFichier(accompagnant);            
            OutilsConsole.Visual("Normal");
        }
        static void Quitter()
        {
            GererFichier.EcrireFichier(clients);
            Environment.Exit(0);
        }
        static void Login()
        {
            OutilsConsole.Visual("Normal");
            
            bool sortir = false;
            OutilsConsole.PrintMenu("BoVoyage", "Add");
            string LoginUser;
            string MotDePasseUser;            
            GererFichier.RecupererFichier(commercial);
            while (!sortir)
            {
                LoginUser = OutilsConsole.SaisirChaineObligatoire("\nLogin(valeur - yann)", "Champs Obligatoire!");
                MotDePasseUser = OutilsConsole.SaisirChaineObligatoire("\nMot de Passe(valeur - abc)", "Champs Obligatoire!");
                
                foreach(Commercial c in commercial)
                {
                    if (c.Login == LoginUser && c.MotDePasse == MotDePasseUser)
                    {
                        CommercialUser = c;
                        OutilsConsole.Visual("Lister");
                        Console.WriteLine("Login Validé!");
                        OutilsConsole.Visual("Normal");
                        Console.ReadKey();
                        sortir = true;
                    }                    
                }
                if (!sortir)
                {
                    OutilsConsole.Visual("Danger");
                    Console.WriteLine("Login ou Mot de passe Invalide!");
                    OutilsConsole.Visual("Normal");
                    Console.ReadKey();
                    Console.Clear();
                    OutilsConsole.PrintMenu("BoVoyage", "Add");
                }
                
            }
            
            
            
        }
        static void Main(string[] args)
        {
            Login();
            LancerApplication();
            
            bool  sortir = false;            
            List<string> MenuOption = new List<string>();            
            MenuOption.Add("[1] Gerer Voyages");
            MenuOption.Add("[2] Gerer Client");
            MenuOption.Add("[3] Sortir");

            while (!sortir)
            {
                OutilsConsole.PrintMenu("Menu", "Add");
                Console.WriteLine($"Bienvenue! {CommercialUser.Nom},{CommercialUser.Prenom} ");
                OutilsConsole.AfficherOpction(MenuOption);
                int op = OutilsConsole.SaisirEntierObligatoire("Tapez l'option:", "SVP un nombre!");
                switch (op)
                {
                    case 1:
                        GererVoyage();                        
                        break;
                    case 2:
                        GererClient();
                        break;
                    case 3:
                        sortir = true;
                        Console.WriteLine($"Bye Bye! {CommercialUser.Nom},{CommercialUser.Prenom} ");
                        Console.ReadKey();
                        break;
                    default:
                        OutilsConsole.Visual("Danger");
                        Console.WriteLine("Option invalide!");
                        OutilsConsole.Visual("Normal");
                        Console.ReadKey();
                        break;
                }
            }
            
        }
    }
}
