using System.ComponentModel.DataAnnotations;

namespace KartuliAPI2.Models
{
    public class RecipeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RecipeDescription { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
