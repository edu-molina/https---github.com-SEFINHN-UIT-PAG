


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class AUX_MENU_DTO {
        
        // ID_MENU
        public ID_MENU: number = 0;
        // ID_SISTEMA
        public ID_SISTEMA: number = 0;
        // NOMBRE_MENU
        public NOMBRE_MENU: string = null;
        // ID_MENU_PADRE
        public ID_MENU_PADRE: number = 0;
        // ORDEN
        public ORDEN: number = 0;
        // JERARQUIA
        public JERARQUIA: string = null;
        // METODO
        public METODO: string = null;
        // DESC_MENU
        public DESC_MENU: string = null;
        // TIPO_MENU
        public TIPO_MENU: string = null;
        // ICO_MENU
        public ICO_MENU: string = null;
        // TOOLTIP
        public TOOLTIP: string = null;
        // VIGENTE
        public VIGENTE: string = null;
        // HABILITADO
        public HABILITADO: string = null;
        // API_ESTADO
        public API_ESTADO: string = null;
        // API_TRANSACCION
        public API_TRANSACCION: string = null;
        // USU_CRE
        public USU_CRE: string = null;
        // USU_MOD
        public USU_MOD: string = null;
        // FEC_CRE
        public FEC_CRE: Date = null;
        // FEC_MOD
        public FEC_MOD: Date = null;
    }
