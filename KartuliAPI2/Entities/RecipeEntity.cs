using System.ComponentModel.DataAnnotations;

namespace KartuliAPI2.Entities
{
    public class RecipeEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RecipeDescription { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}

