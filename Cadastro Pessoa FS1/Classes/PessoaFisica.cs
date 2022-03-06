using Cadastro_Pessoa_FS1.Interfaces;

namespace Cadastro_Pessoa_FS1.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? cpf { get; set; }
        public string? dataNascimento { get; set; }

        public bool ValidarDataNascimento(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;

            if(anos >= 18)
            {
                return true;
            }
            
            return false;
        }

        public bool ValidarDataNascimento(string dataNasc)
        {
            DateTime resultado;

            if(DateTime.TryParse(dataNasc, out resultado) == true)
            {
                DateTime dataAtual = DateTime.Today;

                double anos = (dataAtual - resultado).TotalDays / 365;

                if(anos >= 18 && anos < 120)
                {
                    return true;
                }
                
                return false; // não precisa dar retorno aqui
            }
            return false;
        }

        public override float PagarImposto(float rendimento)
        {
            if(rendimento <= 1500)
            {
                return  0;
            }
            else if(rendimento <= 3500)
            {
                return rendimento * 0.02f;
            }
            else if(rendimento <= 6000)
            {
                return rendimento *  0.035f;
            }
            else
            {
                return rendimento *  0.05f;
            }
        }
        
    }
}