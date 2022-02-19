using System;
using Cadastro_Pessoa.Classes;


Console.WriteLine(@"
=========================================================
|                 BEM-VINDO AO SISTEMA!!!               |
|                                                       |
|      CADASTRO de Pessoa Física e Pessoa Jurídica      | 
=========================================================  
 ");


Esperar("Carregando ", 500);

List<PessoaFisica> pessoasFisicas = new List<PessoaFisica>();
List<PessoaJuridica> pessoaJuridicas = new List<PessoaJuridica>();

string opcao;
do
{
    Console.Clear();
    Thread.Sleep(500);
    opcao = MostrarMenu();

    switch (opcao)
    {
        case "1":
            pessoasFisicas.Add(CadastrarPessoaFisica());
            Console.WriteLine("Cadastro criado com sucesso!");
            Console.WriteLine("Aperte 'Enter' para voltar ao menu novamente, ou '0' para sair ");
            opcao = Console.ReadLine();
            break;

        case "2":
            pessoaJuridicas.Add(CadastrarPessoaJuridica());
            Console.WriteLine("Cadastro criado com sucesso!");
            Console.Write("Aperte 'Enter' para voltar ao menu novamente, ou digite '0' para sair: ");
            opcao = Console.ReadLine();
            break;
        
        case "3":
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Listando o nome das pessoas físicas já cadastradas");
            Console.ResetColor();

            Esperar("", 200);
            
            foreach (var pessoa in pessoasFisicas)
            {
                Console.WriteLine($"Nome: {pessoa.Nome}\n");
            }

            Console.Write("Aperte 'Enter' para voltar ao menu novamente, ou digite '0' para sair: ");
            opcao = Console.ReadLine();
            break;

        case "4":
            Console.WriteLine("Listando o nome e razao social das pessoas juridicas já cadastradas");

            foreach (var pessoa in pessoaJuridicas)
            {
                Console.WriteLine($"Nome: {pessoa.Nome}");
                Console.WriteLine($"Razao Social: {pessoa.RazaoSocial}\n");
            }

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


static void CriarArquivoComDados(string nome, string dadosPraGravar)
{
    string nomeArquivo = nome;

    string path = Environment.CurrentDirectory + $"\\{nomeArquivo}.txt";

    StreamWriter sw = File.CreateText(path);

    sw.Write(dadosPraGravar);
    sw.Flush();
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


static PessoaFisica CadastrarPessoaFisica()
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


    return new PessoaFisica(cpf, dataNasc, nome, new Endereco(logradouro, numero), rendimento);
}

static PessoaJuridica CadastrarPessoaJuridica()
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


    return new PessoaJuridica(cnpj, razaoSocial, nome, new Endereco(logradouro, numero), rendimento);
}

// static void ListarPessoasFisicasCadastradas()
// {
//     foreach(PessoaFisica pessoa in pessoasFisicas)
// }

// PessoaFisica pessoaPF = new PessoaFisica("12.345.678-90", "01/01/2000", "Handryo",
//                                           new Endereco("125 26 D St - Jumeirah,  Dubai - Emirados Árabes Unidos", 5013550,"Confia", false), 1500.5M);

// Console.WriteLine(pessoaPF.ToString());
// Console.WriteLine($"Maior de idade: {pessoaPF.ValidarDataNascimento(pessoaPF.DataNasc)}");
// Console.WriteLine();

// PessoaJuridica metodoPj = new PessoaJuridica();            
// PessoaJuridica pessoaPJ = new PessoaJuridica("00.000.000/0001-00", "Senai Razao Social", "Senai SP",
//                                             new Endereco("Alameda Barão de Limeira",539,"SENAI Informatica", true),
//                                             150000.5M);

// Console.WriteLine(pessoaPJ.ToString());

// Console.WriteLine($"CNPJ válido: {metodoPj.ValidarCNPJ("00.000.000/0001-00")}");

// string dadosPF = pessoaPF.ToString();
// CriarArquivoComDados(pessoaPF.Nome, dadosPF);

// string dadosPJ = pessoaPJ.ToString();
// CriarArquivoComDados(pessoaPJ.Nome, dadosPJ);


