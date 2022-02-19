namespace Cadastro_Pessoa.Classes
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public bool EndComercial { get; set; }
        public Endereco(string logradouro, int numero, string complemento, bool endComercial)
        {
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Complemento = complemento;
            this.EndComercial = endComercial;
        }

        public Endereco(string logradouro, int numero)
        {
            this.Logradouro = logradouro;
            this.Numero = numero;
        }
    }
}