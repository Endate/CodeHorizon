using CodeHorizon.Web.Data;
using CodeHorizon.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodeHorizon.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly CodeHorizonDbContext codeHorizonDbContext;

        public TagRepository(CodeHorizonDbContext codeHorizonDbContext)
        {
            this.codeHorizonDbContext = codeHorizonDbContext;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await codeHorizonDbContext.Tags.AddAsync(tag);
            await codeHorizonDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await codeHorizonDbContext.Tags.FindAsync(id);

            if (existingTag != null)
            {
                codeHorizonDbContext.Tags.Remove(existingTag);
                await codeHorizonDbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await codeHorizonDbContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            return codeHorizonDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await codeHorizonDbContext.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await codeHorizonDbContext.SaveChangesAsync();

                return existingTag;
            }
            return null;
        }
    }
}
