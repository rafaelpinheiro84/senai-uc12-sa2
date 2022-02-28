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
            decimal desconto = 0;

            if(rendimento <= 3000M)
            {
                desconto =  0.03M;
            }
            else if(rendimento <= 6000M)
            {
                desconto = 0.05M;
            }
            else if(rendimento <= 10000M)
            {
                desconto = 0.07M;
            }
            else
            {
                desconto = 0.09M;
            }

            return rendimento * desconto;
        }

        public bool ValidarCNPJ(string cnpj)
        
        {                            //[0-9]{2}.?[0-9]{3}.?[0-9]/?[0-9]{4}-?[0-9]{2}
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
CNPJ Válido: {(ValidarCNPJ(CNPJ) ? "Sim": "Não" )}
Razão Social: {RazaoSocial}.
Endereço: {Endereco.Logradouro} {Endereco.Numero}.
Rendimento: R$ {Rendimento:0.00}.
Taxa de imposto a ser paga é R$ {PagarImposto(Rendimento):0.00}.
";
        }
    }
}