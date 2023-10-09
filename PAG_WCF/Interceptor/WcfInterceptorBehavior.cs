using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;

namespace PAG_WCF.Interceptor
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WcfInterceptorBehavior : Attribute, System.ServiceModel.Description.IServiceBehavior
    {
        public void AddBindingParameters(System.ServiceModel.Description.ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<System.ServiceModel.Description.ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            return;
        }

        public void ApplyDispatchBehavior(System.ServiceModel.Description.ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            foreach (System.ServiceModel.Dispatcher.ChannelDispatcher item in serviceHostBase.ChannelDispatchers)
            {

                //Estos handlers permiten manejar de forma centralizada los errores
                //item.ErrorHandlers
                foreach (System.ServiceModel.Dispatcher.EndpointDispatcher endPoint in item.Endpoints)
                {
                    foreach (System.ServiceModel.Dispatcher.DispatchOperation op in endPoint.DispatchRuntime.Operations)
                    {
                        op.ParameterInspectors.Add(new dispatchers.Interceptor());
                    }
                }
            }
        }

        public void Validate(System.ServiceModel.Description.ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            return;
        }
    }
}