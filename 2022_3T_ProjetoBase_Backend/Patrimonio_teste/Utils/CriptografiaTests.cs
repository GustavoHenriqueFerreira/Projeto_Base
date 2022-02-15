using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patrimonio_teste.Utils
{
    public class CriptografiaTests
    {
        [Fact]
        public void Deve_Retornar_Hash_Em_BCrypt()
        {
            // Pré-Condição
            var senha = Criptografia.GerarHash("123456789");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");

            // Procedimento
            var retorno = regex.IsMatch(senha);

            // Resultado
            Assert.True(retorno);
        }
        
        [Fact]
        public void DeveCompararComparacaoValida()
        {
            // Pré-Condição
            var senha = "123456789";
            var hash = "$2a$11$OpX8HFECSF8oFwgKKvP0H.HlkKpCjcHOs294yO/gKQICuuYNX5RR2";

            // Procedimento
            var comparacao = Criptografia.Comparar(senha, hash);

            // Resultado
            Assert.True(comparacao);
        }


    }
}
