
module IDM.Scripts.angular2 {

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class IDM_TRANSACCIONES_DET_DTO {
        
        // FECHA_ELABORACION
        public fechA_ELABORACION: Date = null;
        // VALOR_ANTERIOR
        public valoR_ANTERIOR: string = null;
        // VALOR_NUEVO
        public valoR_NUEVO: string = null;
        // TRANSACCION_ID
        public transaccioN_ID: number = 0;
        // PROPIEDAD_ID
        public propiedaD_ID: number = 0;
        // TIPO_TRANSACCION_ID
        public tipO_TRANSACCION_ID: number = 0;
        // API_ESTADO
        public apI_ESTADO: string = null;
        // API_TRANSACCION
        public apI_TRANSACCION: string = null;
        // USU_CRE
        public usU_CRE: string = null;
        // FEC_CRE
        public feC_CRE: Date = null;
        // USU_MOD
        public usU_MOD: string = null;
        // FEC_MOD
        public feC_MOD: Date = null;
    }
}