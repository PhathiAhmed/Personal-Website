using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Personal.Models
{
    public partial class personaldpContext : DbContext
    {
        public personaldpContext()
        {
        }

        public personaldpContext(DbContextOptions<personaldpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbaboutme> Tbaboutmes { get; set; }
        public virtual DbSet<Tbcontect> Tbcontects { get; set; }
        public virtual DbSet<Tbmywork> Tbmyworks { get; set; }
        public virtual DbSet<Tbservice> Tbservices { get; set; }
        public virtual DbSet<TBslider> Tbsliders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbaboutme>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("TBaboutme");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Dateofbirth).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Freelancer).HasMaxLength(200);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(200);
            });

            modelBuilder.Entity<Tbcontect>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("TBcontect");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Phone).HasMaxLength(200);

                entity.Property(e => e.Skype).HasMaxLength(200);
            });

            modelBuilder.Entity<Tbmywork>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("TBmywork");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.WorkImage)
                    .HasMaxLength(200)
                    .HasColumnName("work_image");

                entity.Property(e => e.WorkName)
                    .HasMaxLength(200)
                    .HasColumnName("work_name");
            });

            modelBuilder.Entity<Tbservice>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("TBservices");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<TBslider>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("TBslider");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
