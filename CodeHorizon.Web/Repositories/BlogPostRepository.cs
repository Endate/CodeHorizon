using CodeHorizon.Web.Data;
using CodeHorizon.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodeHorizon.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly CodeHorizonDbContext codeHorizonDbContext;

        public BlogPostRepository(CodeHorizonDbContext codeHorizonDbContext)
        {
            this.codeHorizonDbContext = codeHorizonDbContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await codeHorizonDbContext.AddAsync(blogPost);
            await codeHorizonDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlog = await codeHorizonDbContext.BlogPosts.FindAsync(id);

            if (existingBlog != null)
            {
                codeHorizonDbContext.BlogPosts.Remove(existingBlog);
                await codeHorizonDbContext.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await codeHorizonDbContext.BlogPosts.Include(x => x.Tags).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await codeHorizonDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await codeHorizonDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var existingBlog = await codeHorizonDbContext.BlogPosts.Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if (existingBlog != null)
            {
                existingBlog.Id = blogPost.Id;
                existingBlog.Heading = blogPost.Heading;
                existingBlog.Author = blogPost.Author;
                existingBlog.PageTitle = blogPost.PageTitle;
                existingBlog.Content = blogPost.Content;
                existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlog.ShortDescription = blogPost.ShortDescription;
                existingBlog.UrlHandle = blogPost.UrlHandle;
                existingBlog.Visible = blogPost.Visible;
                existingBlog.PublishedDate = blogPost.PublishedDate;
                existingBlog.Tags = blogPost.Tags;

                await codeHorizonDbContext.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }
    }
}
