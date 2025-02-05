using CodeHorizon.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodeHorizon.Web.Data
{
    public class CodeHorizonDbContext : DbContext
    {
        public CodeHorizonDbContext(DbContextOptions<CodeHorizonDbContext> options) : base(options)
        {
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostLike> BlogPostLike { get; set; }
        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}
