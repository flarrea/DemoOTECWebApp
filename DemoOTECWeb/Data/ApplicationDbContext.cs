using System;
using System.Collections.Generic;
using System.Text;
using DemoOTECWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoOTECWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Relator> Relators { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}
