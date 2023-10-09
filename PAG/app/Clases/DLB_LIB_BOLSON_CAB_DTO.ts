


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class DLB_LIB_BOLSON_CAB_DTO {
        
        // GESTION
        public GESTION: number = 0;
        // INSTITUCION
        public INSTITUCION: number = 0;
        // GA
        public GA: number = 0;
        // NRO_DOCUMENTO
        public NRO_DOCUMENTO: number = 0;
        // DPTO_LUGAR
        public DPTO_LUGAR: number = 0;
        // MUN_LUGAR
        public MUN_LUGAR: number = 0;
        // TIPO_OPERACION
        public TIPO_OPERACION: string = null;
        // USU_VERIFICACION
        public USU_VERIFICACION: string = null;
        // FEC_VERIFICACION
        public FEC_VERIFICACION: Date = null;
        // USU_APROBACION
        public USU_APROBACION: string = null;
        // FEC_APROBACION
        public FEC_APROBACION: Date = null;
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
        // LUGAR
        public LUGAR: string = null;
        // DESC_INSTITUCION
        public DESC_INSTITUCION: string = null;
        // DESC_GA
        public DESC_GA: string = null;
        // DESC_LUGAR
        public DESC_LUGAR: string = null;
        // DESC_TIPO_OPERACION
        public DESC_TIPO_OPERACION: string = null;
    }
