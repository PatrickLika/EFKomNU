namespace EFKomNU.Model
{
    public class Kompetence
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public List<Medarbejder> MedarbejderListe { get; set; }

    }
}
