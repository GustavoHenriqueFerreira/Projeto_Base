using Patrimonio.Domains;
using Xunit;

namespace Patrimonio_teste.Domains
{
    public class UsuarioDomainTests
    {
        [Fact] // Descrição
        public void DeveRetornarUsuarioPreenchido() //Teste unitário
        {

            // Pré-Condição / Arrange
            Usuario usuario = new Usuario();
            usuario.Email = "gustavo@gmail.com";
            usuario.Senha = "123456789";

            // Procedimento / Act
            bool resultado = true;

            if(usuario.Senha == null || usuario.Email == null)
            {
                resultado = false;
            }

            // Resultado / Assert
            Assert.True(resultado);
        }
    
    }
}
