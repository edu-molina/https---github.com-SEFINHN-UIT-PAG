//------------------------------------------------------------------------------
//                         Secretaria de Finanzas
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PAG_DTO
{


    public class TreeRoot
    {
        public List<TreeNode> data { get; set; }
    }
    public class TreeLeaf
    {
        public string cuenta { get; set; }
        public string descripcion { get; set; }
        public string antecesor { get; set; }
        public string saldo { get; set; }
        public string apropia { get; set; }
        public string vigencia { get; set; }
    }
    public class TreeNode
    {
        public TreeLeaf data { get; set; }
        public List<TreeNode> children { get; set; }
        public string expandedIcon { get; set; }
        public string collapsedIcon { get; set; }
    }

    public class DropDownKeyValue
    {
        public string label { get; set; }
        public string value { get; set; }
    }

}
