namespace EFKomNU.Model
{
    public class Medarbejder
    {
        public int Id { get; set; }
        public string Navn{ get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Titel { get; set; }
        public List<Kompetence> KompetenceListe { get; set; }
    }
}
