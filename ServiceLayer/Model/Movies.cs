using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayer.Model
{
    public class Movies
    {
        public Movies()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Actors { get; set; }

        public string Tags { get; set; }
        public string Awards { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string Released { get; set; }
        public string Year { get; set; }
        public int imdbrating { get; set; }
        public int imdbId { get; set; }
        public DateTime InsertedDate { get; set; }
        public string YouTubeLink { get; set; }
        public string AlternateName { get; set; }

        
        public virtual ICollection<MovieDetail> MovieDetails { get; set; }

        
    }
}
