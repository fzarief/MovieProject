using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieProject.Data;
using MovieProject.Service;
using MvcMovie.Models;

namespace MovieProject.Controllers
{

    public class MoviesController : Controller
    {
        ////    //private readonly MovieProjectContext _context;

        //IMovieService _movieService;

        //public MoviesController(IMovieService movieService)
        //{
        //    _movieService = movieService;
        //}

        ////GET: Movies
        //public async Task<IActionResult> Index(string search)
        //{
        //    if (search != null)
        //    {
        //        var resultSearch = await _movieService.GetAllSearch(search);
        //        return View(resultSearch);
        //    }

        //    var result = await _movieService.GetAll();
        //    MovieService movie = new MovieService();
        //    var m = await movie.GetAll();
        //    return View(m);
        //}

        ////GET: Movies/Details/5
        //public async Task<IActionResult> Details(int id)
        //{
        //    var result = await _movieService.GetById(id);
        //    return View(result);
        //}

        //// GET: Movies/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Movies/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([FromForm] Movie movie)
        //{
        //    await _movieService.Insert(movie);
        //    return RedirectToAction(nameof(Index));
        //}

        //// GET: Movies/Edit/5
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var result = await _movieService.GetById(id);
        //    return View(result);
        //}

        //// POST: Movies/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit([FromForm] Movie movie)
        //{
        //    await _movieService.Update(movie);
        //    return RedirectToAction(nameof(Index));
        //}

        //// GET: Movies/Delete/5
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _movieService.GetById(id);
        //    return View(result);
        //}

        //// POST: Movies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _movieService.Delete(id);
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool MovieExists(int id)
        //{
        //    return _context.Movie.Any(e => e.Id == id);
        //}




        IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string search)
        {
            if (search != null)
            {
                var resultSearch = await _movieService.GetAllSearch(search);
                return Json(resultSearch);
            }

            var result = await _movieService.GetAll();
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _movieService.GetById(id);
            return Json(result);
        }
        //[Route("movies/insert")]

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Movie movie)
        {
            try
            {
                await _movieService.Insert(movie);
                return Ok("Save done");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] Movie movie)
        {
            try
            {
                await _movieService.Update(movie);
                return Json(true);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.Delete(id);
            return Json(true);
        }
    }
}

