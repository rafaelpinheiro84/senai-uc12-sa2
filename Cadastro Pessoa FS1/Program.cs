﻿using Cadastro_Pessoa_FS1.Classes;


Console.WriteLine(@$"
=========================================================
|           Bem vindo ao sistema de cadastro de         |
|               Pessoas Físicas e Jurídicas             |
=========================================================
");

BarraCarregamento("Carregando ");

List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
=========================================================
|             Escolha uma das opções abaixo             |
|-------------------------------------------------------|
|             1 - Pessoa Física                         |
|             2 - Pessoa Jurídica                       |
|                                                       |
|             0 - Sair                                  |
=========================================================
");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            PessoaFisica metodoPf = new PessoaFisica();
            string? opcaoPf;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=========================================================
|             Escolha uma das opções abaixo             |
|-------------------------------------------------------|
|             1 - Cadastrar Pessoa Física               |
|             2 - Mostrar Pessoas Físicas               |
|                                                       |
|             0 - Voltar ao menu anterior               |
=========================================================
");
                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1":
                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco novoEnd = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar: ");
                        novaPf.nome = Console.ReadLine();

                        bool dataValida;
                        do
                        {

                            Console.WriteLine($"Digite a data de nascimento Ex: DD/MM/AAAA");
                            string dataNasc = Console.ReadLine();

                            dataValida = metodoPf.ValidarDataNascimento(dataNasc);

                            if (dataValida)
                            {
                                novaPf.dataNascimento = dataNasc;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data digitada inválida, por favor digite uma data válida");
                                Console.ResetColor();
                            }

                        } while (dataValida == false);

                        Console.WriteLine($"Digite o número do CPF ");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (digite somente números)");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o numero");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (aperte 'ENTER' para vazio");
                        novoEnd.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEnd.endComercial = true;
                        }
                        else
                        {
                            novoEnd.endComercial = false;
                        }

                        novaPf.endereco = novoEnd;

                        listaPf.Add(novaPf);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso");
                        Console.ResetColor();

                        Thread.Sleep(3000);
                        break;

                    case "2":

                        Console.Clear();

                        if (listaPf.Count > 0)
                        {

                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                Console.WriteLine(@$"
Nome: {cadaPessoa.nome}
Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero}
Data de nascimento: {cadaPessoa.dataNascimento}
Taxa de imposto a ser paga é: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")}
");
                            }
                            Console.WriteLine($"Aperte 'Enter' para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine($"Lista vazia!!");
                            Thread.Sleep(3000);
                        }

                        break;

                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digite outra opção");
                        Thread.Sleep(2000);
                        break;
                }

            } while (opcaoPf != "0");

            break;

        case "2":
            PessoaJuridica metodoPj = new PessoaJuridica();

            string? opcaoPj;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=========================================================
|             Escolha uma das opções abaixo             |
|-------------------------------------------------------|
|             1 - Cadastrar Pessoa Jurídica             |
|             2 - Mostrar Pessoas Jurídicas             |
|                                                       |
|             0 - Voltar ao menu anterior               |
=========================================================
");
                opcaoPj = Console.ReadLine();

                switch (opcaoPj)
                {
                    case "1":
                        PessoaJuridica novaPj = new PessoaJuridica();
                        Endereco novoEndPj = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa jurídica que deseja cadastrar:");
                        novaPj.nome = Console.ReadLine();

                        bool cnpjValido;
                        do
                        {
                            Console.WriteLine($"Digite o CNPJ: ");
                            string cnpj = Console.ReadLine();

                            cnpjValido = metodoPj.ValidarCnpj(cnpj);

                            if (cnpjValido)
                            {
                                novaPj.cnpj = cnpj;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"CNPJ inválido, por favor digite um CNPJ válido. Ex: 00.000.000/0001-00");
                                Console.ResetColor();
                            }

                        } while (cnpjValido == false);

                        Console.WriteLine($"Digite a Razão Social: ");
                        novaPj.razaoSocial = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento. (Somente números)");

                        novaPj.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro:");
                        novoEndPj.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número: ");
                        novoEndPj.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (aperte 'ENTER' para vazio");
                        novoEndPj.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEndPj.endComercial = true;
                        }
                        else
                        {
                            novoEndPj.endComercial = false;
                        }

                        novaPj.endereco = novoEndPj;

                        listaPj.Add(novaPj);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        break;

                    case "2":
                        Console.Clear();

                        if (listaPj.Count > 0)
                        {

                            foreach (PessoaJuridica cadaPessoa in listaPj)
                            {
                                Console.WriteLine(@$"
Nome: {cadaPessoa.nome}
Razão Social: {cadaPessoa.razaoSocial}
CNPJ: {cadaPessoa.cnpj}
Taxa de imposto a ser paga é: {metodoPj.PagarImposto(cadaPessoa.rendimento).ToString("C")}
");
                            }
                            Console.WriteLine($"Aperte 'Enter' para continuar");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine($"Lista vazia!!");
                            Thread.Sleep(3000);
                        }
                        break;

                    case "0":
                        //sair
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digite outra opção");
                        Thread.Sleep(2000);
                        break;
                }

            } while (opcaoPj != "0");
            
            break;

        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema");

            BarraCarregamento("Finalizando ", 300);

            break;

        default:
            Console.Clear();
            Console.WriteLine($"Opção inválida, por favor digite outra opção");
            Thread.Sleep(2000);
            break;
    }

} while (opcao != "0");


static void BarraCarregamento(string mensagem, int tempoEmMs = 500)
{
    Console.BackgroundColor = ConsoleColor.DarkCyan;
    Console.ForegroundColor = ConsoleColor.Red;

    Console.Write($"{mensagem}");

    for (var contador = 0; contador < 10; contador++)
    {
        Console.Write(". ");
        Thread.Sleep(tempoEmMs);
    }

    Console.ResetColor();

}

