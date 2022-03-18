namespace ThinkLand.Model
{
    public class Category
    {
        public Guid ID { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
    }
}