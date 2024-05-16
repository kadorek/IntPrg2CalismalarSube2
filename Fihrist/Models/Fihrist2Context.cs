using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Fihrist.Models;

public partial class Fihrist2Context : DbContext
{
    public Fihrist2Context()
    {
    }

    public Fihrist2Context(DbContextOptions<Fihrist2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Info> Infos { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<RolMember> RolMembers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=.\\Data\\fihrist2.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Info>(entity =>
        {
            entity.ToTable("Info");

            entity.HasOne(d => d.Person).WithMany(p => p.Infos)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Type).WithMany(p => p.Infos)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");
        });

        modelBuilder.Entity<RolMember>(entity =>
        {
            entity.ToTable("RolMember");

            entity.HasOne(d => d.Member).WithMany(p => p.RolMembers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Role).WithMany(p => p.RolMembers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.ToTable("Type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
