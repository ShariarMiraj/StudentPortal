﻿using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models.Domain;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<DiscussionForum> DiscussionForums { get;set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<AttendanceTracking> AttendanceTrackings { get; set; }
        public DbSet<Fee> fees { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
