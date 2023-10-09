
module IDM.Scripts.angular2 {

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class IDM_SISTEMAS_DTO {
        
        // SISTEMA_ID
        public sistemA_ID: number = 0;
        // DESC_SISTEMA
        public desC_SISTEMA: string = null;
        // SIGLAS_SISTEMA
        public siglaS_SISTEMA: string = null;
        // TOOLTIP
        public tooltip: string = null;
        // COLOR
        public color: string = null;
        // ICONO
        public icono: string = null;
        // URL
        public url: string = null;
        // SIZE
        public size: string = null;
        // ORDEN
        public orden: number = 0;
        // CLASE
        public clase: string = null;
        // VALOR1
        public valoR1: string = null;
        // VALOR2
        public valoR2: string = null;
        // VALOR3
        public valoR3: string = null;
        // FECHA_ELABORACION
        public fechA_ELABORACION: Date = null;
        // VIGENTE
        public vigente: string = null;
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