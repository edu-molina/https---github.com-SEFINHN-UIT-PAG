using System.Collections.Generic;

namespace Sefin.Security.Interfaces
{
    public interface IHeaderBuilder{
        IHeaderBuilder add(string key, string value);
        IEnumerable<KeyValuePair<string, string>> headers { get; }
    }
}