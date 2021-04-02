namespace Builders.TestUnitario
{
    public interface IBuilder<TEntity> where TEntity : class
    {
        TEntity Criar();
    }
}
