namespace ThinkLand.DTO
{
    public class UserLogin
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
