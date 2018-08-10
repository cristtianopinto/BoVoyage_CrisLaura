using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage_CrisLaura_Commercial
{
    class OutilsConsole
    {
        /// <summary>
        /// Methode responsqble pour masquer le mot de passe. Font - https://social.msdn.microsoft.com/Forums/vstudio/fr-FR/55e423d6-7917-4e7d-822d-ce1adcd547c6/comment-masquer-les-caractres-de-mot-de-passe-dans-la-console-lors-de-la-saisie-?forum=visualcsharpfr
        /// </summary>
        /// <returns></returns>
        public static string MaskPassword()
        {
            Stack<char> stack = new Stack<char>();
            ConsoleKeyInfo consoleKeyInfo;

            // push until the enter key is pressed
            while ((consoleKeyInfo = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                if (consoleKeyInfo.Key != ConsoleKey.Backspace)
                {
                    stack.Push(consoleKeyInfo.KeyChar);
                    Console.Write("*");
                }
                else
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    if (stack.Count > 0) stack.Pop();
                }
            }

            return stack.Reverse().Aggregate(string.Empty, (pass, kc) => pass += kc.ToString());
        }
        /// <summary>
        /// Methode qui retourne zero em cas de mauveise entrer(letre ou cqrqctere speciaux)
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static int SaisirEntier(string Message)
        {
            Console.WriteLine(Message);
            int i;
            bool ok = int.TryParse(Console.ReadLine(), out i);
            if (!ok)
            {
                return 0;
            }
            return i;
        }
        /// <summary>
        /// methode qui oblige le saisie d'un entier
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="MessageOblige"></param>
        /// <returns></returns>
        public static int SaisirEntierObligatoire(string Message, string MessageOblige)
        {
            Console.WriteLine(Message);
            int i;
            bool ok = int.TryParse(Console.ReadLine(), out i);
            while (!ok)
            {
                Console.WriteLine(MessageOblige);
                ok = int.TryParse(Console.ReadLine(), out i);
            }
            return i;
        }
        public static DateTime ConvertirData(string chaine, out bool booldata)
        {
            DateTime date_valuer = new DateTime();
            booldata = DateTime.TryParse(chaine, out date_valuer);
            return date_valuer;
        }
        /// <summary>
        /// Methode qui récupère la saisie d'une date.
        /// </summary>
        /// <param name="message">Message à afficher sur la console</param>
        /// <returns>Renvoie la saisie convertie en date si possible,si pas possible return null.</returns>
        public static DateTime? SaisirDate(string message,string MessageInvalide)
        {
            Console.WriteLine(message);
            string saisie = Console.ReadLine();

            DateTime date = default(DateTime);
            while (!string.IsNullOrEmpty(saisie)
                    && !DateTime.TryParse(saisie, out date))
            {
                Console.WriteLine(MessageInvalide);
                saisie = Console.ReadLine();
            }

            return string.IsNullOrEmpty(saisie)
                    ? (DateTime?)null
                    : date;
        }
        /// <summary>
        /// Methode qui récupère la saisie d'une date Obligqtoire.
        /// </summary>
        /// <param name="message">Message à afficher sur la console</param>
        /// <returns>Renvoie la saisie convertie en date si possible,si pas possible return null.</returns>
        public static DateTime SaisierDataObligatoire(string Message, string MessageOblige)
        {
            bool saisiValide;
            Console.WriteLine(Message);
            DateTime date = ConvertirData(Console.ReadLine(), out saisiValide);
            while (!saisiValide)
            {
                Console.WriteLine(MessageOblige);
                date = ConvertirData(Console.ReadLine(), out saisiValide);
            }
            return date;
        }
        public static string SaisirChaine(string Message)
        {
            Console.WriteLine(Message);
            string saisie = Console.ReadLine();            
            return saisie;
        }
        public static string SaisirChaineObligatoire(string Message, string MessageOblige)
        {
            Console.WriteLine(Message);
            string saisie = Console.ReadLine();
            while (string.IsNullOrEmpty(saisie))
            {
                Visual("Danger");
                Console.WriteLine(MessageOblige);
                Visual("normal");
                saisie = Console.ReadLine();
            }
            return saisie;
        }
        /// <summary>
        /// méthode qui choisit un visuel specifique pour l'application
        /// </summary>
        /// <param name="Type"></param>
        public static void Visual(string Type)
        {
            switch (Type)
            {
                case "Normal":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "Danger":
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "Add":
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "Lister":
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "EnTete":
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            };
        }
        /// <summary>
        /// Affiche menu de l'application
        /// </summary>
        /// <param name="Tittle"></param>
        /// <param name="Type"></param>
        public static void PrintMenu(string Tittle, string Type)
        {
            Console.Clear();
            char[] chars = { '█', '▓', '▒', '░' };
            Visual(Type);
            Console.Write(new string(chars[2], Console.WindowWidth));
            Console.Write(new string('-', Console.WindowWidth));
            Console.Write(new string(' ', Console.WindowWidth / 2 -(Tittle.Length%2==0?Tittle.Length/2: (Tittle.Length / 2)-1)) +
                                    Tittle +
                                    new string(' ', Console.WindowWidth / 2 - (Tittle.Length % 2 == 0 ? Tittle.Length / 2 : (Tittle.Length / 2) - 1)));
            Console.Write(new string('-', Console.WindowWidth));
            Console.Write(new string(chars[3], Console.WindowWidth));
            Visual("Normal");
        }
        /// <summary>
        /// Affiche option de l'application
        /// </summary>
        /// <param name="Opctions"></param>
        /// <param name="choix"></param>
        public static void AfficherOpction(List<string> Opctions)
        {
            Console.WriteLine("\t╔═════════════════════════╗");
            for (int i = 0; i < Opctions.Count; i++)
            {
                Visual("Normal");
                Console.WriteLine("\t║  »" + Opctions[i] + "");
                Visual("Normal");                
            }
            Console.WriteLine("\t╚═════════════════════════╝");
        }

    }
}
