using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieWorldApi.Controllers;
using ServiceLayer;
using ServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text.Json;


namespace UnitTestsMovieWorld
{
    [TestClass]
    public class UnitTest1
    {
        public AppDbContext db_connection;


        public UnitTest1()
        {
            db_connection = db_connector();

        }

        public AppDbContext db_connector()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            //uncomment the line to use in memory database
            //optionsBuilder.UseInMemoryDatabase(databaseName: "madrasimovies");
            optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13; Database=madrasimovies");
            return new AppDbContext(optionsBuilder.Options);

        }









        [TestMethod]
        public void TestMethod1Async()

        {

            var client = new HttpClient();
            var movie = new HttpRequestor(client);
            var controller = new AdminController(movie, db_connection);
            var result = controller.OmdbApi("baaghi");
            Assert.IsTrue(result.Equals("baaghi"));

        }


        [TestMethod]
        public void CreateJson()

        {
            System.Collections.Specialized.OrderedDictionary dictionary = new System.Collections.Specialized.OrderedDictionary();
            dictionary.Add("name", "Abhi");
            string json = JsonSerializer.Serialize<OrderedDictionary>(dictionary);

        }

        [TestMethod]
        public void DataAdder()


        {


            {

                Movies movie = new Movies
                {
                    Title = "Don2",
                    Actors = "Sharukh Khan,Priyanka Chopra",
                    Director = "farhan Akhtar",
                    Released = new DateTime(2006, 6, 1).ToString(),

                };

                db_connection.Movies.Add(movie);
                foreach (var item in movie.Actors.Split(","))
                {
                    Actor actor = new Actor { ActorTypeId = 1, Name = item };
                    db_connection.Add(actor);
                    MovieDetail moviedetail = new MovieDetail
                    { Movie = movie, Actor = actor };
                    db_connection.MovieDetails.Add(moviedetail);
                }

                db_connection.SaveChanges();

            }




        }
    }
}
