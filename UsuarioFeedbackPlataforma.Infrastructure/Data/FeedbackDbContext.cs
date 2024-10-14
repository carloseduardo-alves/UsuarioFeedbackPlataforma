using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioFeedbackPlataforma.Core.Entities;

namespace UsuarioFeedbackPlataforma.Infrastructure.Data
{
    public class FeedbackDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }

        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
