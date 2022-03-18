global using System.ComponentModel.DataAnnotations.Schema;
global using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ThinkLand.DTO
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required, MaxLength(30)]
        public string Name { get; set; }
        public Category(string name)
        {
            this.Name = name;
        }
    }
}