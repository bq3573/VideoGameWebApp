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
    public class IndexModel : PageModel
    {
        private readonly VideoGameWebApp.Data.VideoGameWebAppContext _context;

        public IndexModel(VideoGameWebApp.Data.VideoGameWebAppContext context)
        {
            _context = context;
        }

        public IList<VideoGame> VideoGame { get;set; } = default!;


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? VideoGameGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.VideoGame
                                            orderby m.Genre
                                            select m.Genre;


            var videoGames = from m in _context.VideoGame
                         select m;
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                videoGames = videoGames.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(VideoGameGenre))
            {
                videoGames = videoGames.Where(x => x.Genre == VideoGameGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            VideoGame = await videoGames.ToListAsync();
        }
    }
}
