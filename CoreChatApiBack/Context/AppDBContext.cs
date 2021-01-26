using CoreChatApiBack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreChatApiBack.Context
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> dbContext):base (dbContext)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Chat> Chats { get; set; }
    }
}
