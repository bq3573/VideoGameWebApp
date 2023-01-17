using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideoGameWebApp.Models;

namespace VideoGameWebApp.Data
{
    public class VideoGameWebAppContext : DbContext
    {
        public VideoGameWebAppContext (DbContextOptions<VideoGameWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<VideoGameWebApp.Models.VideoGame> VideoGame { get; set; } = default!;
    }
}
