


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class OBJETOS_DEL_GASTO_DTO {
        
        // GESTION
        public GESTION: number = 0;
        // OBJETO
        public OBJETO: string = null;
        // GRUPO_OBJETO
        public GRUPO_OBJETO: number = 0;
        // SUB_GRUPO_OBJETO
        public SUB_GRUPO_OBJETO: number = 0;
        // PARTIDA_OBJETO
        public PARTIDA_OBJETO: number = 0;
        // SUB_PARTIDA_OBJETO
        public SUB_PARTIDA_OBJETO: number = 0;
        // DESC_OBJETO
        public DESC_OBJETO: string = null;
        // VIGENTE
        public VIGENTE: string = null;
        // API_ESTADO
        public API_ESTADO: string = null;
    }
