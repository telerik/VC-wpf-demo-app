namespace Infrastructure.Migrations
{
    using Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.StudentDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Infrastructure.StudentDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Peter Lucas", Email = "peter.lucas@mail.com", Course = "First", Specialty = "Computer Science" },
                new Student { Id = 2, Name = "Martha Golding", Email = "m.golding@mail.com", Course = "Second", Specialty = "Computer Science" },
                new Student { Id = 3, Name = "Sandra Butler", Email = "s.butler@mail.com", Course = "First", Specialty = "Networking" },
                new Student { Id = 4, Name = "Robert Balentine", Email = "robert.b@mail.com", Course = "Third", Specialty = "Electronics" },
                new Student { Id = 5, Name = "Joseph Spicer", Email = "j.spicer@mail.com", Course = "Second", Specialty = "Networking" },
                new Student { Id = 6, Name = "Linda Sam", Email = "sam.linda@mail.com", Course = "Fourth", Specialty = "Networking" },
                new Student { Id = 7, Name = "Delia Smith", Email = "ddelia@mail.com", Course = "Second", Specialty = "Electronics" },
                new Student { Id = 8, Name = "Shannon Glass", Email = "shan.glass@mail.com", Course = "Third", Specialty = "Computer Science" },
                new Student { Id = 9, Name = "George Griffin", Email = "griffinn@mail.com", Course = "First", Specialty = "Computer Science" },
                new Student { Id = 10, Name = "Keith Neimann", Email = "k.neimann@mail.com", Course = "Second", Specialty = "Computer Science" },
                new Student { Id = 11, Name = "Kim Thomas", Email = "k.tommas@mail.com", Course = "Fourth", Specialty = "Electronics" },
                new Student { Id = 12, Name = "Jared Hilton", Email = "hiltonn@mail.com", Course = "Third", Specialty = "Electronics" },
                new Student { Id = 13, Name = "Brandy Hunt", Email = "hunt.brandy@mail.com", Course = "Second", Specialty = "Networking" },
                new Student { Id = 14, Name = "David Cox", Email = "d.coxx@mail.com", Course = "First", Specialty = "Computer Science" },
                new Student { Id = 15, Name = "Martha Mejia", Email = "mmejia@mail.com", Course = "Third", Specialty = "Computer Science" },
                new Student { Id = 16, Name = "Andrew Maez", Email = "a.maezz@mail.com", Course = "Fourth", Specialty = "Networking" },
                new Student { Id = 17, Name = "Connie Williams", Email = "c.williams@mail.com", Course = "First", Specialty = "Computer Science" },
                new Student { Id = 18, Name = "Brett Miller", Email = "bredd.mil@mail.com", Course = "Third", Specialty = "Electronics" },
                new Student { Id = 19, Name = "Kevin Vargas", Email = "kev.vargas@mail.com", Course = "Second", Specialty = "Networking" },
                new Student { Id = 20, Name = "Joseph Garmon", Email = "joseph.s.garmon@mail.com", Course = "Fourth", Specialty = "Computer Science" }
            };

            students.ForEach(s => context.Students.AddOrUpdate(s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
                new Teacher { Id = 1, Name = "Alfredo Nesson", Email = "a.nesson@mail.com", Rank = "Professor" },
                new Teacher { Id = 2, Name = "Donald Cannady", Email = "donald.cannady@mail.com", Rank = "Lecturer" },
                new Teacher { Id = 3, Name = "Portia Anderson", Email = "p.anderson@mail.com", Rank = "Assistant Professor" },
                new Teacher { Id = 4, Name = "Sonja Alongi", Email = "sonja.alongi@mail.com", Rank = "Associate Professor" },
                new Teacher { Id = 5, Name = "Irene Atkinson", Email = "ir.atkinson@mail.com", Rank = "Guest Professor" }
            };

            teachers.ForEach(t => context.Teachers.AddOrUpdate(t));
            context.SaveChanges();

            var disciplines = new List<Discipline>
            {
                new Discipline { Id = 1, Title = "Physics", Teacher = teachers[0] },
                new Discipline { Id = 2, Title = "Algebra", Teacher = teachers[1] },
                new Discipline { Id = 3, Title = "Programming", Teacher = teachers[2] },
                new Discipline { Id = 4, Title = "Web Design", Teacher = teachers[3] },
                new Discipline { Id = 5, Title = "Machine Learning", Teacher = teachers[4] },
                new Discipline { Id = 6, Title = "Geometry", Teacher = teachers[0] },
                new Discipline { Id = 7, Title = "Operating Systems", Teacher = teachers[2] }
            };

            disciplines.ForEach(d => context.Disciplines.AddOrUpdate(d));
            context.SaveChanges();

            var currentDateTime = DateTime.Now;
            var tomorrow = currentDateTime.AddDays(1);
            var dayAfterTomorrow = currentDateTime.AddDays(2);

            context.Exams.AddOrUpdate(e => e.Id,
                new Exam
                {
                    Id = 1,
                    Description = "Physics - Term Test",
                    Hall = "305",
                    Discipline = disciplines[0],
                    ExaminationTimeStart = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 10, 30, 00, DateTimeKind.Local),
                    ExaminationTimeEnd = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 11, 30, 00, DateTimeKind.Local)
                },
                new Exam
                {
                    Id = 2,
                    Description = "Programming - Final Exam",
                    Hall = "501",
                    Discipline = disciplines[2],
                    ExaminationTimeStart = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 15, 00, 00, DateTimeKind.Local),
                    ExaminationTimeEnd = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 17, 45, 00, DateTimeKind.Local)
                },
                new Exam
                {
                    Id = 3,
                    Description = "Geometry - Project Defense",
                    Hall = "608",
                    Discipline = disciplines[5],
                    ExaminationTimeStart = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 09, 00, 00, DateTimeKind.Local),
                    ExaminationTimeEnd = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 12, 00, 00, DateTimeKind.Local)
                },
                new Exam
                {
                    Id = 4,
                    Description = "Algebra - Term Exam",
                    Hall = "100",
                    Discipline = disciplines[1],
                    ExaminationTimeStart = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 14, 30, 00, DateTimeKind.Local),
                    ExaminationTimeEnd = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 19, 00, 00, DateTimeKind.Local)
                },
                new Exam
                {
                    Id = 5,
                    Description = "Programming - Project Defense",
                    Hall = "237",
                    Discipline = disciplines[2],
                    ExaminationTimeStart = new DateTime(dayAfterTomorrow.Year, dayAfterTomorrow.Month, dayAfterTomorrow.Day, 10, 00, 00, DateTimeKind.Local),
                    ExaminationTimeEnd = new DateTime(dayAfterTomorrow.Year, dayAfterTomorrow.Month, dayAfterTomorrow.Day, 13, 20, 00, DateTimeKind.Local)
                });
            context.SaveChanges();

            context.Grades.AddOrUpdate(g => g.Id,
                new Grade { Id = 1, Discipline = disciplines[0], Score = 75, Student = students[0] },
                new Grade { Id = 2, Discipline = disciplines[1], Score = 80, Student = students[1] },
                new Grade { Id = 3, Discipline = disciplines[2], Score = 77, Student = students[2] },
                new Grade { Id = 4, Discipline = disciplines[3], Score = 90, Student = students[3] },
                new Grade { Id = 5, Discipline = disciplines[4], Score = 92, Student = students[0] },
                new Grade { Id = 6, Discipline = disciplines[0], Score = 88, Student = students[2] },
                new Grade { Id = 7, Discipline = disciplines[1], Score = 76, Student = students[3] },
                new Grade { Id = 8, Discipline = disciplines[2], Score = 82, Student = students[4] },
                new Grade { Id = 9, Discipline = disciplines[3], Score = 93, Student = students[6] },
                new Grade { Id = 10, Discipline = disciplines[4], Score = 100, Student = students[7] },
                new Grade { Id = 11, Discipline = disciplines[0], Score = 65, Student = students[9] },
                new Grade { Id = 12, Discipline = disciplines[1], Score = 79, Student = students[10] },
                new Grade { Id = 13, Discipline = disciplines[2], Score = 81, Student = students[12] },
                new Grade { Id = 14, Discipline = disciplines[3], Score = 79, Student = students[15] },
                new Grade { Id = 15, Discipline = disciplines[4], Score = 96, Student = students[17] }
            );
            context.SaveChanges();
        }
    }
}
