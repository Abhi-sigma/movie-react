using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServiceLayer.Model
{
   public class Tags
    {
        public Tags()
        {

        }

        public string TagsName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int TagId { get; set; }

        public virtual ICollection<MovieDetail> MoviDetails { get; set; }

    }
}
