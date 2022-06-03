  using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;//for model validations also
using System.ComponentModel.DataAnnotations.Schema;//for sql constraints

namespace MovieAPP.Entity
{
     public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int UserId { get; set; }

        [Required (ErrorMessage ="Please Enter FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please Enter LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile")]
        public int Mobile { get; set; }

    }
}
