using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
 


namespace HYPERION_ASSESSMENT.Models;

public partial class CUsersMalcolmDesktopHyperionAssessmentHyperiondevassessmentMdfContext : DbContext
{
    public CUsersMalcolmDesktopHyperionAssessmentHyperiondevassessmentMdfContext()
    {
    }

    public CUsersMalcolmDesktopHyperionAssessmentHyperiondevassessmentMdfContext(DbContextOptions<CUsersMalcolmDesktopHyperionAssessmentHyperiondevassessmentMdfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;AttachDBFilename=C:\\Users\\Malcolm\\Desktop\\HYPERION_ASSESSMENT\\HYPERIONDEVASSESSMENT.mdf;Trusted_connection=TRUE;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__COURSE__2AA84FD19845FC8E");

            entity.ToTable("COURSE");

            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.Coursename)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("COURSENAME");
            entity.Property(e => e.Duration).HasColumnName("DURATION");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__ROLE__CD98460A275E642C");

            entity.ToTable("ROLE");

            entity.Property(e => e.RoleId).HasColumnName("roleID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudId).HasName("PK__STUDENT__E27BA9A30BFC3F61");

            entity.ToTable("STUDENT");

            entity.Property(e => e.StudId).HasColumnName("studID");
            entity.Property(e => e.Country)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("COUNTRY");
            entity.Property(e => e.Firstname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Studentname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("STUDENTNAME");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__USER__CB9A1CDF12399D42");

            entity.ToTable("USER");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Firstname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PHONENUMBER");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__CD3149ACA16967A4");

            entity.ToTable("UserRole");

            entity.Property(e => e.UserRoleId).HasColumnName("userRoleID");
            entity.Property(e => e.UsId).HasColumnName("UsID");
            entity.Property(e => e.UsRid).HasColumnName("UsRID");

            entity.HasOne(d => d.Us).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UsId)
                .HasConstraintName("UsId_FK");

            entity.HasOne(d => d.UsR).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UsRid)
                .HasConstraintName("USrid_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

 

    

    
}
