using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Cliente2.ServicoEstoqueV2;

namespace ClienteV2 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();

            // Create a proxy object and connect to the service
            ServicoEstoqueV2Client proxy = new ServicoEstoqueV2Client("WS2007HttpBinding_IServicoEstoque");

            Console.WriteLine("Test 1: Verificar o estoque atual do Produto 1");
            int qtd = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Qtd estoque do produto é: {0}", qtd);
            Console.WriteLine();

            Console.WriteLine("Test 2: Adicionar 20 unidades para o produto 1");
            if (proxy.AdicionarEstoque("1000", 20)) {                
                Console.WriteLine("O estoque foi incremetado com sucesso.");
            }
            else {
                Console.WriteLine("Opss! Ocorreu um erro ao incrementar o estoque.");
            }               
            Console.WriteLine();

            Console.WriteLine("Test 3: Verificar o estoque do Produto 1 novamente");
            qtd = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Qtd estoque do produto é: {0}", qtd);
            Console.WriteLine();

            Console.WriteLine("Teste 4: Verificar o estoque atual do Produto 5");
            qtd = proxy.ConsultarEstoque("5000");
            Console.WriteLine("Qtd estoque do produto é: {0}", qtd);
            Console.WriteLine();

            Console.WriteLine("Teste 5: Remover 10 unidades do Produto 5");
            if (proxy.RemoverEstoque("5000", 10)) {
                Console.WriteLine("O estoque foi removido com sucesso.");
            }
            else
            {
                Console.WriteLine("Opss! Ocorreu um erro ao remover o estoque.");
            }
            Console.WriteLine();

            Console.WriteLine("Teste 6: Verificar o estoque do Produto 5 novamente");
            qtd = proxy.ConsultarEstoque("5000");
            Console.WriteLine("Qtd estoque do produto é: {0}", qtd);
            Console.WriteLine();

            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
