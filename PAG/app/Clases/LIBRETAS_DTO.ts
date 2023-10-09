


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class LIBRETAS_DTO {
        
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
        // INSTITUCION
        public INSTITUCION: number = 0;
        // GA
        public GA: number = 0;
        // FUENTE
        public FUENTE: number = 0;
        // SECUENCIA_FUENTE
        public SECUENCIA_FUENTE: number = 0;
        // DESC_LIBRETA
        public DESC_LIBRETA: string = null;
        // SALDO_INICIAL
        public SALDO_INICIAL: number = null;
        // SALDO
        public SALDO: number = 0;
        // SE_CONCILIA
        public SE_CONCILIA: string = null;
        // DEBITA_POR
        public DEBITA_POR: string = null;
        // ACREDITA_POR
        public ACREDITA_POR: string = null;
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
    }
