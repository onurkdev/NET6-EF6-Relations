namespace EFRelations.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        List<Character> Characters { get; set; }
    }
}
