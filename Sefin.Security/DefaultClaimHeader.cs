using SAS_DTO;

namespace Sefin.Security
{
    public class DefaultClaimHeader
    {
        public static string Name = "defaultClaimsHeader";
        public static string Namespace = "";
        public DefaultClaimHeader(string token, AUX_SEGURIDAD_DTO securityInfo)
        {
            this.token = token;
            this.securityInfo = securityInfo;
        }
        public string token { get; set; }
        public AUX_SEGURIDAD_DTO securityInfo { get; set; }
    }
}