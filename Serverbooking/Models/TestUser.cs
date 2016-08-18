

namespace Serverbooking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class TestUser
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter your Username", AllowEmptyStrings = false) ]
        public string Username { get; set; }        
        public string Password { get; set; }
        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Email { get; set; }
    }
}
