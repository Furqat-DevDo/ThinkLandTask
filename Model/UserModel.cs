namespace ThinkLand.Model
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required,MaxLength(6)]
        public string PassWord { get; set; }
        
    }
}