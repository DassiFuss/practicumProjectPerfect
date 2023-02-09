using Microsoft.EntityFrameworkCore;
using Properties;
using Properties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DBContext
{
    public partial class MyDBContext : DbContext,IContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<Hmo> Hmos { get; set; }

        //public virtual DbSet<Sex> Sexes { get; set; }

        //public virtual DbSet<Status> Statuses { get; set; }

        public virtual DbSet<User> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=ZIPCOM-67856\\MS55;Initial Catalog=User;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hmo>(entity =>
            {
                entity.HasKey(e => e.IdHmo);

                entity.ToTable("HMO");

                entity.Property(e => e.IdHmo).HasColumnName("idHMO");
                entity.Property(e => e.Hmo1)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasColumnName("HMO");
            });

            modelBuilder.Entity<Sex>(entity =>
            {
                entity.HasKey(e => e.IdSex);

                entity.ToTable("Sex");

                entity.Property(e => e.IdSex).HasColumnName("idSex");
                entity.Property(e => e.Sex1)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasColumnName("sex");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.ToTable("Status");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");
                entity.Property(e => e.Status1)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasColumnName("status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("idUser");
                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birthDate");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");
                entity.Property(e => e.Id)
                    .HasMaxLength(9)
                    .IsFixedLength()
                    .HasColumnName("id");
                entity.Property(e => e.IdFamily)
                    .HasMaxLength(9)
                    .IsFixedLength()
                    .HasColumnName("idFamily");
                entity.Property(e => e.IdHmo).HasColumnName("idHMO");
                entity.Property(e => e.IdSex).HasColumnName("idSex");
                entity.Property(e => e.IdStatus).HasColumnName("idStatus");
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.HasOne(d => d.IdHmoNavigation).WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdHmo)
                    .HasConstraintName("FK_User_HMO");

                entity.HasOne(d => d.IdSexNavigation).WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdSex)
                    .HasConstraintName("FK_User_Sex");

                entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_User_Status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}

