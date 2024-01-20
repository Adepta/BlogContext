using DataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    public class EFBlogContext : IdentityDbContext<BlogUser>
    {
        public EFBlogContext(DbContextOptions<EFBlogContext> options) : base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                
        }
        
        
        public DbSet<BlogUser> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
