using System;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Sefin.Security.Wcf
{
    public class ClaimEndpointBehavior :BehaviorExtensionElement , IEndpointBehavior
    {
        public IClientMessageInspector ClientMessageInspector { get; set; }

        public ClaimEndpointBehavior(IClientMessageInspector clientMessageInspector)
        {
            ClientMessageInspector = clientMessageInspector;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            return;
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(ClientMessageInspector);
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            
        }
        public void Validate(ServiceEndpoint endpoint)
        {
            return;
        }

        protected override object CreateBehavior()
        {
            return new ClaimEndpointBehavior(ClientMessageInspector);
        }

        public override Type BehaviorType
        {
            get { return typeof(ClaimEndpointBehavior); }
        }
    }
}