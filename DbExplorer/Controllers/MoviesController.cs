using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;
using ServiceLayer.Model;
using MovieWorldApi.Controllers;

namespace DbExplorer.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
           
            _context = context;
        }
        
        // GET: Movies
        public async Task<IActionResult> Index(string? search)
        {
            if (search != null)
                
            {
                ListViewModel viewModel = new ListViewModel
                {
                    Movies = await _context.Movies.Include(m => m.MovieDetails).
                    Where(m => m.Title == search).ToListAsync(),
                    Actors = await _context.Actors.ToListAsync(),
                    MovieDetail = await _context.MovieDetails.ToListAsync()

                };
                return View(viewModel);
                
             }
            else {
                ListViewModel viewModel = new ListViewModel
                {
                    MovieDetail = await _context.MovieDetails.ToListAsync(),
                    Actors = await _context.Actors.ToListAsync(),
                    Movies = await _context.Movies.ToListAsync()
                };
                return View(viewModel);
            }
        }

        //public async Task<IActionResult> HomePageModifier(int? id)
        //{
        //    var movies = await _context.Movies.FindAsync(id);
        //    ListViewModel viewModel = new ListViewModel
        //    {
        //        Movies = await _context.Movies.Include(m => m.MovieDetails).
        //            Where(m => m.MovieId == id).ToListAsync(),
        //        Actors = await _context.Actors.ToListAsync(),
        //        MovieDetail = await _context.MovieDetails.ToListAsync()

        //    };
        //    return View(viewModel);
        //}

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Title,Actors,Awards,Director,Genre,Language,Plot,Poster,Released,Year,imdbrating,imdbId,InsertedDate,YouTubeLink,AlternateName")] Movies movies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movies);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ListViewModel viewModel = new ListViewModel
            {
                Movies = await _context.Movies.Include(m => m.MovieDetails).Where(m => m.MovieId == id)
                .ToListAsync(),


                MovieDetail = await _context.MovieDetails.Include(m => m.Actor).
                Where(m => m.MovieId == id).ToListAsync()

             


            };
            
           
            if (viewModel.Movies.Count == 0)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,string tags , Movies movies)
        {

            ListViewModel viewModel = new ListViewModel
            {
                Movies = await _context.Movies.Include(m => m.MovieDetails).
                   Where(m => m.MovieId == id).ToListAsync(),
                //Actors = await _context.Actors.ToListAsync(),
                //MovieDetail = await _context.MovieDetails.ToListAsync()

            };
            //instance of movie to update
            Movies movieToUpdate = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            
            movieToUpdate.Tags = tags;
            //Update the movie
            if (await TryUpdateModelAsync<Movies>(movieToUpdate,
            "",
            c => c.Tags))
            {
                try
                {

                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }

            }

            List<string> tags_list = tags.Split(',').ToList();


            //insert the tag in table
            for (int i = 0; i < tags_list.Count(); i++)
            {


                if (_context.Tags.Where(tagname => tagname.TagsName ==
                                                tags_list[i]).Count() > 0)

                {
                    //found a tag,do nothing
                }
                else
                {
                    //Create a new entry for tag

                    Tags tag =
                        new Tags
                        {

                            TagsName = tags_list[i]
                        };

                    _context.Tags.Add(tag);
                    MovieDetail moviedetail = new MovieDetail
                    {
                        Movie = movieToUpdate,

                        Tag = _context.Tags.Where(tags => tags.TagsName == tags_list[i]).FirstOrDefault()


                    };
                    _context.MovieDetails.Add(moviedetail);
                    await _context.SaveChangesAsync();
                }



                
                
            }
            return View(viewModel);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movies = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
