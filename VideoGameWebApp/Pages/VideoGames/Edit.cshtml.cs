using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoGameWebApp.Data;
using VideoGameWebApp.Models;

namespace VideoGameWebApp.Pages.VideoGames
{
    public class EditModel : PageModel
    {
        private readonly VideoGameWebApp.Data.VideoGameWebAppContext _context;

        public EditModel(VideoGameWebApp.Data.VideoGameWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VideoGame VideoGame { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.VideoGame == null)
            {
                return NotFound();
            }

            var videogame =  await _context.VideoGame.FirstOrDefaultAsync(m => m.ID == id);
            if (videogame == null)
            {
                return NotFound();
            }
            VideoGame = videogame;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VideoGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoGameExists(VideoGame.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VideoGameExists(int id)
        {
          return (_context.VideoGame?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
