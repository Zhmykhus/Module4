using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Module4.DB;

public partial class Module2Context : DbContext
{
    public Module2Context()
    {
    }

    public Module2Context(DbContextOptions<Module2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Object> Objects { get; set; }

    public virtual DbSet<ObjectClient> ObjectClients { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=Dikyiyaz12122005;database=module2", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("client");

            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Patronymic).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Object>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("object");

            entity.HasIndex(e => e.CategoryId, "FK_object_category_Id");

            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CategoryId).HasColumnName("Category_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");

            entity.HasOne(d => d.Category).WithMany(p => p.Objects)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_object_category_Id");
        });

        modelBuilder.Entity<ObjectClient>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("object_client");

            entity.HasIndex(e => e.ClientId, "FK_object_client_client_Id");

            entity.HasIndex(e => e.ObjectId, "FK_object_client_object_Id");

            entity.HasIndex(e => e.StatusId, "FK_object_client_status_Id");

            entity.Property(e => e.ClientId).HasColumnName("Client_id");
            entity.Property(e => e.Cost).HasPrecision(19, 2);
            entity.Property(e => e.FinishDate)
                .HasColumnType("datetime")
                .HasColumnName("Finish_date");
            entity.Property(e => e.FirstDate)
                .HasColumnType("datetime")
                .HasColumnName("First_date");
            entity.Property(e => e.ObjectId).HasColumnName("Object_id");
            entity.Property(e => e.Paid).HasPrecision(10);
            entity.Property(e => e.StatusId).HasColumnName("Status_id");

            entity.HasOne(d => d.Client).WithMany()
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_object_client_client_Id");

            entity.HasOne(d => d.Object).WithMany()
                .HasForeignKey(d => d.ObjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_object_client_object_Id");

            entity.HasOne(d => d.Status).WithMany()
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_object_client_status_Id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.RoleId, "FK_user_role_Id");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.EnterData)
                .HasColumnType("datetime")
                .HasColumnName("Enter_data");
            entity.Property(e => e.LastData)
                .HasColumnType("datetime")
                .HasColumnName("Last_data");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.RoleId).HasColumnName("Role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_role_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
