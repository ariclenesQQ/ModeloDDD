using ModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDDD.Infra.Data.Contexto
{
    public class ModeloDDDContextEF : DbContext
    {
        public ModeloDDDContextEF() : base("ModeloDDD")
        {
            /* Solução para este erro
             * No Entity Framework provider found for the ADO.NET provider with invariant name 'System.Data.SqlClient'
             */
            //This will make the build process include the assembly with the host project
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices); 
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) //Criar BD usando fluent API
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Quando tiver numa tabela o nome da propriedade + Id define como chave primária
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Toda a propriedade de uma tabela do tipo "string" será criada como "varchar" no banco de dados
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            /*
             * Toda a propriedade de uma tabela do tipo "string" terá por padrão o tamanho máximo de 100 carecteres
             * Caso não for definida              
            */
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new EntityConfig.ClienteConfiguration());
            modelBuilder.Configurations.Add(new EntityConfig.ProdutoConfiguration());

            //modelBuilder.Configurations.Add(new Maps.ProdutoMap());
            //modelBuilder.Configurations.Add(new Maps.TipoProdutoMap());
            //modelBuilder.Configurations.Add(new Maps.UsuarioMap());
        }

        //Definindo o valor padrão da data de cadastro das entidades
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
