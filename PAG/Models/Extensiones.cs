using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Helpers;

namespace PAG.Models
{
    public static class Extensiones
    {
        public static SelectList Cod_Desc(this SelectList Listado)
        {
            foreach (var item in Listado)
            { 
            item.Text=item.Value.ToString()+"-"+item.Text.ToString();
            }
            return Listado;
        }

        //Fuente DCLM 01-06-2016: http://forums.asp.net/t/2061874.aspx?DropDownList+with+ViewBag
        public static MvcHtmlString EnumDropDownList<TEnum>(this HtmlHelper htmlHelper, string name, TEnum selectedValue)
        {
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem
                                                {
                                                    Text = value.ToString(),
                                                    Value = value.ToString(),
                                                    Selected = (value.Equals(selectedValue))
                                                };
            return htmlHelper.EnumDropDownList(name, items);
        }


    //    public class PAG_DOCFIC_DET : PAG_DTO.PAG_DOCFIC_DET_DTO
    //    {
    //    public HttpPostedFileBase Archivo{get;set;}
    //}
    }
    }
