namespace ThinkLand.Model
{
    public class Category
    {   
        [Required,MaxLength(30)]
        public string Name { get; set; }
        
        public virtual ICollection<Product> Products { get; set;}
    }
}