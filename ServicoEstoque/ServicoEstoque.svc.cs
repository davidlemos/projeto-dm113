using EstoqueProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EstoqueEntityModel;
using System.ServiceModel.Activation;


namespace EstoqueProduto {

    // WCF service that implements the service contract
    // This implementation performs minimal error checking and exception handling
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicoEstoque : IServicoEstoque, IServicoEstoqueV2
    {
        public List<string> ListarProdutos()
        {
            List<string> listaProdutos = new List<String>();

            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {

                    List<ProdutoEstoque> produtosEstoque = (from produto in database.ProdutoEstoques
                                                            select produto).ToList();

                    foreach (ProdutoEstoque p in produtosEstoque)
                    {
                        listaProdutos.Add(p.NomeProduto);
                    }
                }
            }
            catch
            {
            }
            return listaProdutos;
        }

        public bool IncluirProduto(Produto produto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {

                    ProdutoEstoque produtoEstoque = new ProdutoEstoque();

                    produtoEstoque.NumeroProduto = produto.NumeroProduto;
                    produtoEstoque.NomeProduto = produto.NomeProduto;
                    produtoEstoque.DescricaoProduto = produto.DescricaoProduto;
                    produtoEstoque.EstoqueProduto = produto.EstoqueProduto;

                    database.ProdutoEstoques.Add(produtoEstoque);
                    database.SaveChanges();

                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool RemoverProduto(string numeroProduto)
        {
            try
            {

                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    database.ProdutoEstoques.Remove(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public int ConsultarEstoque(string numeroProduto)
        {

            int qtd = 0;

            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    qtd = produtoEstoque.EstoqueProduto;

                }
            }
            catch
            {
            }

            return qtd;
        }

        public bool AdicionarEstoque(string numeroProduto, int quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    produtoEstoque.EstoqueProduto = produtoEstoque.EstoqueProduto + quantidade;
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool RemoverEstoque(string numeroProduto, int quantidade)
        {
            try
            {

                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    produtoEstoque.EstoqueProduto = produtoEstoque.EstoqueProduto - quantidade;
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public Produto VerProduto(string numeroProduto)
        {

            Produto produto = null;

            try
            {

                using (ProvedorEstoque database = new ProvedorEstoque())
                {

                    ProdutoEstoque produtoEstoque = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    produto = new Produto()
                    {
                        NumeroProduto = produtoEstoque.NumeroProduto,
                        NomeProduto = produtoEstoque.NomeProduto,
                        DescricaoProduto = produtoEstoque.DescricaoProduto,
                        EstoqueProduto = produtoEstoque.EstoqueProduto
                    };
                }
            }
            catch
            {
            }

            return produto;
        }
    }
}
