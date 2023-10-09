


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class TPR_DOCUMENTOS_DTO {
        
        // INSTITUCION
        public INSTITUCION: number = 0;
        // GA
        public GA: number = 0;
        // TIPO_PROGRAMACION
        public TIPO_PROGRAMACION: number = 0;
        // SECUENCIA_DOC
        public SECUENCIA_DOC: number = 0;
        // ID_DOCUMENTO
        public ID_DOCUMENTO: string = null;
        // OBSERVACION
        public OBSERVACION: string = null;
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
        // DESC_DOCUMENTO
        public DESC_DOCUMENTO: string = null;
    }
