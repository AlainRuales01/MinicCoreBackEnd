using ARMiniCore.Backend.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace ARMiniCore.Backend.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {

        }
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationUtility.GetConfiguratiConnectionSetting("DataBaseConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Contrato> Contrato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Contrato>().ToTable("Contrato");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Task>().HasOne(u => u.UsuarioCreador)
        //        .WithMany(u => u.TareasCreadas)
        //        .HasForeignKey(u => u.UsuarioId)
        //        .OnDelete(DeleteBehavior.ClientSetNull);

        //    modelBuilder.Entity<UsuarioCourse>().HasOne(u => u.Usuario)
        //        .WithMany(u => u.Cursos)
        //        .HasForeignKey(u => u.UsuarioId)
        //        .OnDelete(DeleteBehavior.ClientSetNull);

        //    modelBuilder.Entity<UsuarioCourse>().HasOne(u => u.Curso)
        //        .WithMany(u => u.Usuarios)
        //        .HasForeignKey(u => u.CourseId)
        //        .OnDelete(DeleteBehavior.ClientSetNull);

        //    modelBuilder.Entity<TaskRate>().HasOne(u => u.Estudiante)
        //        .WithMany(u => u.CalificacionesEstudiante)
        //        .HasForeignKey(u => u.UsuarioId)
        //        .OnDelete(DeleteBehavior.ClientSetNull);

        //    modelBuilder.Entity<TaskRate>().HasOne(u => u.Tarea)
        //        .WithMany(u => u.CalificacionesTarea)
        //        .HasForeignKey(u => u.TaskCourseId)
        //        .OnDelete(DeleteBehavior.ClientSetNull);

        //    modelBuilder.Entity<TaskCourse>().HasOne(u => u.Curso)
        //        .WithMany(u => u.TareasCurso)
        //        .HasForeignKey(u => u.CourseId)
        //        .OnDelete(DeleteBehavior.ClientSetNull);

        //    modelBuilder.Entity<TaskCourse>().HasOne(u => u.Tarea)
        //        .WithMany(u => u.CursosTarea)
        //        .HasForeignKey(u => u.TaskId)
        //        .OnDelete(DeleteBehavior.ClientSetNull);
        //}
    }
}
