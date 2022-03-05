using Cadastro_Pessoa_FS1.Classes;


ExibirBemVindo();
BarraCarregamento("Carregando ");
ExibirMenu();

static void ExibirBemVindo(){
    Console.WriteLine(@$"
=========================================================
|           Bem vindo ao sistema de cadastro de         |
|               Pessoas Físicas e Jurídicas             |
=========================================================
");
}

static void ExibirMenu()
{
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
            Console.Clear();
            TerceiroEncontroRemoto();
            Console.WriteLine($"Aperte 'Enter' para continuar");
            Console.ReadLine();
            break;

        case "2":
            Console.Clear();
            QuartoEncontroRemoto();
            Console.WriteLine($"Aperte 'Enter' para continuar");
            Console.ReadLine();
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
}

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

static void TerceiroEncontroRemoto()
{
    PessoaFisica metodoPf = new PessoaFisica();
    PessoaFisica novaPf = new PessoaFisica();
    Endereco novoEnd = new Endereco();

    novaPf.nome = "Odirlei";
    novaPf.dataNascimento = "01/01/2000";
    novaPf.cpf = "1234567890";
    novaPf.rendimento = 1500.5f;

    novoEnd.logradouro = "Alameda Barão de Limeira";
    novoEnd.numero = 539;
    novoEnd.complemento = "SENAI Informática";
    novoEnd.endComercial = true;

    novaPf.endereco = novoEnd;

    bool dataValida = metodoPf.ValidarDataNascimento(novaPf.dataNascimento);

    Console.WriteLine(@$"
Nome: {novaPf.nome}
Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
Maior de idade: {(dataValida ? "Sim" : "Não")}
Taxa de imposto a ser paga é: {metodoPf.PagarImposto(novaPf.rendimento).ToString("C")}
");
}

static void QuartoEncontroRemoto()
{
    PessoaJuridica metodoPj = new PessoaJuridica();
    PessoaJuridica novaPj = new PessoaJuridica();
    Endereco novoEndPj = new Endereco();
    novaPj.nome = "Nome Pj";
    novaPj.cnpj = "00.000.000/0001-00";
    novaPj.razaoSocial = "Razão Social Pj";
    novaPj.rendimento = 8000.5f;
    novoEndPj.logradouro = "Alameda Barão de Limeira";
    novoEndPj.numero = 539;
    novoEndPj.complemento = "SENAI Informatica";
    novoEndPj.endComercial = true;
    novaPj.endereco = novoEndPj;
    Console.WriteLine(@$"
Nome: {novaPj.nome}
Razão Social: {novaPj.razaoSocial}
CNPJ: {novaPj.cnpj}
CNPJ Válido: {(metodoPj.ValidarCnpj(novaPj.cnpj) ? "Sim" : "Não")}
Taxa de imposto a ser paga é: {metodoPj.PagarImposto(novaPj.rendimento).ToString("C")}
");
}
