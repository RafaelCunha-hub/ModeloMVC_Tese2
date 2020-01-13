namespace RC.Teste.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBancoDeDados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Sexo = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 11, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataNascimento = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ClienteId)
                .Index(t => t.Cpf, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clientes", new[] { "Cpf" });
            DropTable("dbo.Clientes");
        }
    }
}
