﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayer.Model
{
    public class Actor
    {
        public Actor()
        {
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ActorId { get; set; }
        public string Name { get; set; }
        public int ActorTypeId { get; set; }
        public DateTime InsertedDate { get; set; }
        public string ImageLink { get; set; }
        public virtual ICollection<MovieDetail> MovieDetails { get; set; }

    }
}
