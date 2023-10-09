


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class EGA_BENEFICIARIOS_DTO {
        
        // GESTION
        public GESTION: number = 0;
        // INSTITUCION
        public INSTITUCION: number = 0;
        // GA
        public GA: number = 0;
        // NRO_PRECOMPROMISO
        public NRO_PRECOMPROMISO: number = 0;
        // NRO_COMPROMISO
        public NRO_COMPROMISO: number = 0;
        // NRO_DEVENGADO
        public NRO_DEVENGADO: number = 0;
        // NRO_SECUENCIA
        public NRO_SECUENCIA: number = 0;
        // SEC_PAGO
        public SEC_PAGO: number = 0;
        // PAIS_ID
        public PAIS_ID: string = null;
        // TIPO_ID
        public TIPO_ID: string = null;
        // NRO_ID
        public NRO_ID: string = null;
        // EJERCICIO
        public EJERCICIO: number = 0;
        // TIPOS_MOMENTOS
        public TIPOS_MOMENTOS: string = null;
        // BANCO
        public BANCO: number = null;
        // CUENTA
        public CUENTA: string = null;
        // MONTO
        public MONTO: number = 0;
        // MONTO_DC
        public MONTO_DC: number = 0;
        // MONTO_ME
        public MONTO_ME: number = 0;
        // API_ESTADO
        public API_ESTADO: string = null;
    }
