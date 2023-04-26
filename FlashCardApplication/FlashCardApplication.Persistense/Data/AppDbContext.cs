using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlashCardApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlashCardApplication.Persistense.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<FlashCard> FlashCards => Set<FlashCard>();
        public DbSet<Module> Modules => Set<Module>();
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) => Database.EnsureCreated();
    }
}
