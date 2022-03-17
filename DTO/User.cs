namespace ThinkLand.DTO
{
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; } = Guid.NewGuid();
        
        [Required,MaxLength(20)]
        public string Name { get; set; }
        [Required,MaxLength(6)]
        public string PassWord { get; set; }
        
    }
}