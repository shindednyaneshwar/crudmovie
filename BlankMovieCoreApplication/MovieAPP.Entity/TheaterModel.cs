using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieAPP.Entity
{
  
    public class TheaterModel
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TheaterId { get; set; }
        public string TheaterName { get; set; }

        public string TheaterLocation { get; set; }

       public string Email { get; set; }
       public string Password { get; set; }
    }
}
