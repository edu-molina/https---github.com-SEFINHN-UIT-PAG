


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class DCO_COLUMNAS_DTO {
        
        // ID_COLUMNA
        public ID_COLUMNA: number = 0;
        // DESC_COLUMNA
        public DESC_COLUMNA: string = null;
        // TIPO_COLUMNA
        public TIPO_COLUMNA: string = null;
        // TABLA
        public TABLA: string = null;
        // COLUMNA
        public COLUMNA: string = null;
        // TABLA_ORIGEN
        public TABLA_ORIGEN: string = null;
        // COLUMNA_ORIGEN
        public COLUMNA_ORIGEN: string = null;
        // OTROS_VALORES
        public OTROS_VALORES: string = null;
        // TIENE_LISTA
        public TIENE_LISTA: string = null;
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
