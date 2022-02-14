using Cadastro_Pessoa.Interfaces;

namespace Cadastro_Pessoa.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {

        public string CPF { get; set; }
        public string DataNasc { get; set; }

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
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return 
@$"Nome: {Nome}.
CPF: {CPF}.
Endereço: {Endereco.Logradouro} {Endereco.Numero}.
Data Nascimento: {DataNasc}.
Rendimento: R$ {Rendimento:0.00}.
";
        }
    }
}