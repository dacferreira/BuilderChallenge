using Builders.Dominio.Interfaces;
using Castle.Core.Configuration;
using Moq;

namespace Builders.TestUnitario.Context
{
    public class BuildersContext
    {
        public Mock<IUnitOfWork> _unitOfWork { get; set; }
        public Mock<IConfiguration> _configuration { get; set; }

        //Service
        public Mock<IArvoreService> _arvoreService;

        public Mock<IArvoreRepositorio> _arvoreRepositorio;
        public Mock<INoArvoreRepositorio> _noArvoreRepositorio;
        public BuildersContext()
        {
            this._unitOfWork = new Mock<IUnitOfWork>();
            this._configuration = new Mock<IConfiguration>();

            //Service
            this._arvoreService = new Mock<IArvoreService>();

            //Repository
            this._arvoreRepositorio = new Mock<IArvoreRepositorio>();
            this._noArvoreRepositorio = new Mock<INoArvoreRepositorio>();
        }
    }
}
