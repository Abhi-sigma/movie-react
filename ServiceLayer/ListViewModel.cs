using System;
using System.Collections.Generic;
using ServiceLayer.Model;

namespace ServiceLayer
{
    public class ListViewModel
    {
        public ListViewModel()
        {


        }

        public List<Actor> Actors { get; set; }
        public List<Movies> Movies { get; set; }
        public List<MovieDetail> MovieDetail { get; set; }
    }
    
}
