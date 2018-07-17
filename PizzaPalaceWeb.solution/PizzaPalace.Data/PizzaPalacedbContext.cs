using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaPalace.Data
{
    public partial class PizzaPalacedbContext : DbContext
    {
        public PizzaPalacedbContext()
        {
        }

        public PizzaPalacedbContext(DbContextOptions<PizzaPalacedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("Locations", "Pizzeria");

                entity.Property(e => e.LocationsId)
                    .HasColumnName("locations_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bacon).HasColumnName("bacon");

                entity.Property(e => e.Cheese).HasColumnName("cheese");

                entity.Property(e => e.Chiken).HasColumnName("chiken");

                entity.Property(e => e.Chorizo).HasColumnName("chorizo");

                entity.Property(e => e.Doug).HasColumnName("doug");

                entity.Property(e => e.Locations1)
                    .HasColumnName("Locations")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Onion).HasColumnName("onion");

                entity.Property(e => e.Pepperoni).HasColumnName("pepperoni");

                entity.Property(e => e.Sauce).HasColumnName("sauce");

                entity.Property(e => e.Sausage).HasColumnName("sausage");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Orders", "Pizzeria");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.DateTimeOrder)
                    .HasColumnName("DateTime_order")
                    .HasColumnType("datetime");

                entity.Property(e => e.LocationsIdfk).HasColumnName("LocationsIDFK");

                entity.Property(e => e.UserIdfk).HasColumnName("UserIDFK");

                entity.HasOne(d => d.LocationsIdfkNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LocationsIdfk)
                    .HasConstraintName("FK_LocID");

                entity.HasOne(d => d.UserIdfkNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserIdfk)
                    .HasConstraintName("FK_USERID");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizzeria");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.Bacon).HasColumnName("bacon");

                entity.Property(e => e.Cheese).HasColumnName("cheese");

                entity.Property(e => e.Chiken).HasColumnName("chiken");

                entity.Property(e => e.Chorizo).HasColumnName("chorizo");

                entity.Property(e => e.Doug).HasColumnName("doug");

                entity.Property(e => e.Onion).HasColumnName("onion");

                entity.Property(e => e.OrdersIdfk).HasColumnName("OrdersIDFK");

                entity.Property(e => e.Pepperoni).HasColumnName("pepperoni");

                entity.Property(e => e.Pizza1)
                    .HasColumnName("Pizza")
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Sauce).HasColumnName("sauce");

                entity.Property(e => e.Sausage).HasColumnName("sausage");

                entity.Property(e => e.Size)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrdersIdfkNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.OrdersIdfk)
                    .HasConstraintName("FK__Pizza__OrdersIDF__09A971A2");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "Pizzeria");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DefaultLocationFk).HasColumnName("Default_LocationFK");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.HasOne(d => d.DefaultLocationFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DefaultLocationFk)
                    .HasConstraintName("FK_DEFLOC");
            });
        }
    }
}
