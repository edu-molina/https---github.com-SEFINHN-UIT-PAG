using Sefin.Security.Interfaces;

namespace Sefin.Security.Wcf
{
    public interface IHeaderBuilderFactory
    {
        IHeaderBuilder create();
        void Destroy(IHeaderBuilder headerBuilder);
    }
}