
module IDM.Scripts.angular2 {

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class IDM_PERSONAS_DTO {
        
        // PERSONA_ID
        public personA_ID: number = 0;
        // PRIMER_NOMBRE
        public primeR_NOMBRE: string = null;
        // SEGUNDO_NOMBRE
        public segundO_NOMBRE: string = null;
        // PRIMER_APELLIDO
        public primeR_APELLIDO: string = null;
        // SEGUNDO_APELLIDO
        public segundO_APELLIDO: string = null;
        // FECHA_NACIMIENTO
        public fechA_NACIMIENTO: Date = null;
        // FECHA_ELABORACION
        public fechA_ELABORACION: Date = null;
        // SEXO
        public sexo: string = null;
        // PAIS_ID
        public paiS_ID: string = null;
        // TIPO_ID
        public tipO_ID: string = null;
        // NRO_ID
        public nrO_ID: string = null;
        // DIRECCION
        public direccion: string = null;
        // CORREO
        public correo: string = null;
        // TELEFONO
        public telefono: string = null;
        // CELULAR
        public celular: string = null;
        // GLOSA
        public glosa: string = null;
        // VIGENTE
        public vigente: string = null;
        // API_ESTADO
        public apI_ESTADO: string = null;
        // API_TRANSACCION
        public apI_TRANSACCION: string = null;
        // USU_CRE
        public usU_CRE: string = null;
        // FEC_CRE
        public feC_CRE: Date = null;
        // USU_MOD
        public usU_MOD: string = null;
        // FEC_MOD
        public feC_MOD: Date = null;
    }
}