


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class VM_PAG_LISTA_VALORES_DTO {
        
        // LLAVE_VIEW
        public LLAVE_VIEW: number = 0;
        // ID_COLUMNA
        public ID_COLUMNA: number = 0;
        // DESC_COLUMNA
        public DESC_COLUMNA: string = null;
        // TABLA
        public TABLA: string = null;
        // COLUMNA
        public COLUMNA: string = null;
        // TIPO_VALOR
        public TIPO_VALOR: string = null;
        // VALOR
        public VALOR: string = null;
        // DESCRIPCION
        public DESCRIPCION: string = null;
        // OTROS_VALORES
        public OTROS_VALORES: string = null;
    }
