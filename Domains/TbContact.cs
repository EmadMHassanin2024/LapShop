using LapShop.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapShop.Models

{
    public class TbContact
    {
        [ValidateNever]
        public int ContactId { get; set; }
        [Required(ErrorMessage = "please enter name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "please enter name")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "PhoneNumber")]
        public int PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [ValidateNever]
        public DateTime CreatedDate { get; set; }

        public int CurrentState { get; set; }

 

        [Required(ErrorMessage = "YourMessage")]
        public string YourMessage { get; set; } = null!;





    }
}
