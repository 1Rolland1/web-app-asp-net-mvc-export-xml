using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace web_app_asp_net_mvc_export_xml.Models
{
    public class TimetableContext : DbContext
    {

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<TeacherImage> TeacherImages { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Nationality> Nationalitys { get; set; }


        public TimetableContext() : base("TimetableEntity")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasOptional(x => x.TeacherImage).WithRequired().WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }


    }
}