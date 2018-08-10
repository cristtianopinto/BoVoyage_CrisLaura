using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage_CrisLauraMetier
{
    /// <summary>
    /// Class responsqble pour creer est lire tous les fichier
    /// </summary>
    public static class GererFichier
    {
        private const string DirFileClient = @"..\..\FICHIER\Clients.txt";
        private const string DirFileAccompagnant = @"..\..\FICHIER\Accompagnant.txt";
        public const string DirFileVoyageAgence = @"..\..\FICHIER\Voyage_agence.txt";//ICI on va avoir les données de Destination
        public const string DirFileVoyageSite = @"..\..\FICHIER\Voyage_site.txt";//ICI on va avoir les données de Destination
        private const string DirFileDossier = @"..\..\FICHIER\Dossier.txt";
        private const string DirFileCommercial = @"..\..\FICHIER\Commercial.txt";

        /// <summary>
        /// Methode pour gardes les donnez sur un file txt en relation CLient
        /// </summary>
        public static void EcrireFichier(List<Client> clients)
        {     
            StreamWriter fileWriter = new StreamWriter(DirFileClient);
            foreach (Client c in clients)
            {

                fileWriter.WriteLine($"Client:");
                fileWriter.WriteLine("nom-" + c.Nom);
                fileWriter.WriteLine("prenom-" + c.Prenom);
                fileWriter.WriteLine("civilite-" + c.Civilite);
                fileWriter.WriteLine("tele-" + c.Telephone);
                fileWriter.WriteLine("date-" + c.DateDeNaissance);
                fileWriter.WriteLine("CB-" + c.CarteBancaire);
                fileWriter.WriteLine("Id-" + c.Id);
                fileWriter.WriteLine("Login-" + c.Login);
                fileWriter.WriteLine("MotDePasse-" + c.MotDePasse);
                fileWriter.WriteLine("****************");
                
            }
            fileWriter.Close();

        }
        /// <summary>
        /// Methode pour gardes les donnez sur un fichier *.txt en relation CLient
        /// </summary>
        public static void RecupererFichier(List<Client> clients)
        {
            StreamReader fileReader = new StreamReader(DirFileClient);
            string line;
            Client c = new Client();   
            while ((line = fileReader.ReadLine()) != null)
            {
                if (line.Contains("-"))
                {
                    string[] iniLine = line.Split('-');
                    switch (iniLine[0])
                    {
                        case "nom":
                            c.Nom = iniLine[1];
                            break;
                        case "prenom":
                            c.Prenom = iniLine[1];
                            break;
                        case "civilite":
                            c.Civilite = iniLine[1];
                            break;
                        case "tele":
                            c.Telephone = iniLine[1];
                            break;
                        case "date":                            
                            c.DateDeNaissance = DateTime.Parse(iniLine[1]);
                            break;
                        case "CB":
                            c.CarteBancaire = iniLine[1];
                            break;
                        case "Id":
                            c.Id = int.Parse(iniLine[1]);
                            break;
                        case "Login":
                            c.Login = iniLine[1];
                            break;
                        case "MotDePasse":
                            c.MotDePasse = iniLine[1];
                            break;
                    }
                }
                else if (line.Contains("***"))
                {
                    clients.Add(c);
                    c = new Client();
                }
            }
            fileReader.Close();
        }

        /// <summary>
        /// Methode pour gardes les donnez sur un file txt en relation Accompagnants
        /// </summary>
        public static void EcrireFichier(List<Accompagnant> Accompagnants)
        {
            StreamWriter fileWriter = new StreamWriter(DirFileAccompagnant);
            foreach (Accompagnant a in Accompagnants)
            {

                fileWriter.WriteLine($"Accompagnants:");
                fileWriter.WriteLine("nom-" + a.Nom);
                fileWriter.WriteLine("prenom-" + a.Prenom);
                fileWriter.WriteLine("civilite-" + a.Civilite);
                fileWriter.WriteLine("tele-" + a.Telephone);
                fileWriter.WriteLine("date-" + a.DateDeNaissance);
                fileWriter.WriteLine("Id-" + a.Id);
                fileWriter.WriteLine("****************");

            }
            fileWriter.Close();

        }
        /// <summary>
        /// Methode pour gardes les donnez sur un fichier *.txt en relation Accompagnants
        /// </summary>
        public static void RecupererFichier(List<Accompagnant> Accompagnants)
        {
            StreamReader fileReader = new StreamReader(DirFileAccompagnant);
            string line;
            Accompagnant c = new Accompagnant();
            while ((line = fileReader.ReadLine()) != null)
            {
                if (line.Contains("-"))
                {
                    string[] iniLine = line.Split('-');
                    switch (iniLine[0])
                    {
                        case "nom":
                            c.Nom = iniLine[1];
                            break;
                        case "prenom":
                            c.Prenom = iniLine[1];
                            break;
                        case "civilite":
                            c.Civilite = iniLine[1];
                            break;
                        case "tele":
                            c.Telephone = iniLine[1];
                            break;
                        case "date":
                            c.DateDeNaissance = DateTime.Parse(iniLine[1]);
                            break;                        
                        case "Id":
                            c.Id = int.Parse(iniLine[1]);
                            break;                        
                    }
                }
                else if (line.Contains("***"))
                {
                    Accompagnants.Add(c);
                    c = new Accompagnant();
                }
            }
            fileReader.Close();
        }

        /// <summary>
        /// Methode pour gardes les donnez sur un file txt en relation Voyage
        /// </summary>
        public static void EcrireFichier(List<Voyage> Voyages,string dir)
        {
            StreamWriter fileWriter = new StreamWriter(dir);
            foreach (Voyage v in Voyages)
            {

                fileWriter.WriteLine($"Voyages:");
                //
                fileWriter.WriteLine("Identifient-" + v.Id);
                fileWriter.WriteLine("Continent-" + v.Destination.Continent);
                fileWriter.WriteLine("Pays-" + v.Destination.Pays);
                fileWriter.WriteLine("Region-" + v.Destination.Region);
                fileWriter.WriteLine("Description-" + v.Destination.Description);
                fileWriter.WriteLine("Prix-" + v.Prix);
                fileWriter.WriteLine("DateAller-" + v.DateAller);
                fileWriter.WriteLine("DateRetour-" + v.DateRetour);
                fileWriter.WriteLine("NombrePlace-" + v.NombrePlace);
                //
                fileWriter.WriteLine("****************");

            }
            fileWriter.Close();

        }
        /// <summary>
        /// Methode pour gardes les donnez sur un fichier *.txt en relation Voyage
        /// </summary>
        public static void RecupererFichier(List<Voyage> Voyages, string dir)
        {
            StreamReader fileReader = new StreamReader(dir);
            string line;
            Voyage v = new Voyage();
            Destination d = new Destination();
            while ((line = fileReader.ReadLine()) != null)
            {
                if (line.Contains("-"))
                {
                    string[] iniLine = line.Split('-');
                    switch (iniLine[0])
                    {
                        case "Identifient":
                            v.Id = int.Parse(iniLine[1]);
                            break;
                        case "Continent":
                            d.Continent = iniLine[1];
                            break;
                        case "Pays":
                            d.Pays =  iniLine[1];
                            break;
                        case "Region":
                            d.Region =  iniLine[1];
                            break;
                        case "Description":
                            d.Description =  iniLine[1];
                            break;
                        case "Prix":
                            v.Prix = double.Parse(iniLine[1]);
                            break;
                        case "DateAller":
                            v.DateAller = DateTime.Parse(iniLine[1]);
                            break;
                        case "DateRetour":
                            v.DateRetour = DateTime.Parse(iniLine[1]);
                            break;
                        case "NombrePlace":
                            v.NombrePlace = int.Parse(iniLine[1]);
                            break;
                    }
                }
                else if (line.Contains("***"))
                {
                    v.Destination = d;
                    Voyages.Add(v);
                    v = new Voyage();
                    d = new Destination();
                }
            }
            fileReader.Close();
        }

        /// <summary>
        /// Methode pour gardes les donnez sur un file txt en relation CLient
        /// </summary>
        public static void EcrireFichier(List<Commercial> commercial)
        {
            StreamWriter fileWriter = new StreamWriter(DirFileCommercial);
            foreach (Commercial c in commercial)
            {

                fileWriter.WriteLine($"Client:");
                fileWriter.WriteLine("nom-" + c.Nom);
                fileWriter.WriteLine("prenom-" + c.Prenom);
                fileWriter.WriteLine("civilite-" + c.Civilite);
                fileWriter.WriteLine("tele-" + c.Telephone);
                fileWriter.WriteLine("date-" + c.DateDeNaissance);                
                fileWriter.WriteLine("Login-" + c.Login);
                fileWriter.WriteLine("MotDePasse-" + c.MotDePasse);
                fileWriter.WriteLine("****************");

            }
            fileWriter.Close();

        }
        /// <summary>
        /// Methode pour gardes les donnez sur un fichier *.txt en relation CLient
        /// </summary>
        public static void RecupererFichier(List<Commercial> commercial)
        {
            StreamReader fileReader = new StreamReader(DirFileCommercial);
            string line;
            Commercial c = new Commercial();
            while ((line = fileReader.ReadLine()) != null)
            {
                if (line.Contains("-"))
                {
                    string[] iniLine = line.Split('-');
                    switch (iniLine[0])
                    {
                        case "nom":
                            c.Nom = iniLine[1];
                            break;
                        case "prenom":
                            c.Prenom = iniLine[1];
                            break;
                        case "civilite":
                            c.Civilite = iniLine[1];
                            break;
                        case "tele":
                            c.Telephone = iniLine[1];
                            break;
                        case "date":
                            c.DateDeNaissance = DateTime.Parse(iniLine[1]);
                            break;                        
                        case "Login":
                            c.Login = iniLine[1];
                            break;
                        case "MotDePasse":
                            c.MotDePasse = iniLine[1];
                            break;
                    }
                }
                else if (line.Contains("***"))
                {
                    commercial.Add(c);
                    c = new Commercial();
                }
            }
            fileReader.Close();
        }

        //problem avec les acompagnants du Dossier. Comment les enregistrer dans le fichier?
        /*
        /// <summary>
        /// Methode pour gardes les donnez sur un file txt en relation Dossier
        /// </summary>
        public static void EcrireFichier(List<Dossier> Dossiers)
        {
            StreamWriter fileWriter = new StreamWriter(DirFileDossier);
            foreach (Dossier v in Dossiers)
            {

                fileWriter.WriteLine($"Voyages:");
                //
                fileWriter.WriteLine("Continent-" + v.Destination.Continent);
                fileWriter.WriteLine("Pays-" + v.Destination.Pays);
                fileWriter.WriteLine("Region-" + v.Destination.Region);
                fileWriter.WriteLine("Description-" + v.Destination.Description);
                fileWriter.WriteLine("Prix-" + v.Prix);
                fileWriter.WriteLine("DateAller-" + v.DateAller);
                fileWriter.WriteLine("DateRetour-" + v.DateRetour);
                fileWriter.WriteLine("NombrePlace-" + v.NombrePlace);
                //
                fileWriter.WriteLine("****************");

            }
            fileWriter.Close();

        }
        /// <summary>
        /// Methode pour gardes les donnez sur un fichier *.txt en relation Dossier
        /// </summary>
        public static void RecupererFichier(List<Dossier> Dossiers)
        {
            StreamReader fileReader = new StreamReader(DirFileVoyage);
            string line;
            Dossier v = new Dossier();
            while ((line = fileReader.ReadLine()) != null)
            {
                if (line.Contains("-"))
                {
                    string[] iniLine = line.Split('-');
                    switch (iniLine[0])
                    {
                        case "Continent":
                            v.Destination.Continent = iniLine[1];
                            break;
                        case "Pays":
                            v.Destination.Pays = iniLine[1];
                            break;
                        case "Region":
                            v.Destination.Region = iniLine[1];
                            break;
                        case "Description":
                            v.Destination.Description = iniLine[1];
                            break;
                        case "Prix":
                            v.Prix = double.Parse(iniLine[1]);
                            break;
                        case "DateAller":
                            v.DateAller = DateTime.Parse(iniLine[1]);
                            break;
                        case "DateRetour":
                            v.DateRetour = DateTime.Parse(iniLine[1]);
                            break;
                        case "NombrePlace":
                            v.NombrePlace = int.Parse(iniLine[1]);
                            break;
                    }
                }
                else if (line.Contains("***"))
                {
                    Dossiers.Add(v);
                    v = new Dossier();
                }
            }
            fileReader.Close();
        }*/

    }
}
