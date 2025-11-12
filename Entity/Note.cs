namespace gestion_etudiant.Entity
{
    public class Note
    {
        public int Id { get; set; }
        public Etudiant? Etudiant { get; set; }
        public double Valeur { get; set; }
    }
}
