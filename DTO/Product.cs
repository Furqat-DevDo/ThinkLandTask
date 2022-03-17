namespace ThinkLand.DTO
{
    public class Product
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; } = Guid.NewGuid();
            
        [Required,MaxLength(40)]
        public string Name { get; set; }
        
        [Range(1, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        public int  Stock { get; set; }
        
        [Required,ForeignKey("Category")]
        public Guid Categoryid { get; set; }

        public virtual Category category { get; set; }
        
    }
}