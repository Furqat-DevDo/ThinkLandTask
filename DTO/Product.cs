namespace ThinkLand.DTO
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required, MaxLength(40)]
        public string Name { get; set; }

        [Range(1, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required, ForeignKey("Category")]
        public Guid Categoryid { get; set; }
       
        public Product(int stock, string name, double price, Guid categoryid)
        {
            this.Name = name;
            this.Price = price;
            this.Categoryid = categoryid;
            this.Stock=stock;
        }
    }
}