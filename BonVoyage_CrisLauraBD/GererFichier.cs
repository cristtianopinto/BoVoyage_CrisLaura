using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BonVoyage_CrisLauraMetier
{
    class GererFichier
    {
        const string DirFileClient = "Clients.txt";
        const string Accompagnant = "Accompagnant.txt";
        const string Voyage = "Voyage.txt";//on va avoir les données de Destination
        const string Dossier = "Dossier.txt";
        const string Commercial = "Commercial.txt";
        //TRAVAILLER SUR LA ECRITURE ET LECTURE DE DOSSIER
        /// <summary>
        /// Methode pour gardes les donnez sur un file txt
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
                fileWriter.WriteLine("****************");
                
            }
            fileWriter.Close();

        }
        /// <summary>
        /// Methode pour gardes les donnez sur un fichier *.txt
        /// </summary>
        public static void RecupererFichier(List<Client> contacts)
        {
            StreamReader fileReader = new StreamReader(DirFile);
            string line;
            Contact c = new Contact();
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
                        case "email":
                            c.Email = iniLine[1];
                            break;
                        case "tele":
                            c.Telephone = iniLine[1];
                            break;
                        case "date":
                            //c.DateDeNaissance = DateTime.Parse(iniLine[1]);
                            c.DateDeNaissance = DateTime.Parse(iniLine[1]);
                            break;
                        case "CB":
                            //c.DateDeNaissance = DateTime.Parse(iniLine[1]);
                            c.Cqrte = DateTime.Parse(iniLine[1]);
                            break;
                    }
                }
                else if (line.Contains("***"))
                {
                    contacts.Add(c);
                    c = new Contact();//VER O QUANTO É CORRETO FAZER ISSO
                }
            }
            fileReader.Close();
        }
        /// <summary>
        /// Methode pour gardes les donnez sur un file txt
        /// </summary>
        public static void EcrireFichier(List<Dossier> dossiers)
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
                fileWriter.WriteLine("****************");

            }
            fileWriter.Close();

        }
        /// <summary>
        /// Methode pour gardes les donnez sur un fichier *.txt
        /// </summary>
        public static void RecupererFichier(List<Dossier> dossiers)
        {
            StreamReader fileReader = new StreamReader(DirFile);
            string line;
            Contact c = new Contact();
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
                        case "email":
                            c.Email = iniLine[1];
                            break;
                        case "tele":
                            c.Telephone = iniLine[1];
                            break;
                        case "date":
                            //c.DateDeNaissance = DateTime.Parse(iniLine[1]);
                            c.DateDeNaissance = DateTime.Parse(iniLine[1]);
                            break;
                        case "CB":
                            //c.DateDeNaissance = DateTime.Parse(iniLine[1]);
                            c.Cqrte = DateTime.Parse(iniLine[1]);
                            break;
                    }
                }
                else if (line.Contains("***"))
                {
                    contacts.Add(c);
                    c = new Contact();//VER O QUANTO É CORRETO FAZER ISSO
                }
            }
            fileReader.Close();
        }
    }
}
