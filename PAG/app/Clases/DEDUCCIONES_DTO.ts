


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class DEDUCCIONES_DTO {
        
        // DEDUCCION
        public DEDUCCION: number = 0;
        // TIPO
        public TIPO: number = 0;
        // SUB_TIPO
        public SUB_TIPO: number = 0;
        // DESCRIPCION
        public DESCRIPCION: string = null;
        // API_ESTADO
        public API_ESTADO: string = null;
    }
