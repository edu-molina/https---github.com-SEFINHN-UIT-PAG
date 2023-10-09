using Newtonsoft.Json;
using Sefin.Security.Interfaces;

namespace Sefin.Security.Wcf
{
    public class DefaultWritetHeaders : IWriteHeaders
    {
        public void write(IDecoratorSessionVariables decoratorSession, IHeaderBuilder builder)
        {
            var data = JsonConvert.SerializeObject(new DefaultClaimHeader(decoratorSession.sessionID, decoratorSession.Permisos));

            builder.add(DefaultClaimHeader.Name, data);
        }
    }
}