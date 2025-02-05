using CodeHorizon.Web.Data;
using CodeHorizon.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodeHorizon.Web.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly CodeHorizonDbContext codeHorizonDbContext;

        public BlogPostCommentRepository(CodeHorizonDbContext codeHorizonDbContext)
        {
            this.codeHorizonDbContext = codeHorizonDbContext;
        }

        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await codeHorizonDbContext.BlogPostComment.AddAsync(blogPostComment);
            await codeHorizonDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
            return await codeHorizonDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }
    }
}
