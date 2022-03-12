using Cadastro_Pessoa_FS1.Interfaces;

namespace Cadastro_Pessoa_FS1.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? cpf { get; set; }
        public string? dataNascimento { get; set; }
        public string caminho { get; private set; } = "Database/PessoaFisica.csv";
        
        
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
        
        public void Inserir(PessoaFisica pf)
        {
            VerificarPastaArquivo(caminho);

            string[] pfString = { $"{pf.nome},{pf.cpf},{pf.dataNascimento},{pf.rendimento}" };
            
            File.AppendAllLines(caminho, pfString);
            
        }

        public List<PessoaFisica> Ler()
        {
            VerificarPastaArquivo(caminho);
            
            List<PessoaFisica> listaPf = new List<PessoaFisica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach( string cadaLinha in linhas )
            {
                string[] atributos = cadaLinha.Split(",");


                PessoaFisica cadaPf = new PessoaFisica();

                cadaPf.nome = atributos[0];
                cadaPf.cpf = atributos[1];
                cadaPf.dataNascimento = atributos[2];
                cadaPf.rendimento = int.Parse(atributos[3]);
                
                listaPf.Add(cadaPf);
            }

            return listaPf;
        }
    }
}