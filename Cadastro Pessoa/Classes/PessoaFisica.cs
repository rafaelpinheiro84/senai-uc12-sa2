using Cadastro_Pessoa.Interfaces;

namespace Cadastro_Pessoa.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {

        public string CPF { get; set; }
        public string DataNasc { get; set; }

        public PessoaFisica()
        {
            
        }
        public PessoaFisica(string cpf, string dataNasc, string nome, Endereco endereco, decimal rendimento)
         : base(nome, endereco, rendimento)
        {
            CPF = cpf;
            DataNasc = dataNasc;
        }
        public bool ValidarDataNascimento(DateTime dataNasc)
        {   
            DateTime dataAtual = DateTime.Today;
            double anos = (dataAtual - dataNasc).TotalDays / 365;

            if( anos >= 18)
            {
                return true;
            }

            return false;        
        }

        public bool ValidarDataNascimento(string dataNasc) // Sobrecarga 
        {   
            // poderia usar a biblioteca Humanize junto com a classe TimeSpan
            DateTime dataConvertida;
            if( DateTime.TryParse(dataNasc, out dataConvertida))
            {
                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConvertida).TotalDays / 365;
                if( anos >= 18)
                {
                    return true;
                }
                return false;
            }
            return false;

                    
        }

        public override decimal PagarImposto(decimal rendimento)
        {
            decimal desconto = 0;
            if(rendimento <= 1500M)
            {
                desconto = 0;
            }
            else if(rendimento <= 3500M)
            {
                desconto =  0.02M;
            }
            else if(rendimento <= 6000M)
            {
                desconto =  0.035M;
            }
            else
            {
                desconto =  0.05M;
            }
            return rendimento * desconto;
        }

        public override string ToString()
        {
            return 
@$"Nome: {Nome}.
CPF: {CPF}.
Maior de idade: {(ValidarDataNascimento(DataNasc) ? "Sim" : "Não")}.
Endereço: {Endereco.Logradouro} {Endereco.Numero}.
Data Nascimento: {DataNasc}.
Rendimento: R$ {Rendimento:0.00}.
Taxa de imposto a ser paga é R$ {PagarImposto(Rendimento):0.00}.
";
        }
    }
}