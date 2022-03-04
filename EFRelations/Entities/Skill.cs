using System.Text.Json.Serialization;

namespace EFRelations.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; } = 10;
        [JsonIgnore]
        List<Character> Characters { get; set; }
    }
}
