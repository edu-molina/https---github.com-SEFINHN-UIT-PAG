﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PAG_DA
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PAG_Entities : DbContext
    {
        public PAG_Entities()
            : base("name=PAG_Entities")
        {
        }
    
    	//Inicio Agregado DCLM 26-03-2016
    	public PAG_Entities(System.Collections.Generic.Dictionary<string, string> pDictionaryClaims)
            : base("name=PAG_Entities")
        {
    		OnContextCreated(pDictionaryClaims: pDictionaryClaims); //Agregado por DCLM 26-03-2016
        }
    	//Final Agregado DCLM 26-03-2016
    
    	partial void OnContextCreated(System.Collections.Generic.Dictionary<string, string> pDictionaryClaims); //Agregado por DCLM 26-03-2016
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<DCO_DOCUMENTOS> DCO_DOCUMENTOS { get; set; }
        public DbSet<MENSAJES_DE_ERROR> MENSAJES_DE_ERROR { get; set; }
        public DbSet<CG_REF_CODES> CG_REF_CODES { get; set; }
        public DbSet<BEN_TIPOS_IDENTIFICACION> BEN_TIPOS_IDENTIFICACION { get; set; }
        public DbSet<BENEFICIARIOS> BENEFICIARIOS { get; set; }
        public DbSet<CLASES_DE_GASTO_CIP> CLASES_DE_GASTO_CIP { get; set; }
        public DbSet<CLASES_DE_GASTO_SIP> CLASES_DE_GASTO_SIP { get; set; }
        public DbSet<DEDUCCIONES> DEDUCCIONES { get; set; }
        public DbSet<DOCUMENTOS_DE_GASTOS> DOCUMENTOS_DE_GASTOS { get; set; }
        public DbSet<EGA_BENEFICIARIOS> EGA_BENEFICIARIOS { get; set; }
        public DbSet<EGA_PARTIDAS> EGA_PARTIDAS { get; set; }
        public DbSet<FUENTES_FINANCIAMIENTO> FUENTES_FINANCIAMIENTO { get; set; }
        public DbSet<GERENCIAS_ADMINISTRATIVAS> GERENCIAS_ADMINISTRATIVAS { get; set; }
        public DbSet<INSTITUCIONES> INSTITUCIONES { get; set; }
        public DbSet<MUNICIPIOS> MUNICIPIOS { get; set; }
        public DbSet<OBJETOS_DEL_GASTO> OBJETOS_DEL_GASTO { get; set; }
        public DbSet<PAISES> PAISES { get; set; }
        public DbSet<UNIDADES_EJECUTORAS> UNIDADES_EJECUTORAS { get; set; }
        public DbSet<API_TRANSICIONES> API_TRANSICIONES { get; set; }
        public DbSet<DCO_COLUMNAS> DCO_COLUMNAS { get; set; }
        public DbSet<DCO_DOCUMENTOS_COLUMNAS> DCO_DOCUMENTOS_COLUMNAS { get; set; }
        public DbSet<DLB_LIB_BOLSON_CAB> DLB_LIB_BOLSON_CAB { get; set; }
        public DbSet<DLB_LIB_BOLSON_DET> DLB_LIB_BOLSON_DET { get; set; }
        public DbSet<DTP_DETALLES_DET> DTP_DETALLES_DET { get; set; }
        public DbSet<DTP_DOCUMENTOS_DET> DTP_DOCUMENTOS_DET { get; set; }
        public DbSet<DTP_TIPOS_PROGRA_CAB> DTP_TIPOS_PROGRA_CAB { get; set; }
        public DbSet<DTP_TIPOS_PROGRA_DET> DTP_TIPOS_PROGRA_DET { get; set; }
        public DbSet<PRG_LIBRETAS_BOLSON> PRG_LIBRETAS_BOLSON { get; set; }
        public DbSet<TPR_DETALLES> TPR_DETALLES { get; set; }
        public DbSet<TPR_DOCUMENTOS> TPR_DOCUMENTOS { get; set; }
        public DbSet<TPR_TIPOS_PROGRAMACION> TPR_TIPOS_PROGRAMACION { get; set; }
        public DbSet<VM_PAG_LISTA_VALORES> VM_PAG_LISTA_VALORES { get; set; }
        public DbSet<BANCOS> BANCOS { get; set; }
        public DbSet<LIBRETAS> LIBRETAS { get; set; }
        public DbSet<LIBROS_BANCO> LIBROS_BANCO { get; set; }
        public DbSet<MONEDAS> MONEDAS { get; set; }
        public DbSet<CUENTAS_BANCARIAS> CUENTAS_BANCARIAS { get; set; }
        public DbSet<COLA_PARAMETROS_REPORTES> COLA_PARAMETROS_REPORTES { get; set; }
    }
}
