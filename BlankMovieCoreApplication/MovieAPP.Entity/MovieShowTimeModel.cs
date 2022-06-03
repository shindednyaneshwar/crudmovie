using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieAPP.Entity
{
   public  class MovieShowTimeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ShowId { get; set; }


        [ForeignKey ("movieModel")]
        public int MovieId { get; set; }
        public MovieModel movieModel { get; set; }


        [ForeignKey("theaterModel")]
        public int TheaterId { get; set; }
        public TheaterModel theaterModel { get; set; }


        public string ShowTime { get; set; }

        public string Date { get; set; }


    }
}
