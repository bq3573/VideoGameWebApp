using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoGameWebApp.Data;
using VideoGameWebApp.Models;

namespace VideoGameWebApp.Pages.VideoGames
{
    public class DetailsModel : PageModel
    {
        private readonly VideoGameWebApp.Data.VideoGameWebAppContext _context;

        public DetailsModel(VideoGameWebApp.Data.VideoGameWebAppContext context)
        {
            _context = context;
        }

      public VideoGame VideoGame { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.VideoGame == null)
            {
                return NotFound();
            }

            var videogame = await _context.VideoGame.FirstOrDefaultAsync(m => m.ID == id);
            if (videogame == null)
            {
                return NotFound();
            }
            else 
            {
                VideoGame = videogame;
            }
            return Page();
        }
    }
}
