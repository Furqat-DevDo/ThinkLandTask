namespace ThinkLand.Model
{
    public class Product
    {
        public Guid ID { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }

        [Range(1, double.MaxValue)]
        public double Price { get; set; }

        [Range(1, 500)]
        public int Stock { get; set; }

        [Required]
        public Guid CategoryID { get; set; }

    }
}