
module IDM.Scripts.angular2 {

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class IDM_USUARIOS_DTO {
        
        // USUARIO_ID
        public usuariO_ID: number = 0;
        // FECHA_ELABORACION
        public fechA_ELABORACION: Date = null;
        // NOMBRE_USUARIO
        public nombrE_USUARIO: string = null;
        // NICK_USUARIO
        public nicK_USUARIO: string = null;
        // TIPO_USUARIO_ID
        public tipO_USUARIO_ID: string = null;
        // NIVEL_USUARIO_ID
        public niveL_USUARIO_ID: number = 0;
        // PERSONA_ID
        public personA_ID: number = 0;
        // PUESTO
        public puesto: string = null;
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