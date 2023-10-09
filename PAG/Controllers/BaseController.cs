using PAG.Filters;
using PAG.Models;
using PAG_INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace PAG.Controllers
{
    [CustomAuthorization]
    [CustomException]
    [CustomAction]
    public class BaseController : Controller
    {
        //protected iPAG_Services wRef = DependencyResolver.Current.GetService<iPAG_Services>();

        //protected iPAG_Services wRef = new SefinClaims.CreateChannelSefin(
        //                            new Uri(System.Configuration.ConfigurationManager.AppSettings["wcfFideicomisos"].ToString().Trim()),
        //                            new BasicHttpBinding("bindingWcfPAG")).Create<iPAG_Services>();
    }
}
