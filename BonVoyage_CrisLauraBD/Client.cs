namespace BonVoyage_CrisLauraMetier
{
    public class Client : Personne
    {
        public string CarteBancaire { get; set; }
        public int Id { get; set; }
        public string Login { get; set; }
        public string MotDePasse { get; set; }
    }
}
