using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OrderItemDetailsAPI.Models
{
    public partial class OrderItemDetailsAPIContext : DbContext
    {
        public OrderItemDetailsAPIContext()
        {
        }

        public OrderItemDetailsAPIContext(DbContextOptions<OrderItemDetailsAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderItemDetail> OrderItemDetails { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<OrderItemDetail>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.ToppingId })
                    .HasName("PK__OrderIte__3C9EAF25821F4CBA");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
