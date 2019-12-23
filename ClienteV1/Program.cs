using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Cliente1.ServicoEstoque;

namespace ClienteV1 {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();

            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");
            Produto produto = new Produto();

            Console.WriteLine("Test 1: Adicionar um produto");
            produto.NumeroProduto = "11000";
            produto.NomeProduto = "Produto 11";
            produto.DescricaoProduto = "Este é o produto 11";
            produto.EstoqueProduto = 10;
            
            if (proxy.IncluirProduto(produto)) {
                Console.WriteLine("O produto foi inserido com sucesso.");
            } else {
                Console.WriteLine("Opss! Ocorreu um erro ao inserir o produto.");
            }
            Console.WriteLine();

            Console.WriteLine("Test 2: Remover produto 10");
            if (proxy.RemoverProduto("10000")) {
                Console.WriteLine("O produto foi removido com sucesso.");
            } else {
                Console.WriteLine("Opss! Ocorreu um erro ao excluir o produto.");
            }
            Console.WriteLine();

            Console.WriteLine("Test 3: Listar todos os produtos");
            List<string> produtos = proxy.ListarProdutos().ToList();
            foreach (string nome in produtos)
            {
                Console.WriteLine("Nome: {0}", nome);
            }
            Console.WriteLine();

            Console.WriteLine("Test 4: Ver informações do produto 2");
            produto = proxy.VerProduto("2000");
            Console.WriteLine("Número do produto: {0}", produto.NumeroProduto);
            Console.WriteLine("Nome do produto: {0}", produto.NomeProduto);
            Console.WriteLine("Descrição do produto: {0}", produto.DescricaoProduto);
            Console.WriteLine("Qtd. Estoque: {0}", produto.EstoqueProduto);
            Console.WriteLine();

            Console.WriteLine("Test 5:  Adicionar 10 unidades para o Produto 2");
            if (proxy.AdicionarEstoque("2000", 10)) {
                Console.WriteLine("O estoque foi incremetado com sucesso.");
            }
            else {
                Console.WriteLine("Opss! Ocorreu um erro ao incrementar o estoque.");
            }
            Console.WriteLine();

            Console.WriteLine("Test 6: Verificar o estoque do Produto 2");
            int qtd = proxy.ConsultarEstoque("2000");
            Console.WriteLine("Qtd estoque do produto é: {0}", qtd);
            Console.WriteLine();

            Console.WriteLine("Test 7: Verificar o estoque atual do Produto 1");
            qtd = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Qtd estoque do produto é: {0}", qtd);
            Console.WriteLine();

            Console.WriteLine("Test 8:  Remover 20 unidades para este produto.");
            if (proxy.RemoverEstoque("1000", 20)) {
                Console.WriteLine("O estoque foi removido com sucesso.");
            }
            else {
                Console.WriteLine("Opss! Ocorreu um erro ao remover o estoque.");
            }
            Console.WriteLine();

           Console.WriteLine("Test 9: Verificar o estoque do Produto 1 novamente.");
            qtd = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Qtd estoque do produto é: {0}", qtd);
            Console.WriteLine();

            Console.WriteLine("Test 10: Verificar todas as informações do Produto 1.");
            produto = proxy.VerProduto("1000");
            Console.WriteLine("Nome: {0}", produto.NomeProduto);
            Console.WriteLine("Descricao: {0}", produto.DescricaoProduto);
            Console.WriteLine("Numero do produto: {0}", produto.NumeroProduto);
            Console.WriteLine("Qtd. Estoque: {0}", produto.EstoqueProduto);
            Console.WriteLine();

            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
