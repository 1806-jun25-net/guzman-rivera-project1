using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassLibrary1
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:guzman-rivera-1806.database.windows.net,1433;Initial Catalog=PizzaPalacedb;Persist Security Info=False;User ID=angelluis;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
                entity.HasKey(e => e.Transactions);

                entity.ToTable("Orders", "Pizzeria");

                entity.Property(e => e.DateTimeOrder)
                    .HasColumnName("DateTime_order")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.Size)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.HasOne(d => d.LocationsNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Locations)
                    .HasConstraintName("FK_OrderLocTOlocID");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK_OrderPizzaTOPizzaID");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizzeria");

                entity.Property(e => e.PizzaId).HasColumnName("Pizza_id");

                entity.Property(e => e.Bacon).HasColumnName("bacon");

                entity.Property(e => e.Cheese).HasColumnName("cheese");

                entity.Property(e => e.Chiken).HasColumnName("chiken");

                entity.Property(e => e.Chorizo).HasColumnName("chorizo");

                entity.Property(e => e.Doug).HasColumnName("doug");

                entity.Property(e => e.Onion).HasColumnName("onion");

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
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "Pizzeria");

                entity.Property(e => e.UsersId).HasColumnName("Users_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Names)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.UsersLocation)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_userLocTOlocID");

                entity.HasOne(d => d.TransactionsNavigation)
                    .WithMany(p => p.UsersTransactionsNavigation)
                    .HasForeignKey(d => d.Transactions)
                    .HasConstraintName("FK_userTranTOOrderTran");
            });
        }
    }
}
