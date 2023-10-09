using SAS_DTO;
using Sefin.Security.Interfaces;

namespace Sefin.Security
{
    public interface ISecurityManager
    {
        ISecurityManager configureWith(IUser user);
        ISecurityManager changeProfile(Profile profile);
        Menu getCurrentMenu();
        void addHeadersForWcf(IHeaderBuilder headerBuilder);
        void logout();
        bool validate(IAction action);
        UsuarioClaim currentUser { get; set; }
        AUX_SEGURIDAD_DTO securityInfo { get; set; }
    }
}