namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacao_do_Banco : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProdutoEstoques", "NumeroProduto", c => c.String());
            AlterColumn("dbo.ProdutoEstoques", "NomeProduto", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProdutoEstoques", "NomeProduto", c => c.String(nullable: false));
            AlterColumn("dbo.ProdutoEstoques", "NumeroProduto", c => c.String(nullable: false));
        }
    }
}
