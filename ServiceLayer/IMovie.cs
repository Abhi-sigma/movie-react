using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ServiceLayer.Model;

namespace ServiceLayer
{
    public interface IMovie
    {
       
        public List<Movies> getMovie();
        public Task<ListViewModel> getActor(string search);

    
        
    }
}
