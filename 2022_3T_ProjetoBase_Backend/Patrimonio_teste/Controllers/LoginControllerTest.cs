using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using Xunit;

namespace Patrimonio_teste.Controllers
{
    public class LoginControllerTest
    {
        [Fact]
        public void DeveRetornarUmUsuarioInvalido() //Teste de integração
        {
            // Pré-Condição
            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "gustavo@gmail.com";
            loginViewModel.Senha = "123456789";

            var controller = new LoginController(fakeRepository.Object);

            // Procedimento
            var resultado = controller.Login(loginViewModel);

            // Resultado
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void DeveRetornarUmUsuarioValido() //Teste de integração
        {
            // Pré-Condição
            var fakeUsuario = new Usuario();
            fakeUsuario.Email = "gustavo@gmail.com";
            fakeUsuario.Senha = "$2a$11$OpX8HFECSF8oFwgKKvP0H.HlkKpCjcHOs294yO/gKQICuuYNX5RR2";

            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(fakeUsuario);

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "gustavo@gmail.com";
            loginViewModel.Senha = "123456789";

            var controller = new LoginController(fakeRepository.Object);

            // Procedimento
            var resultado = controller.Login(loginViewModel);

            // Resultado
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
