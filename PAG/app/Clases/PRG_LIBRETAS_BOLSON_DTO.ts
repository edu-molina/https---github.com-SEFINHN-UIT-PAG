


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class PRG_LIBRETAS_BOLSON_DTO {
        
        // INSTITUCION
        public INSTITUCION: number = 0;
        // GA
        public GA: number = 0;
        // GESTION
        public GESTION: number = 0;
        // BANCO
        public BANCO: number = 0;
        // CUENTA
        public CUENTA: string = null;
        // LIBRETA
        public LIBRETA: string = null;
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
        // DESC_LIBRETA
        public DESC_LIBRETA: string = null;
        // DESC_FUENTE
        public DESC_FUENTE: string = null;
        // DESC_CUENTA
        public DESC_CUENTA: string = null;
    }
