using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using Autofac;
using Autofac.Integration.Wcf;
using Sefin.Security.Wcf;
using PAG.Helpers;

namespace PAG.AutoFacModuls
{
    public class ServiceModule<T> : Module
    {
        public string NameBinding { get; set; }

        public ServiceModule(string nameBinding)
        {
            NameBinding = nameBinding;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var endpointAddress = EndpointNameAddress.GetPair(typeof(T));

            builder.Register(c =>
            {
                var factory = new ChannelFactory<T>(
                    new BasicHttpBinding(NameBinding),
                    new EndpointAddress(endpointAddress.Value));
                factory.Endpoint.EndpointBehaviors.Add(new ClaimEndpointBehavior(c.Resolve<IClientMessageInspector>()));
                return factory;
            })
                .SingleInstance();

            builder
                .Register(c => c.Resolve<ChannelFactory<T>>().CreateChannel())
                .As<T>()
                .UseWcfSafeRelease();
        }
    }
}