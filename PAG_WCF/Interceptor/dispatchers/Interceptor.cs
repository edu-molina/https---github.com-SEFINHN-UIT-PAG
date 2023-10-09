using SAS_DTO;
using SAS_INTERFACES;
using Sefin.Security;
using Sefin.Security.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;


namespace PAG_WCF.Interceptor.dispatchers
{
   
    public class Interceptor : System.ServiceModel.Dispatcher.IParameterInspector
    {
        private readonly ReaderHeader _readerHeader = new ReaderHeader(DefaultClaimHeader.Name, DefaultClaimHeader.Namespace);
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            Console.WriteLine("Se ha ejecutado el metodo {0}: ", operationName);
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            var NameSpaces = System.Configuration.ConfigurationManager.AppSettings["NameSpaces"].ToUpper();
            var headers = OperationContext.Current.IncomingMessageHeaders;
            var hasHeaders = _readerHeader.containHeader(headers);
            // var action = OperationContext.Current.IncomingMessageHeaders.Action;
            if (hasHeaders)
            {
                var claimsHeader = _readerHeader.GetClaimsHeaderFrom<DefaultClaimHeader>(headers);
                PAG_Security.DictionaryClaims.Clear();
                PAG_Security.DictionaryClaims = PAG_Security.ToDictionary(claimsHeader.securityInfo);
                PAG_Security.Llenado.LlenadoSeg(NameSpaces, operationName);
            }

            return null;
        }
    }
}