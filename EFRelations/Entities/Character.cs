using System.Text.Json.Serialization;

namespace EFRelations.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RpgClass { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public int UserId { get; set; }
        public Weapon Weapon { get; set; }
        List<Skill> Skill { get; set; }

    }
}
