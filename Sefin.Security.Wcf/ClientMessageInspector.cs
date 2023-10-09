using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Sefin.Security.Interfaces;

namespace Sefin.Security.Wcf
{
    public class ClientMessageInspector : IClientMessageInspector
    {
        public ISecurityManager SecurityManager { get; private set; }
        public IWriteHeaders WriteHeaders { get; set; }
        public IDecoratorSessionVariables DecoratorSessionVariables { get; set; }
        public IHeaderBuilderFactory HeaderBuilderFactory { get; set; }
        
        public ClientMessageInspector(IWriteHeaders writeHeaders,IDecoratorSessionVariables decoratorSessionVariables, IHeaderBuilderFactory headerBuilderFactory)
        {
            WriteHeaders = writeHeaders;
            DecoratorSessionVariables = decoratorSessionVariables;
            HeaderBuilderFactory = headerBuilderFactory;
        }

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            return;
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
        {
            var headerBuilder = HeaderBuilderFactory.create();
            WriteHeaders.write(DecoratorSessionVariables,headerBuilder);
            beforeSend(ref request, headerBuilder.headers);
            HeaderBuilderFactory.Destroy(headerBuilder);
            return null;
        }

        public virtual void beforeSend(ref System.ServiceModel.Channels.Message request,IEnumerable<KeyValuePair<string,string>> headers )
        {
            foreach (var header in headers)
            {
                request.Headers.Add(MessageHeader.CreateHeader(header.Key, DefaultClaimHeader.Name, header.Value));
            }
        }

    }
}