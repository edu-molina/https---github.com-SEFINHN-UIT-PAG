


    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class DOCUMENTOS_DE_GASTOS_DTO {
        
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
        // EJERCICIO
        public EJERCICIO: number = 0;
        // NRO_DEVENGADO_SIP
        public NRO_DEVENGADO_SIP: number = null;
        // UE
        public UE: number = 0;
        // TIPO_FORMULARIO
        public TIPO_FORMULARIO: string = null;
        // TIPO_DOCUMENTO
        public TIPO_DOCUMENTO: string = null;
        // LUGAR_DEP
        public LUGAR_DEP: number = 0;
        // LUGAR_MUN
        public LUGAR_MUN: number = 0;
        // APLICACION
        public APLICACION: string = null;
        // FUENTE
        public FUENTE: number = null;
        // ORGANISMO
        public ORGANISMO: number = null;
        // BIP
        public BIP: string = null;
        // CONVENIO
        public CONVENIO: string = null;
        // SIGADE
        public SIGADE: string = null;
        // TRAMO
        public TRAMO: number = null;
        // API_ESTADO
        public API_ESTADO: string = null;
    }
