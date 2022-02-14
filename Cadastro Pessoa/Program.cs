using System;
using Cadastro_Pessoa.Classes;

namespace Cadastro_Pessoa
{
    class Program 
    {
        static void Main( string[] args) {

            PessoaFisica pessoaPF = new PessoaFisica("12.345.678-90", "01/01/2000", "Handryo",
                                                     new Endereco("125 26 D St - Jumeirah,  Dubai - Emirados Árabes Unidos", 5013550,"Confia", false), 1500.5M);

            Console.WriteLine(pessoaPF.ToString());
            Console.WriteLine($"Maior de idade: {pessoaPF.ValidarDataNascimento(pessoaPF.DataNasc)}");
            Console.WriteLine();
            
            PessoaJuridica metodoPj = new PessoaJuridica();            
            PessoaJuridica pessoaPJ = new PessoaJuridica("00.000.000/0001-00", "Senai Razao Social", "Senai SP",
                                                        new Endereco("Alameda Barão de Limeira",539,"SENAI Informatica", true),
                                                        150000.5M);

            Console.WriteLine(pessoaPJ.ToString());

            Console.WriteLine($"CNPJ válido: {metodoPj.ValidarCNPJ("00.000.000/0001-00")}");

            string dadosPF = pessoaPF.ToString();
            CriarArquivoComDados(pessoaPF.Nome, dadosPF);

            string dadosPJ = pessoaPJ.ToString();
            CriarArquivoComDados(pessoaPJ.Nome, dadosPJ);
        }

        static void CriarArquivoComDados(string nome, string dadosPraGravar)
        {
            string nomeArquivo = nome;

            string path = Environment.CurrentDirectory + $"\\{nomeArquivo}.txt";

            StreamWriter sw = File.CreateText(path);

            sw.Write(dadosPraGravar);
            sw.Flush();
        }
    }
}