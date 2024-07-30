using Microsoft.EntityFrameworkCore;
using TakeAway.Comment.DAL.Etities;

namespace TakeAway.Comment.DAL.Context
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        {
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
