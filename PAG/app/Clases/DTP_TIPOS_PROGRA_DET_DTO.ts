


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class DTP_TIPOS_PROGRA_DET_DTO {
        
        // GESTION
        public GESTION: number = 0;
        // INSTITUCION
        public INSTITUCION: number = 0;
        // GA
        public GA: number = 0;
        // NRO_DOCUMENTO
        public NRO_DOCUMENTO: number = 0;
        // INSTITUCION_PROG
        public INSTITUCION_PROG: number = 0;
        // GA_PROG
        public GA_PROG: number = 0;
        // TIPO_PROGRAMACION
        public TIPO_PROGRAMACION: number = 0;
        // DESC_TIPO_PROGRAMACION
        public DESC_TIPO_PROGRAMACION: string = null;
        // ESPECIAL
        public ESPECIAL: string = null;
        // API_ESTADO
        public API_ESTADO: string = null;
        // API_TRANSACCION
        public API_TRANSACCION: string = null;
        // USU_CRE
        public USU_CRE: string = null;
        // FEC_CRE
        public FEC_CRE: Date = null;
        // USU_MOD
        public USU_MOD: string = null;
        // FEC_MOD
        public FEC_MOD: Date = null;
        // DESC_INSTITUCION_PROG
        public DESC_INSTITUCION_PROG: string = null;
        // DESC_GA_PROG
        public DESC_GA_PROG: string = null;
    }
