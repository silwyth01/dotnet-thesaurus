using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{

    public class ThesaurusContext : DbContext
    {
        public ThesaurusContext(DbContextOptions<ThesaurusContext> opt) : base(opt)
        {

        }

        public DbSet<Thesaurus> Thesauruses { get; set; }
    }
}

