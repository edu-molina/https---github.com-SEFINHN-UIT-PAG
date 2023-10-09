


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class DLB_LIB_BOLSON_DET_DTO {
        
        // GESTION
        public GESTION: number = 0;
        // INSTITUCION
        public INSTITUCION: number = 0;
        // GA
        public GA: number = 0;
        // NRO_DOCUMENTO
        public NRO_DOCUMENTO: number = 0;
        // SECUENCIA
        public SECUENCIA: number = 0;
        // PAG_INSTITUCION
        public PAG_INSTITUCION: number = 0;
        // PAG_GA
        public PAG_GA: number = 0;
        // LIB_GESTION
        public LIB_GESTION: number = 0;
        // LIB_BANCO
        public LIB_BANCO: number = 0;
        // LIB_CUENTA
        public LIB_CUENTA: string = null;
        // LIB_LIBRETA
        public LIB_LIBRETA: string = null;
        // MONEDA
        public MONEDA: string = null;
        // FUENTE
        public FUENTE: number = 0;
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
        // DESC_INSTITUCION
        public DESC_INSTITUCION: string = null;
        // DESC_GA
        public DESC_GA: string = null;
        // DESC_FUENTE
        public DESC_FUENTE: string = null;
    }
