using Cadastro_Pessoa.Interfaces;

namespace Cadastro_Pessoa.Classes
{
    public abstract class Pessoa : IPessoa
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public decimal Rendimento { get; set; }
        
        public Pessoa(string nome, Endereco endereco, decimal rendimento)
        {
            Nome = nome;
            Endereco = endereco;
            Rendimento = rendimento;
        }

        public Pessoa()
        {
            
        }
        public abstract decimal PagarImposto(decimal rendimento);
    }
}