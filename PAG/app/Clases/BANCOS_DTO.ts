


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class BANCOS_DTO {
        
        // BANCO
        public BANCO: number = 0;
        // DESC_BANCO
        public DESC_BANCO: string = null;
        // SIGLA_BANCO
        public SIGLA_BANCO: string = null;
        // TIPO_BANCO
        public TIPO_BANCO: string = null;
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
        // CUENTA_ENCAJE
        public CUENTA_ENCAJE: string = null;
        // RECIPIENTE_ID
        public RECIPIENTE_ID: string = null;
        // CONECTADO_SIAFI
        public CONECTADO_SIAFI: string = null;
        // HABILITADO_ENVIOS
        public HABILITADO_ENVIOS: string = null;
        // BEN_PAIS_ID
        public BEN_PAIS_ID: string = null;
        // BEN_TIPO_ID
        public BEN_TIPO_ID: string = null;
        // BEN_NRO_ID
        public BEN_NRO_ID: string = null;
        // BEN_BANCO
        public BEN_BANCO: number = null;
        // BEN_CUENTA
        public BEN_CUENTA: string = null;
    }
