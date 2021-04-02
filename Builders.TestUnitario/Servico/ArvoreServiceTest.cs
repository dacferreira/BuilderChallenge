using Builders.Dominio.Entidades;
using Builders.Dominio.Interfaces;
using Builders.TestUnitario.Builder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace Builders.TestUnitario.Servico
{
    public class ArvoreServiceTest : TesteBase
    {
        [Fact]
        public void ArvoreServiceTest_InserirRaiz()
        {
            var target = new ArvoreBuilder(context);
            context._unitOfWork.Setup(u => u.GetRepositorio<IArvoreRepositorio>().Inserir(It.IsAny<ArvoreBusca>()));

            target.Build().Inserir(2, target.Criar());
            context._unitOfWork.Verify(u => u.GetRepositorio<IArvoreRepositorio>().Inserir(It.IsAny<ArvoreBusca>()), Times.Once);
        }

        [Fact]
        public void ArvoreServiceTest_InserirNoDireito()
        {
            var target = new ArvoreBuilder(context);
            context._unitOfWork.Setup(u => u.GetRepositorio<IArvoreRepositorio>().Inserir(It.IsAny<ArvoreBusca>()));
            context._unitOfWork.Setup(u => u.GetRepositorio<INoArvoreRepositorio>().Atualizar(It.IsAny<NoArvore>()));

            var _entidade = target.Criar();
            _entidade.Id = 1;
            _entidade.Raiz.Id = 1;
            target.Build().Inserir(2, _entidade);
            context._unitOfWork.Verify(u => u.GetRepositorio<IArvoreRepositorio>().Inserir(It.IsAny<ArvoreBusca>()), Times.Once);
            context._noArvoreRepositorio.Verify(u => u.Atualizar(It.IsAny<NoArvore>()), Times.Once);
        }

        [Fact]
        public void ArvoreServiceTest_ObterPrimeiroNo()
        {
            var target = new ArvoreBuilder(context);
            var _entidade = target.Criar();
            context._unitOfWork.Setup(u => u.GetRepositorio<IArvoreRepositorio>().ObterSomente(It.IsAny<Expression<Func<ArvoreBusca, bool>>>()))
                               .Returns(_entidade);
            
            target.Build().ObterPrimeiroNo();
            context._unitOfWork.Verify(u => u.GetRepositorio<IArvoreRepositorio>().ObterSomente(It.IsAny<Expression<Func<ArvoreBusca, bool>>>()), Times.Once);
        }
    }
}
