namespace Sefin.Security
{
    public class SecurityConfiguration
    {
        private bool _enable =true;

        public SecurityConfiguration()
        {
            
        }
        public SecurityConfiguration(int currentIdSytem, string nameSystem)
        {
            this.currentIdSytem = currentIdSytem;
            this.nameSystem = nameSystem;
        }

        public SecurityConfiguration(int currentIdSytem, string nameSystem,bool enable)
        {
            this.currentIdSytem = currentIdSytem;
            this.nameSystem = nameSystem;
            this.enable = enable;
        }
        public int currentIdSytem { get; set; }
        public string nameSystem { get; set; }
      

        public bool enable
        {
            get { return _enable; }
            set { _enable = value; }
        }
    }
}