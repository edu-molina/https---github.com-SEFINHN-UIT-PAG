using Autofac;
using Sefin.Security;
using Sefin.Security.Interfaces;
using Sefin.Security.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAG.AutoFacModuls
{
    public class SecurityManagerModule : Module
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Enable { get; set; }

        public SecurityManagerModule(int id, string nombre, bool enable = true)
        {
            Id = id;
            Nombre = nombre;
            Enable = enable;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new SecurityConfiguration(Id, Nombre, Enable));
            builder.RegisterType<DecoratorSessionVariables>().As<IDecoratorSessionVariables>();
            builder.RegisterType<SecurityManager>().As<ISecurityManager>();
        }
    }
}