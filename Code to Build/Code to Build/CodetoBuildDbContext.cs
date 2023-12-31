﻿using Code_to_Build.Model;
using Microsoft.EntityFrameworkCore;

namespace Code_to_Build
{
    public class CodetoBuildDbContext :DbContext
    {
        public CodetoBuildDbContext(DbContextOptions<CodetoBuildDbContext> options)
        : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
