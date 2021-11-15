using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieMaster;
using ServiceLayer;
using ServiceLayer.Model;

namespace MovieWorldApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {

        private IMovie _movie;
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, IMovie movie)
        {
            _logger = logger;
            _movie = movie;
        }


        /// <summary>
        /// The method takes search string and return list of actors from database
        /// </summary>
        /// <param name="search"></param>
        /// <returns> List of Actors</returns>
        [HttpGet("actor")]
        public async Task<ListViewModel> Actor(string search)
        {
            var test = await _movie.getActor(search);
            return test;
        }


    } 
}
