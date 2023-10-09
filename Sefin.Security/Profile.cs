namespace Sefin.Security
{
    public class Profile
    {
        public Profile(string userName, int perfil, bool isAuthenticated)
        {
            this.isAuthenticated = isAuthenticated;
            this.userName = userName;
            this.perfil = perfil;
        }
        public string userName { get; private set; }

        public bool isAuthenticated { get; private set; }
        public int perfil { get; private set; }
        
    }
}