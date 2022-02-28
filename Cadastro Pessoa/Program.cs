using System;
using Cadastro_Pessoa.Classes;

var metodoPJ = new PessoaFisica();
Console.WriteLine(metodoPJ.PagarImposto(2500m));
Console.ReadLine();


Console.WriteLine(@"
=========================================================
|                 BEM-VINDO AO SISTEMA!!!               |
|                                                       |
|      CADASTRO de Pessoa Física e Pessoa Jurídica      | 
=========================================================  
 ");


Esperar("Carregando ", 500);

List<PessoaFisica> pessoasFisicas = new List<PessoaFisica>();
List<PessoaJuridica> pessoasJuridicas = new List<PessoaJuridica>();

string opcao;
do
{
    Console.Clear();
    Thread.Sleep(500);
    opcao = MostrarMenu();

    switch (opcao)
    {
        case "1":
            CadastrarPessoaFisica(pessoasFisicas);

            Console.WriteLine("Cadastro criado com sucesso!");

            Console.WriteLine("Aperte 'Enter' para voltar ao menu novamente, ou '0' para sair ");
            opcao = Console.ReadLine();
            break;

        case "2":
            CadastrarPessoaJuridica(pessoasJuridicas);

            Console.WriteLine("Cadastro criado com sucesso!");
            Console.Write("Aperte 'Enter' para voltar ao menu novamente, ou digite '0' para sair: ");
            opcao = Console.ReadLine();
            break;
        
        case "3":
            ListarPessoasFisicas(pessoasFisicas);
            
            Console.Write("Aperte 'Enter' para voltar ao menu novamente, ou digite '0' para sair: ");
            opcao = Console.ReadLine();
            break;

        case "4":
            
            ListarPessoasJuridicas(pessoasJuridicas);

            Console.Write("Aperte 'Enter' para voltar ao menu novamente, ou digite '0' para sair: ");
            opcao = Console.ReadLine();
            break;

        case "5":
            Esperar("Criando arquivo", 300);
            CriarArquivoListaPessoasFisicas("ListaDePessoasFisicas", pessoasFisicas);

            Console.Write("Aperte 'Enter' para voltar ao menu novamente, ou digite '0' para sair: ");
            opcao = Console.ReadLine();
            break;

        case "0":

            Console.WriteLine("Obrigado por usar nosso sistema !!!");
            Esperar("Finalizando ", 300);
            break;

        default:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\nOpção inválida, Aperte 'Enter' para tentar novamente. ");
            Console.ResetColor();
            Console.ReadLine();
            break;
    }

} while (opcao != "0");


// Uma pessoa
static void CriarArquivoComDados(string nome, string dadosPraGravar)
{
    string nomeArquivo = nome;

    string path = Environment.CurrentDirectory + $"\\{nomeArquivo}.txt";

    using StreamWriter sw = File.CreateText(path);

    sw.Write(dadosPraGravar);
    sw.Flush();
}

// Lista de pessoas Fisicas
static void CriarArquivoListaPessoasFisicas(string nomeArquivo, List<PessoaFisica> listaPessoas)
{   
    string path = Environment.CurrentDirectory + $"\\{nomeArquivo}.txt";

    using StreamWriter sw = File.CreateText(path);

    foreach(var pessoa in listaPessoas)
    {
        sw.WriteLine(pessoa);
    }
}

static string MostrarMenu()
{

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(@"
=========================================================
|            Escolha uma das opções abaixo:             |
|                                                       |
|           1 - Cadastro de Pessoa FÍSICA               | 
|           2 - Cadastro de Pessoa JURÍDICA             | 
|           3 - Listar Pessoa Fisica já cadastrada      | 
|           4 - Listar Pessoa Jurídica já cadastrada    | 
|                                                       | 
|           0 - Para SAIR do sistema                    |  
|                                                       | 
=========================================================  
 ");

    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("Digite a opção desejada: ");
    Console.ResetColor();

    return Console.ReadLine();

}

static void Esperar(string mensagem, int tempoMS)
{
    Console.Write(mensagem);
    for (int i = 0; i < 10; i++)
    {
        Console.Write(". ");
        Thread.Sleep(tempoMS);
    }
}


static void CadastrarPessoaFisica(List<PessoaFisica> listaPessoas)
{
    Console.WriteLine("Para o cadastro de pessoa física, por favor!");
    Console.Write("Digite o nome:  ");
    string nome = Console.ReadLine();

    Console.Write("Digite o cpf:  ");
    string cpf = Console.ReadLine();

    Console.Write("Digite a data de nascimento:  ");
    string dataNasc = Console.ReadLine();

    Console.Write("Digite o rendimento:  ");
    decimal rendimento = decimal.Parse(Console.ReadLine());

    Console.Write("Digite o logradouro:  ");
    string logradouro = Console.ReadLine();

    Console.Write("Digite o numero da casa:  ");
    int numero = int.Parse(Console.ReadLine());


    listaPessoas.Add(new PessoaFisica(cpf, dataNasc, nome, new Endereco(logradouro, numero), rendimento));
}

static void CadastrarPessoaJuridica(List<PessoaJuridica> listaPessoas)
{
    Console.WriteLine("Para o cadastro de pessoa jurídica, por favor!");
    Console.Write("Digite o nome:  ");
    string nome = Console.ReadLine();

    Console.Write("Digite a razao social:  ");
    string razaoSocial = Console.ReadLine();

    Console.Write("Digite o cnpj:  ");
    string cnpj = Console.ReadLine();

    Console.Write("Digite o rendimento:  ");
    decimal rendimento = decimal.Parse(Console.ReadLine());

    Console.Write("Digite o logradouro:  ");
    string logradouro = Console.ReadLine();

    Console.Write("Digite o numero da casa:  ");
    int numero = int.Parse(Console.ReadLine());


    listaPessoas.Add(new PessoaJuridica(cnpj, razaoSocial, nome, new Endereco(logradouro, numero), rendimento));
}

static void ListarPessoasFisicas(List<PessoaFisica> listaPessoas)
{   
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("Listando o nome das pessoas físicas já cadastradas");
    Console.ResetColor();

    Esperar("", 200);
    Console.WriteLine($"\n");

    foreach(PessoaFisica pessoa in listaPessoas)
    {
        Console.WriteLine($"Nome: {pessoa.Nome}\n");
    }

}

static void ListarPessoasJuridicas(List<PessoaJuridica> listaPessoas)
{
    Console.WriteLine("Listando o nome e razao social das pessoas juridicas já cadastradas");

    foreach (var pessoa in listaPessoas)
    {
        Console.WriteLine($"Nome: {pessoa.Nome}");
        Console.WriteLine($"Razao Social: {pessoa.RazaoSocial}\n");
    }
}




