using Autofac;
using Sefin.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace PAG.AutoFacModuls
{
    public class ConfigurationSystemModule : Module
    {
        private Type _menuBuilderType;
        private Type _writeHeadersType;
        private Type _clientMessageInspectorType;

        public Type menuBuilderType
        {
            get { return _menuBuilderType; }
            private set { _menuBuilderType = value; }
        }

        public Type writeHeadersType
        {
            get { return _writeHeadersType; }
            private set { _writeHeadersType = value; }
        }

        public Type clientMessageInspectorType
        {
            get { return _clientMessageInspectorType; }
            private set { _clientMessageInspectorType = value; }
        }


        public ConfigurationSystemModule(Type menuBuilderType, Type writeHeadersType, Type clientMessageInspectorType)
        {
            this.menuBuilderType = menuBuilderType;
            this.writeHeadersType = writeHeadersType;
            this.clientMessageInspectorType = clientMessageInspectorType;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(menuBuilderType).As<IDefaultMenuBuilder>();
            builder.RegisterType(writeHeadersType).As<IWriteHeaders>();
            builder.RegisterType(clientMessageInspectorType).As<IClientMessageInspector>();
        }
    }
}