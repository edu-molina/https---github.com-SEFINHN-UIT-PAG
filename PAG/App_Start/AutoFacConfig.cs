using Autofac;
using Autofac.Integration.Mvc;
using FPE_INTERFACES;
using PAG.AutoFacModuls;
using PAG_INTERFACES;
using SAS_INTERFACES;
using Sefin.Security;
using Sefin.Security.Interfaces;
using Sefin.Security.Mvc;
using Sefin.Security.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;

namespace PAG.App_Start
{
    public class AutoFacConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();

            //Registrar las dependencias en los controladores
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<DefaultHeaderBuilderWCF>().As<IHeaderBuilder>();
            builder.RegisterType<HeaderBuilderFactory>().As<IHeaderBuilderFactory>();

            //Registrar las depedendias de los modulos de AutoFac
            builder.RegisterModule(new ConfigurationSystemModule(typeof(EmptyDefaultMenuBuilder), typeof(DefaultWritetHeaders), typeof(DefaultClientMessageInspector)));
            builder.RegisterModule(new SecurityManagerModule(6, "PAG", true));

            builder.RegisterType<ActionMvc>().As<IAction>();

            //Registra la dependencia de los servicios
            builder.RegisterModule(new ServiceModule<ISAS_Services>("BasicHttpBinding_IPAG"));
            builder.RegisterModule(new ServiceModule<iPAG_Services>("BasicHttpBinding_IPAG"));
            builder.RegisterModule(new ServiceModule<IFPE_Services>("BasicHttpBinding_IPAG")); 

            //Registramos las dependencias de los filtros
            builder.RegisterFilterProvider();

            var container = builder.Build();

            // Asignamos a un MVC DI para usar un contenedor de AutoFac
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public class DefaultClientMessageInspector : ClientMessageInspector
        {
            public DefaultClientMessageInspector(IWriteHeaders writeHeaders, IDecoratorSessionVariables decoratorSessionVariables, IHeaderBuilderFactory headerBuilderFactory) : base(writeHeaders, decoratorSessionVariables, headerBuilderFactory)
            {
            }

            public override void beforeSend(ref Message request, IEnumerable<KeyValuePair<string, string>> headers)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(MessageHeader.CreateHeader(header.Key, DefaultClaimHeader.Namespace /*ClaimsDefaultHeaders.DEFAULT_HEADER_NAMESPACE*/, header.Value));
                }
            }
        }
    }
}