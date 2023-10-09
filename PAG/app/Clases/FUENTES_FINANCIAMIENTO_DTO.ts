


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class FUENTES_FINANCIAMIENTO_DTO {
        
        // FUENTE
        public FUENTE: number = 0;
        // GRUPO_FUENTE
        public GRUPO_FUENTE: number = 0;
        // SUB_GRUPO_FUENTE
        public SUB_GRUPO_FUENTE: number = 0;
        // DESC_FUENTE
        public DESC_FUENTE: string = null;
        // VIGENTE
        public VIGENTE: string = null;
        // API_ESTADO
        public API_ESTADO: string = null;
    }
