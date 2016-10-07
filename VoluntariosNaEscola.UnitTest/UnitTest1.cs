using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using VoluntariosNaEscola.Domain.Interfaces.Service;
using VoluntariosNaEscola.Infra.CrossCutting.InversionOfControl;

namespace VoluntariosNaEscola.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private IKernel kernel;

        [TestInitialize]
        public void MyTestInitialize()
        {
            var ioc = new IoC();
            kernel = ioc.kernel;
           // kernel.Load(Assembly.GetExecutingAssembly());
            
        }

        [TestMethod]
        public void AddVoluntario()
        {

            var mailSender = kernel.Get<IVoluntarioService>();
            mailSender.Add(new Domain.Entities.Voluntario()
            { 
                Email = "silva.pucrs@gmail.com",
                Nome = "Diego Silva",
                DtNascimento = new System.DateTime(1987, 3, 28),
                Senha = "102030",
                Profissao = "Estudante",
                Telefone = "(51) 85077222",
                Endereco = new Domain.Entities.Endereco()
                {
                    Cep = "91430260",
                    Cidade = "Porto Alegre",
                    Estado = "RS",
                    Rua = "Rua 5, 571",
                    Complemento = "Cefer 2"
                }                
            });
        
        }
    }
}
