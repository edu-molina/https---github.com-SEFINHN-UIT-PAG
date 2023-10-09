using System;
using System.Collections.Generic;
using System.Linq;
using SAS_DTO;
using SAS_INTERFACES;
using Sefin.Security.Interfaces;
using Sefin.Security.Mappers;
using System.Web;

namespace Sefin.Security
{
    public class SecurityManager : ISecurityManager
    {
        public UsuarioClaim currentUser
        {
            get
            {
                return _decoratorSession.Claims;
            }
            set { _decoratorSession.Claims = value; }
        }

        public AUX_SEGURIDAD_DTO securityInfo
        {
            get { return _decoratorSession.Permisos; }
            set { _decoratorSession.Permisos=value; }
        }

        private readonly IDecoratorSessionVariables _decoratorSession;
        private bool _isConfigured;
        private bool _isLoged;
        private const int IdDefaultPerfil = 0;

        public SecurityManager(ISAS_Services sasServices, IWriteHeaders writeHeaders,IDecoratorSessionVariables decoratorSession,IDefaultMenuBuilder defaultMenuBuilder,SecurityConfiguration securityConfiguration)
        {
            this.sasServices = sasServices;
            WriteHeaders = writeHeaders;
            DefaultMenuBuilder = defaultMenuBuilder;
            _decoratorSession = decoratorSession;
            this.securityConfiguration = securityConfiguration;
        }

        #region properties

        public ISAS_Services sasServices { get; private set; }
        public IWriteHeaders WriteHeaders { get; set; }
        public IDefaultMenuBuilder DefaultMenuBuilder { get; set; }
        public SecurityConfiguration securityConfiguration { get; private set; }

    

        #endregion

        #region Methods

        public ISecurityManager configureWith(IUser user)
        {

            if (securityIsDisabled) return this;
            if (user.IsAuthenticated== false) return this;
            
            buildCurrentUserFrom(user);
            buildSecurityInfoWithCache(new Profile(user.Name, IdDefaultPerfil, user.IsAuthenticated));
            _isConfigured = true;
            return this;
        }

        public ISecurityManager changeProfile(Profile profile)
        {
            if (securityIsDisabled) return this;
            if (_isConfigured == false)
                throw new InvalidOperationException("Debe configurar la seguridad antes de cambiar el perfil");

            BuildSecurityInfo(profile);
            return this;
        }

        public Menu getCurrentMenu()
        {
            return _decoratorSession.isClaimsEmpty ? getDefaultMenu() : getMenuFromPerfil();
        }

        private Menu getDefaultMenu()
        {
            return new Menu() {items =  mappear(0,DefaultMenuBuilder.buildMenu())};
        }

        private Menu getMenuFromPerfil()
        {
            var menu = new Menu {items = mappear(0, this.securityInfo.Menus)};

            return menu;
        }

        public IEnumerable<Item> mappear( int id,IEnumerable<SAS_MENUS_DTO> menu )
        {
            var lista = new List<Item>();
            foreach (var sasMenusDto in menu.Where(x => x.ID_MENU_PADRE == id).OrderBy(x => x.ORDEN))
            {
                var item = sasMenusDto.toItem();
                item.childs = mappear(sasMenusDto.ID_MENU,menu);
                lista.Add(item);
            }
            return lista;
        }
        

        public void addHeadersForWcf(IHeaderBuilder builder)
        {
            if (_decoratorSession.isClaimsEmpty)return;
            WriteHeaders.write(_decoratorSession, builder);
        }

        public void logout()
        {
            sasServices.cerrarSESSION(securityInfo);
            _decoratorSession.clean();
        }


        public bool validate(IAction action)
        {
            if (securityIsDisabled) return true;
            if (_isConfigured == false)
                throw new InvalidOperationException("No se puede validar mientras no configure la seguridad");
            var actionName = action.getName();
           
            return validations(actionName).All(x => x == true);
        }

        private bool securityIsDisabled => securityConfiguration.enable == false;

        #endregion

        #region Helpers

        public void buildCurrentUserFrom(IUser user)
        {
            if (_decoratorSession.isClaimsEmpty==false) return;
            currentUser = user.getClaims();

        }


        public void buildSecurityInfoWithCache(Profile profile)
        {
            if (_decoratorSession.isPermisosEmpty==false) return;
            BuildSecurityInfo(profile);
        }

        private void BuildSecurityInfo(Profile profile)
        {
            try
            {
                securityInfo = sasServices.inicializarSeguridad(securityConfiguration.currentIdSytem, profile.userName, profile.perfil, _decoratorSession.sessionID);
            }
            catch (Exception ex)
            {
                var paramsMessage = $"Con parametros pSistema({securityConfiguration.currentIdSytem}), pUsuario({profile.userName}), pPerfil({profile.perfil}), pToken({_decoratorSession.sessionID}).";
                throw new HttpException(401, "Error al configurar SAS. " + paramsMessage);
            }
        }


        public IEnumerable<bool> validations(string action)
        {
            yield return securityInfo.Sistemas.Any(x => x.SIGLA == securityConfiguration.nameSystem);
            yield return currentUser.SISTEMAS.Any(x => x == securityConfiguration.nameSystem);
            yield return securityInfo.Permisos.Select(x => x.ToUpper()).Contains(action.ToUpper());
        }


        #endregion

    }
}
