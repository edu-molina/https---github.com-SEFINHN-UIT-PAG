using System.Linq;
using System.ServiceModel.Channels;
using Newtonsoft.Json;

namespace Sefin.Security.Wcf
{
    public class ReaderHeader
    {
        public string NameHeader { get; set; }
        public string NamespaceHeader { get; set; }

        public ReaderHeader(string nameHeader,string namespaceHeader)
        {
            NameHeader = nameHeader;
            NamespaceHeader = namespaceHeader;
        }

        public  bool containHeader(MessageHeaders headers)
        {
            return headers.Any(x => x.Name == NameHeader);
        }

   
        public T GetClaimsHeaderFrom<T>(MessageHeaders headers)
        {
            var headerStringValue = getStringHeaders(headers);
            return JsonConvert.DeserializeObject<T>(headerStringValue);
        }

        public string getStringHeaders(MessageHeaders headers)
        {
            return headers.GetHeader<string>(NameHeader,NamespaceHeader);
        }
    }
}