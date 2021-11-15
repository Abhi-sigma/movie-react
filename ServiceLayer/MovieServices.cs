using Microsoft.EntityFrameworkCore;
using ServiceLayer.Model;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json;


namespace ServiceLayer
{
    public class MoviesService
    {
        private readonly AppDbContext _appDbContext;
        public MoviesService(AppDbContext appDbContext)

        {
            _appDbContext = appDbContext;
        }



        public string GetMovies()
        {

            var moviesList = _appDbContext.Movies.Include(x=>x.MovieDetails).ToList();
           


            List<OrderedDictionary> json_object = new List<OrderedDictionary>();
            int counter = 1;


            foreach (var movies in moviesList)
                
            {
                OrderedDictionary movies_object = new OrderedDictionary();
                movies_object.Add("title", movies.Title);
                var actors = _appDbContext.MovieDetails.Where(x => x.Movie.Title.ToLower() ==
                    movies.Title.ToLower()).ToList();
                foreach (var actor in actors)

                    
                {
                    
                    var actorName = _appDbContext.Actors.FirstOrDefault(x => x.ActorId == actor.ActorId).Name;
                    if (movies.Director != actorName)
                    {
                        movies_object.Add("Actor" + counter.ToString(), actorName);
                        counter++;
                    }
                }
                counter = 1;
                movies_object.Add("director", movies.Director);
                movies_object.Add("imdbid", movies.imdbId);
                movies_object.Add("postor", movies.Poster);
                movies_object.Add("language", movies.Language);
                movies_object.Add("tags", movies.Tags);
                json_object.Add(movies_object);

            }
            return JsonSerializer.Serialize(json_object);
            

        }

        public string GetMoviesByName(string Name)
        {

            Movies movie = _appDbContext.Movies.FirstOrDefault(x => x.Title.ToLower() == Name.ToLower());
            int movieId = movie.MovieId;
            var actors = _appDbContext.MovieDetails.Where(x => x.Movie.Title.ToLower() ==
                   movie.Title.ToLower()).ToList();
            int counter = 1;
            OrderedDictionary movies_object = new OrderedDictionary();
            foreach ( var actor in actors)

            {
                var actorName = _appDbContext.Actors.Where(x => x.ActorId == actor.ActorId)
                    .FirstOrDefault().Name;
                if (actor.Actor.ActorTypeId == 1001)
                {

                }
                else
                {
                    movies_object.Add("Actor" + counter.ToString(), actorName);
                    counter++;
                }
             
            }
            movies_object.Add("director", movie.Director);
            movies_object.Add("imdbid", movie.imdbId);
            movies_object.Add("postor", movie.Poster);
            movies_object.Add("language", movie.Language);

            return JsonSerializer.Serialize(movies_object);
        }

        //public string GetMoviesByCategory(string category)
        //{
        //    string tags = _appDbContext.Movies.
        //        FirstOrDefault()
        //    Movies movie = _appDbContext.Movies.FirstOrDefault(x => x.Tags.ToLower() == category.ToLower());
        //    int movieId = movie.MovieId;
        //    var actors = _appDbContext.MovieDetails.Where(x => x.Movie.Title.ToLower() ==
        //           movie.Title.ToLower()).ToList();
        //    int counter = 1;
        //    OrderedDictionary movies_object = new OrderedDictionary();
        //    foreach (var actor in actors)

        //    {
        //        var actorName = _appDbContext.Actors.Where(x => x.ActorId == actor.ActorId)
        //            .FirstOrDefault().Name;
        //        if (actor.Actor.ActorTypeId == 1001)
        //        {

        //        }
        //        else
        //        {
        //            movies_object.Add("Actor" + counter.ToString(), actorName);
        //            counter++;
        //        }

        //    }
        //    movies_object.Add("director", movie.Director);
        //    movies_object.Add("imdbid", movie.imdbId);
        //    movies_object.Add("postor", movie.Poster);
        //    movies_object.Add("language", movie.Language);

        //    return JsonSerializer.Serialize(movies_object);
        //}
    }


    }

