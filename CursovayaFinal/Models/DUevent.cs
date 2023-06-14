namespace CursovayaFinal.Models
{
    public class DUevent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Section>? Sections{ get; set; }
        public List<User>? Users { get; set; }

        public EventCondition? EventCondition { get; set; }
        public DateTime? DateOfEvent { get; set; }

    }
}
