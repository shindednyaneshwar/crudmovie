using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPP.Entity
{
    public class MovieModel
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId{get;set;}

        public string MovieName { get; set; }

        public string MovieLocation { get; set; }
    }
}
