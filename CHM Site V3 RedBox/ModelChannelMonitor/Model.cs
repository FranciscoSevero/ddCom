namespace ModelChannelMonitor
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=CHMContext")
        {
        }

        public virtual DbSet<tbl_Auditoria> tbl_Auditoria { get; set; }
        public virtual DbSet<tbl_Email> tbl_Email { get; set; }
        public virtual DbSet<tbl_Gravador> tbl_Gravador { get; set; }
        public virtual DbSet<tbl_Plataforma> tbl_Plataforma { get; set; }
        public virtual DbSet<tbl_Ramal> tbl_Ramal { get; set; }
        public virtual DbSet<tbl_RamalEmAnalise> tbl_RamalEmAnalise { get; set; }
        public virtual DbSet<tbl_RamalVago> tbl_RamalVago { get; set; }
        public virtual DbSet<tbl_Sites> tbl_Sites { get; set; }
        public virtual DbSet<tbl_Status> tbl_Status { get; set; }
        public virtual DbSet<tbl_TipoGravador> tbl_TipoGravador { get; set; }
        public virtual DbSet<tbl_Usuarios> tbl_Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Auditoria>()
                .Property(e => e.acao)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Email>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Email>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Email>()
                .Property(e => e.smtp)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Email>()
                .Property(e => e.porta)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Email>()
                .Property(e => e.copia)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Gravador>()
                .Property(e => e.hostname)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Gravador>()
                .Property(e => e.Ip)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Gravador>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Gravador>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Gravador>()
                .Property(e => e.userfieldExtension)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Gravador>()
                .Property(e => e.PP)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Gravador>()
                .Property(e => e.operacao)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Gravador>()
                .Property(e => e.recorderType)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Plataforma>()
                .Property(e => e.instanciaSql)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Plataforma>()
                .HasMany(e => e.tbl_Gravador)
                .WithRequired(e => e.tbl_Plataforma)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Plataforma>()
                .HasMany(e => e.tbl_Ramal)
                .WithRequired(e => e.tbl_Plataforma)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Ramal>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ramal>()
                .Property(e => e.eventos)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ramal>()
                .Property(e => e.extension)
                .IsUnicode(false);

            

            modelBuilder.Entity<tbl_Status>()
                .HasMany(e => e.tbl_Ramal)
                .WithRequired(e => e.tbl_Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Status>()
                .HasOptional(e => e.tbl_Status1)
                .WithRequired(e => e.tbl_Status2);

            modelBuilder.Entity<tbl_TipoGravador>()
                .HasMany(e => e.tbl_Gravador)
                .WithRequired(e => e.tbl_TipoGravador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Usuarios>()
                .Property(e => e.nome_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Usuarios>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Usuarios>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Usuarios>()
                .Property(e => e.nivel)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Usuarios>()
                .HasMany(e => e.tbl_Auditoria)
                .WithRequired(e => e.tbl_Usuarios)
                .WillCascadeOnDelete(false);
        }
    }
}
