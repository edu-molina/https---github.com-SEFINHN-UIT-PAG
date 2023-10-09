using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;

namespace PAG_WCF.Interceptor
{
    public class InterceptorExtension : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new WcfInterceptorBehavior();
        }

        public override Type BehaviorType
        {
            get { return typeof(WcfInterceptorBehavior); }
        }
    }
}