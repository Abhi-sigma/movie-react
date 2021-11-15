using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;
using System.Collections.Specialized;
using ServiceLayer.Model;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Hosting.Server;

namespace MovieWorldApi.Controllers 

{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        public MovieInfoFromApi json_to_object;
        private IHttpCaller _httpcaller;
        private AppDbContext _appDbContext;
        private MoviesService _moviesService;
        private IServer _serverInfo;
        public AdminController(IHttpCaller httpCaller,
            AppDbContext appDbContext, MoviesService movieService , IServer serverinfo)
        {

            _httpcaller = httpCaller;
            _appDbContext = appDbContext;
            _moviesService = movieService;
            _serverInfo = serverinfo;


        }




        // gets the page which will search the imdb database
        [HttpGet("omdbapi")]
        public string OmdbApi(string search_query, string search_type)
        {
            string uri = string.Format("http://www.omdbapi.com/?t={0}&apikey=5d9755d", search_query);
            if (search_type == "title")
            {
                uri = string.Format("http://www.omdbapi.com/?t={0}&apikey=5d9755d", search_query);
            }
            else
            {
                uri = string.Format("http://www.omdbapi.com/?i={0}&apikey=5d9755d", search_query);
            }
            OrderedDictionary jsondict = new OrderedDictionary();
            string result = _httpcaller.Request(uri);
            json_to_object = JsonSerializer.Deserialize<MovieInfoFromApi>(result);
            List<Movies> movies = _appDbContext.Movies.Where(
                movie => movie.Title == json_to_object.Title).ToList();
            string TitleFromJson = json_to_object.Title;
            string actors = json_to_object.Actors;
            if (TitleFromJson == null)
            {
                jsondict.Add("msg", "No record found");
                return JsonSerializer.Serialize<OrderedDictionary>(jsondict);
            }
            //Get all the movies from the db with same title
            else {
                string json_result = null;
                if (movies.Count == 0)
                {
                    return result;
                }

                foreach (Movies moviesingle in movies)
                {
                    var movieDbStatus = CheckIfMovieInDb(json_to_object.Title, moviesingle);
                    //var TitleFromDb = _appDbContext.Movies.
                    //    Select(movie => movie.Title).Where(movie => movie == TitleFromJson.ToLower()).FirstOrDefault();
                    if (movieDbStatus.Equals(false))
                    {
                        json_result = result;
                        return json_result;
                    }
                    else
                    {

                        jsondict.Add("msg", "Movie already in db");
                        jsondict.Add("movies_in_db", movies);
                        json_result = JsonSerializer.Serialize<OrderedDictionary>(jsondict); ;
                        return json_result;

                    }


                }
                return json_result;
            };
        }

        public Boolean CheckIfMovieInDb(string movie_name, Movies movie)

        {
            Boolean IfallActorsPresent = false;
            //Boolean SameReleaseDate = false;

            if (movie.Title == movie_name) {
                //a movie with same title may exists,so we check actors in it
                String[] actors = json_to_object.Actors.Split(",");

                foreach (string actor in actors)
                {

                    if (_appDbContext.MovieDetails.Where(moviedetail => moviedetail.Actor.Name == actor &&
                        moviedetail.Movie.Title == movie_name
                        ).Count() > 0)
                    {

                        IfallActorsPresent = true;
                    }
                    else
                    {
                        IfallActorsPresent = false;
                        break;
                    }

                }


            }


            string releasedate = movie.Released;
            //#TODO:Fix this release date,currently removing this from criterion on line 134

            if (movie.Released == json_to_object.Released)
            {
                //SameReleaseDate = true;
            }
            if (movie.Title.Equals(json_to_object.Title) && IfallActorsPresent == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public void  InsertTags(Movies moviedata)

        {
            List<string> tags = moviedata.Tags.Split(',').ToList();



            for (int i = 0; i < tags.Count(); i++)
            {


                if (_appDbContext.Tags.Where(tagname => tagname.TagsName ==
                                                tags[i]).Count() > 0)

                {
                    //do nothing
                }
                else
                {

                    Tags tag =
                        new Tags
                        {

                            TagsName = tags[i]
                        };

                    _appDbContext.Tags.Add(tag);
                    _appDbContext.SaveChanges();



                }

            }

        }
        public List<Actor> InsertActors(Movies moviedata)

        {
            List<Actor> ActorList = new List<Actor>();

            for (int i = 0; i < moviedata.MovieDetails.Count(); i++)
            {

                //if we find actor name in actors db we do nothing
                if (_appDbContext.Actors.Where(actorName => actorName.Name ==
                                                moviedata.MovieDetails.ElementAt(i).Actor.Name).Count() > 0)

                {
                    //do nothing
                }
                else
                //we create actors,this returns a list of actors object
                {

                    Actor newActor =
                        new Actor { ActorTypeId = 1,
                            Name = moviedata.MovieDetails.ElementAt<MovieDetail>(i).Actor.Name,
                            ImageLink = moviedata.MovieDetails.ElementAt<MovieDetail>(i).Actor.ImageLink };
                    ActorList.Add(newActor);
                    _appDbContext.Actors.Add(newActor);
                }
                _appDbContext.SaveChanges();

            }
            return ActorList;
        }

        public void AddDirector(string directorname, Movies movie)
        {
            //check if director is in actor table
            if (_appDbContext.Actors.Where(x => x.Name == directorname && x.ActorTypeId == 2).Count() > 0)
            {
                //do nothing
            }
            else
            {
                Actor director = new Actor
                {
                    ActorTypeId = 1001,
                    Name = directorname,

                };
                _appDbContext.Actors.Add(director);
                MovieDetail moviedetail = new MovieDetail
                {
                    Movie = movie,
                    Actor = director
                };
                _appDbContext.MovieDetails.Add(moviedetail);
                _appDbContext.SaveChanges();


            }
        }


        // POST api/<AdminController>
        [HttpPost("add")]
        public string Post([FromForm] Movies moviedata)
        {
            InsertActors(moviedata);
            Movies movie = new Movies
            {
                Title = moviedata.Title,
                Released = moviedata.Released,
                imdbId = moviedata.imdbId,
                imdbrating = moviedata.imdbrating,
                Director = moviedata.Director,
                Language = moviedata.Language,
                Genre = moviedata.Genre,
                YouTubeLink = moviedata.YouTubeLink,
                AlternateName = moviedata.AlternateName,
                Awards = moviedata.Awards,
                Plot = moviedata.Plot,
                Poster = moviedata.Poster,
                Year = moviedata.Year,
                Tags = moviedata.Tags
            };
            _appDbContext.Movies.Add(movie);
            AddDirector(moviedata.Director, movie);
            InsertTags(moviedata);
            //Use this to add to moviedetail
            string[] tags_list = movie.Tags.Split(",");
            int tag_counter=0;
            //Actor names is sent as moviedetails by using form
            //so loop through all actors and add if they are not added
            for (var i = 0; i < moviedata.MovieDetails.Count(); i++ )
            { 
                while (i < tags_list.Length) {
                    tag_counter = i;
                    break;
                   
                  
                   
                 
                }
                MovieDetail moviedetail = new MovieDetail 
                {
                    Movie = movie,
                    Actor = _appDbContext.Actors.Where(actor => actor.Name
                    == moviedata.MovieDetails.ElementAt(i).Actor.Name).FirstOrDefault(),
                    Tag = _appDbContext.Tags.Where(tags => tags.TagsName == tags_list[tag_counter]).FirstOrDefault()


                };
                _appDbContext.MovieDetails.Add(moviedetail);
               





            }


            _appDbContext.SaveChanges();

            return "added to db";


        }
        [Route("resources/{category?}/{example}/{name?}")]
        [HttpGet]
        public string GetResource(string example, string name = "", string category  = "")

        {
            string parameter;

            if (category == "category")
            {
                switch (example)
                {
                    case "movies":

                        break;
                    default:
                        return "";

                }
                return "";
            }
            else
            {
                switch (example)
                {
                    case "movies":
                        if (!string.IsNullOrEmpty(name))
                        {
                            parameter = _moviesService.GetMoviesByName(name);
                        }
                        else
                        {
                            parameter = _moviesService.GetMovies();
                        }

                        break;
                    case "songs":
                        parameter = "songs";
                        break;
                    default:
                        parameter = "default";
                        break;
                }
                return parameter;
            }
           
        }

        [Route("resources/movies/getby{type}/{name}")]
        [HttpGet]
        public string GetMoviesBy(string type, string name)

        {
            if (type == "actor")
            {
                Actor actor = _appDbContext.Actors.Where(x => x.Name.ToLower() == name.ToLower()).
                    FirstOrDefault();
                List<MovieDetail> movies = _appDbContext.MovieDetails.Include(c => c.Movie).Where(
                    x => x.ActorId == actor.ActorId).ToList();
                List<string> movie_collection_json = new List<string>();
                for (var i = 0; i < movies.Count(); i++)
                {
                    string movie_from_db = _moviesService.GetMoviesByName(movies[i].Movie.Title);
                    movie_collection_json.Add(movie_from_db);

                };

                return JsonSerializer.Serialize(movie_collection_json); ;
            }

            else if (type == "director")
            {
                Actor actor = _appDbContext.Actors.Where(x => x.Name.ToLower() == name.ToLower()).
                    FirstOrDefault();
                List<MovieDetail> movies = _appDbContext.MovieDetails.Include(c => c.Actor).Include(m=>m.Movie).Where(
                    x => x.ActorId == actor.ActorId && x.Actor.ActorTypeId==1001).ToList();
                List<string> movie_collection_json = new List<string>();
                for (var i = 0; i < movies.Count(); i++)
                {

                    string movie_from_db = _moviesService.GetMoviesByName(movies[i].Movie.Title);
                    movie_collection_json.Add(movie_from_db);

                };

                return JsonSerializer.Serialize(movie_collection_json); ;
            }
            if (type == "category")
            {

                return "";

            }
           
            
            else
            {
                return "not found";
            }
        }


        //[Route("resources/{category}/home/")]
        //[HttpGet]
        //public string GetHomePageItems(string category)
        //{

        //    string result;

        //    if(category == "movies" )
        //    {
        //       var movies = _appDbContext.Movies.W

                
        //    return "";            
        //    }

        //   return result
        //}











        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }                    
    }
}

