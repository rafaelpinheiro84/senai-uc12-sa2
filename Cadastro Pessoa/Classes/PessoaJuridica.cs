using System.Text.RegularExpressions;
using Cadastro_Pessoa.Interfaces;

namespace Cadastro_Pessoa.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {

        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public PessoaJuridica(string cnpj, string razaoSocial ,string nome, Endereco endereco, decimal rendimento) : base(nome, endereco, rendimento)
        {
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
        }
        
        public PessoaJuridica()
        {

        }
        public override decimal PagarImposto(decimal rendimento)
        {
            throw new NotImplementedException();
        }

        public bool ValidarCNPJ(string cnpj)
        {
            if(Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {
                if(cnpj.Length == 18)
                {
                    if(cnpj.Substring(11, 4) == "0001")
                    {
                        return true;
                    }
                }
                else if(cnpj.Length == 14)
                {
                    if(cnpj.Substring(8, 4) == "0001")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            return 
@$"Nome: {Nome}.
CNPJ: {CNPJ}.
Razão Social: {RazaoSocial}.
Endereço: {Endereco.Logradouro} {Endereco.Numero}.
Rendimento: R$ {Rendimento:0.00}.
";
        }
        
    }
}