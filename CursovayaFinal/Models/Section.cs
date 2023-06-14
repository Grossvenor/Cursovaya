namespace CursovayaFinal.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DUevent> DUevents { get; set; }
    }
}
