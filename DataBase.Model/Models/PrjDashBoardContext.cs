﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Model.Models;

public partial class PrjDashBoardContext : DbContext
{
    public PrjDashBoardContext()
    {
    }

    public PrjDashBoardContext(DbContextOptions<PrjDashBoardContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PARTHIBAN;Initial Catalog=PrjDashBoard; Trusted_Connection=True; Trustservercertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("country");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Iso)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Iso3)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.NiceName)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Manager");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ManagerName).HasMaxLength(50);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Project");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ProjectCode).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserInfo");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
