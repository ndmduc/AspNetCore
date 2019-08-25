using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using aspnetcoreapp.Data;
using aspnetcoreapp.Models;

namespace aspnetcoreapp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly aspnetcoreapp.Data.RazorPagesMovieContext _context;

        public CreateModel(aspnetcoreapp.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // When the Create form posts the form values, the ASP.NET Core runtime binds the posted values to the Movie model.
        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}