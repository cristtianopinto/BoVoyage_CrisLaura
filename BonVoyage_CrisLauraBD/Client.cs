﻿namespace BoVoyage_CrisLauraMetier
{
    public class Client : Personne
    {
        public string CarteBancaire { get; set; }
        public int Id { get; set; }//Numéro séquenciel
        public string Login { get; set; }
        public string MotDePasse { get; set; }
        public Adresse Adresse { get; set; }
    }
}
