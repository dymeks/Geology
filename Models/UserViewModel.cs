using System.ComponentModel.DataAnnotations;

namespace Geology.Models
{
    public abstract class BaseEntity {}

    public class UserViewModel : BaseEntity
    {
        [Required(ErrorMessage = "First name is a required field!")]
        [MinLength(2,ErrorMessage = "Name must be longer than 2 letters!")]
        [RegularExpression(@"^[a-zA-Z]+$", 
         ErrorMessage = "Name must Only contain letters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is a required field")]
        [MinLength(2,ErrorMessage = "Name must be longer than 2 letters!")]
        [RegularExpression(@"^[a-zA-Z]+$", 
         ErrorMessage = "Name must Only contain letters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is a required field!")]
        [EmailAddress(ErrorMessage = "Must Submit a valid email!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password must be at least 8 characters!")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage="Password and Password Confirm must match!")]
        public string PasswordConfirm {get;set;}
        // [Required(ErrorMessage = "Age must be a positive number!")]
        // [Range(1,120,ErrorMessage = "Age must be a positive number!")]
        // [DataAnnotationsExtensions.Integer(ErrorMessage = "Age must be a valid number!")]
        // public int Age {get;set;}
    }
}