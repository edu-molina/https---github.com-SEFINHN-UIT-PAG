


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class MUNICIPIOS_DTO {
        
        // DEPARTAMENTO
        public DEPARTAMENTO: number = 0;
        // MUNICIPIO
        public MUNICIPIO: number = 0;
        // DESC_MUNICIPIO
        public DESC_MUNICIPIO: string = null;
        // SIGLA_MUNICIPIO
        public SIGLA_MUNICIPIO: string = null;
        // VIGENTE
        public VIGENTE: string = null;
        // API_ESTADO
        public API_ESTADO: string = null;
    }
