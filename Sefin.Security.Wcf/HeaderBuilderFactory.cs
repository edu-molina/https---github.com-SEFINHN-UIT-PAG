using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sefin.Security.Interfaces;

namespace Sefin.Security.Wcf
{
    public class HeaderBuilderFactory : IHeaderBuilderFactory
    {
        public IHeaderBuilder headerBuilder { get; set; }
        public HeaderBuilderFactory(IHeaderBuilder headerBuilder)
        {
            this.headerBuilder = headerBuilder;
        }

        public IHeaderBuilder create()
        {
            return headerBuilder;
        }

        public void Destroy(IHeaderBuilder headerBuilder)
        {
            this.headerBuilder = new DefaultHeaderBuilderWCF();

        }
    }
}
