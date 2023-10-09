using System.Collections.Generic;
using SAS_DTO;

namespace Sefin.Security.Interfaces
{
    public interface IAction
    {
        string getName();
    }

    public interface IUser
    {
        bool IsAuthenticated { get; }
        string Name { get;  }
        UsuarioClaim getClaims();
    }

    public interface IDefaultMenuBuilder
    {
        IEnumerable<SAS_MENUS_DTO> buildMenu();
    }
}