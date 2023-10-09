using System.Collections.Generic;
using Sefin.Security.Interfaces;

namespace Sefin.Security.Wcf
{
    public class DefaultHeaderBuilderWCF : IHeaderBuilder
    {

        private readonly List<KeyValuePair<string, string>> _headers = new List<KeyValuePair<string, string>>();
        public IHeaderBuilder add(string key, string value)
        {
            _headers.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }

        public IEnumerable<KeyValuePair<string, string>> headers
        {
            get { return _headers; }
        }

      
    }
}