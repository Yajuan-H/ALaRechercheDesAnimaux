using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ALaRechercheDesAnimaux.Entities;

public partial class Especes3Context : DbContext
{
    public Especes3Context()
    {
    }

    public Especes3Context(DbContextOptions<Especes3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Espece> Especes { get; set; }

    public virtual DbSet<Observation> Observations { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Especes3;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Espece>(entity =>
        {
            entity.HasIndex(e => e.NomScientifique, "IX_Especes_NomScientifique").IsUnique();

            entity.Property(e => e.NomScientifique).UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasMany(d => d.TagsTags).WithMany(p => p.EspecesEspeces)
                .UsingEntity<Dictionary<string, object>>(
                    "EspeceTag",
                    r => r.HasOne<Tag>().WithMany().HasForeignKey("TagsTagId"),
                    l => l.HasOne<Espece>().WithMany().HasForeignKey("EspecesEspeceId"),
                    j =>
                    {
                        j.HasKey("EspecesEspeceId", "TagsTagId");
                        j.ToTable("EspeceTag");
                        j.HasIndex(new[] { "TagsTagId" }, "IX_EspeceTag_TagsTagId");
                    });
        });

        modelBuilder.Entity<Observation>(entity =>
        {
            entity.HasIndex(e => e.EspeceObserveeEspeceId, "IX_Observations_EspeceObserveeEspeceId");

            entity.Property(e => e.Commentaires).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.EmailObservateur).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NomCommune).UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.EspeceObserveeEspece).WithMany(p => p.Observations).HasForeignKey(d => d.EspeceObserveeEspeceId);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasIndex(e => e.Nom, "IX_Tags_Nom").IsUnique();

            entity.Property(e => e.Nom).UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
