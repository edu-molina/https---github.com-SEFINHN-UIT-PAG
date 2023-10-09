using System.Collections;
using System.Collections.Generic;
using SAS_DTO;
using Sefin.Security.Interfaces;

namespace Sefin.Security
{
    public class EmptyDefaultMenuBuilder:IDefaultMenuBuilder
    {
        public IEnumerable<SAS_MENUS_DTO> buildMenu()
        {
            return new List<SAS_MENUS_DTO>();
        }
    }
}