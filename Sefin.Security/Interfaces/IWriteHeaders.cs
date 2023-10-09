namespace Sefin.Security.Interfaces
{
    public interface IWriteHeaders
    {
        void write(IDecoratorSessionVariables decoratorSession, IHeaderBuilder builder);
    }
  
}