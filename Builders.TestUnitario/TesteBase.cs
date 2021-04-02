using Builders.TestUnitario.Context;

namespace Builders.TestUnitario
{
    public abstract class TesteBase
    {
        protected readonly BuildersContext context;
        public TesteBase()
        {
            this.context = new BuildersContext();
        }

        static TesteBase()
        {

        }
    }
}
