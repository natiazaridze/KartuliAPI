using System.ComponentModel.DataAnnotations;

namespace KartuliAPI2.Entities
{
    public class WineEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
