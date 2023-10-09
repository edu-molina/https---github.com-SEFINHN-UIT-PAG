using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Clase UNIDADES_EJECUTORAS_DTO
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 03/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>
namespace PAG_DTO
{
    public class UNIDADES_EJECUTORAS_DTO
    {
        [DisplayName("Gestión")]//, MaxLength(4), ReadOnly(true)]
        public short GESTION { get; set; }

        [DisplayName("Institución")]//, MaxLength(6), ReadOnly(true)]
        public short INSTITUCION { get; set; }

        [DisplayName("Unidad Ejecutora")]//, MaxLength(6), ReadOnly(true)]
        public short UE { get; set; }
        [DisplayName("Descripcion UE")]//, MaxLength(60), ReadOnly(true)]
        public string DESC_UE { get; set; }
        [DisplayName("Etapa Documento")]//, MaxLength(30), ReadOnly(true)]
        public short ETAPA_DOCUMENTO { get; set; }
        [DisplayName("Vigente")]//, MaxLength(1), ReadOnly(true)]
        public string VIGENTE { get; set; }

        [DisplayName("Estado")]//, MaxLength(30), ReadOnly(true)]
        public string API_ESTADO { get; set; }
    }
}
