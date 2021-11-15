using System;
using System.Collections.Generic;
using ServiceLayer.Model;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ServiceLayer
{
    public class MovieRepository : IMovie

    {
       
        private AppDbContext _appDbContext;
        public MovieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }


        //string query:actor,director,name
        //string type:actor,director
        
        //public PropertyInfo CheckIfDataExists(string query,string type)
        //{
        //    var property = _appDbContext.GetType().GetProperty(type);
        //    return _appDbContext.property;
            
            

        //}

        public async Task<ListViewModel> getActor(string search)
        {

           ListViewModel model = new ListViewModel();
            try
            {
                if (!String.IsNullOrEmpty(search))
                {
                    model.Actors = await _appDbContext.Actors.Where(x => x.Name.Contains(search)).ToListAsync();
                    model.Movies = await _appDbContext.Movies.Where(x => x.Title.Contains(search)).ToListAsync();
                }
            } catch (Exception ex)
            {
                throw ex;
            }

          return model;
        }

        public List<Movies> getMovie()
        {
            throw new NotImplementedException();
        }

       
    }
}
