/*using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventTicketBookingPlatform.Models
{
    public partial class finalContext : DbContext
    {
        public finalContext()
        {
        }

       // public finalContext(DbContextOptions<finalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Eevent> Eevents { get; set; } = null!;
        public virtual DbSet<EeventOrganizer> EeventOrganizers { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-47I364R;Database=final;User Id=DESKTOP-47I364R\\User;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eevent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__EEvents__2370F7275C29EF88");

                entity.ToTable("EEvents");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.EventDate)
                    .HasColumnType("date")
                    .HasColumnName("event_date");

                entity.Property(e => e.EventDescription)
                    .HasColumnType("text")
                    .HasColumnName("event_description");

                entity.Property(e => e.EventLocation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("event_location");

                entity.Property(e => e.EventTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("event_title");
            });

            modelBuilder.Entity<EeventOrganizer>(entity =>
            {
                entity.HasKey(e => e.OrganizerId)
                    .HasName("PK__EEvent_o__06347014F0F008FC");

                entity.ToTable("EEvent_organizers");

                entity.Property(e => e.OrganizerId)
                    .ValueGeneratedNever()
                    .HasColumnName("organizer_id");

                entity.Property(e => e.ContactInformation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("contact_information");

                entity.Property(e => e.NameOrganization)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Name_organization");

                entity.HasOne(d => d.Organizer)
                    .WithOne(p => p.EeventOrganizer)
                    .HasForeignKey<EeventOrganizer>(d => d.OrganizerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EEvent_or__organ__3F466844");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId)
                    .ValueGeneratedNever()
                    .HasColumnName("ticket_id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.TicketPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("ticket_price");

                entity.Property(e => e.TicketStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ticket_status");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Tickets__event_i__3B75D760");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__Tickets__userid__3C69FB99");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}*/
