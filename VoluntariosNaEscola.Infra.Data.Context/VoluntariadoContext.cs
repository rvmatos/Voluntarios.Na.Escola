using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Infra.Data.Context.Mapping;

namespace VoluntariosNaEscola.Infra.Data.Context
{
    public class VoluntariadoContext : DbContext
    {
       

        public VoluntariadoContext()
            :base("VoluntariadoEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Properties()
            //    .Where(p => p.Name == "Id")
            //    .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(255));

            modelBuilder.Properties<DateTime>()
               .Configure(p => p.HasColumnType("datetime2"));

           

           
            modelBuilder.Configurations.Add(new AcaoMap());
            modelBuilder.Configurations.Add(new DiretorMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new EscolaMap());
            modelBuilder.Configurations.Add(new EventoMap());
            modelBuilder.Configurations.Add(new HabilidadeMap());
            modelBuilder.Configurations.Add(new SupervisorMap());
            modelBuilder.Configurations.Add(new VoluntarioMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new ConviteAprovacaoMap());
            base.OnModelCreating(modelBuilder);


        }

        public override int SaveChanges()
        {

            ChangeTracker.Entries().AsParallel().ForAll(item =>
            {
                var entidade = item.Entity as EntidadeBase;

                if (item.State == EntityState.Added)
                {
                    entidade.DtCriacao = DateTime.Now;
                    entidade.DtAtualizacao = DateTime.Now;
                    entidade.Ativo = true;
                }

                if (item.State == EntityState.Modified)
                {
                    item.Property("DtCriacao").IsModified = false;
                    entidade.DtAtualizacao = DateTime.Now;
                }

                if (item.State == EntityState.Deleted)
                {
                    SoftDelete(item);
                }
            });

            try
            {
                return base.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
           
        }

        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<Supervisor> Supervisores { get; set; }
        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<ConviteAprocao> ConvitesAprovacoes { get; set; }


        private static Dictionary<Type, EntitySetBase> _mappingCache = new Dictionary<Type, EntitySetBase>();

        private string GetTableName(Type type)
        {
            EntitySetBase es = GetEntitySet(type);

            return string.Format("[{0}].[{1}]",
                es.MetadataProperties["Schema"].Value,
                es.MetadataProperties["Table"].Value);
        }

        private string GetPrimaryKeyName(Type type)
        {
            EntitySetBase es = GetEntitySet(type);

            return es.ElementType.KeyMembers[0].Name;
        }

        private EntitySetBase GetEntitySet(Type type)
        {
            if (!_mappingCache.ContainsKey(type))
            {
                ObjectContext octx = ((IObjectContextAdapter)this).ObjectContext;

                string typeName = ObjectContext.GetObjectType(type).Name;

                var es = octx.MetadataWorkspace
                                .GetItemCollection(DataSpace.SSpace)
                                .GetItems<EntityContainer>()
                                .SelectMany(c => c.BaseEntitySets
                                                .Where(e => e.Name == typeName))
                                .FirstOrDefault();

                if (es == null)
                    throw new ArgumentException("Entity type not found in GetTableName", typeName);

                _mappingCache.Add(type, es);
            }

            return _mappingCache[type];
        }

        private void SoftDelete(DbEntityEntry entry)
        {
            lock (Database)
            {
                Type entryEntityType = entry.Entity.GetType();

                string tableName = GetTableName(entryEntityType);
                string primaryKeyName = GetPrimaryKeyName(entryEntityType);

                string sql = string.Format("UPDATE {0} SET Excluido = 1, DtAtualizacao = GetDate() WHERE {1} = ", tableName, primaryKeyName);
                var sqlCmd = sql + " {0} ";

                Database.ExecuteSqlCommand(sqlCmd, entry.OriginalValues[primaryKeyName]);

                entry.State = EntityState.Detached;
            }
        }

    }
}
