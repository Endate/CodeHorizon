
using CodeHorizon.Web.Data;
using CodeHorizon.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodeHorizon.Web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly CodeHorizonDbContext codeHorizonDbContext;

        public BlogPostLikeRepository(CodeHorizonDbContext codeHorizonDbContext)
        {
            this.codeHorizonDbContext = codeHorizonDbContext;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await codeHorizonDbContext.BlogPostLike.AddAsync(blogPostLike);
            await codeHorizonDbContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await codeHorizonDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await codeHorizonDbContext.BlogPostLike.CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
