
using System;

namespace Trabajo_integrador
{
	
	public class Venta
	{
		//atributos
		private string nomComercial;
		private string droga;
		private string obraSocial;
		private int codEmpleado;
		private DateTime fechaHora;
		private int nTicketFactura;
		private double importe;
		
		//constructores
		public Venta(string nomComercial,string droga, string obraSocial,int codEmpleado,DateTime fechahora, int nroticket, double importe)
		{
			this.nomComercial=nomComercial;
			this.droga=droga;
			this.obraSocial=obraSocial;
			this.codEmpleado=codEmpleado;
			this.nTicketFactura=nroticket;
			this.importe=importe;
			this.fechaHora=fechahora;
			
		}
		
		//propiedades
		public string NomComercial
		{
			set{nomComercial=value;}
			get{return nomComercial;}
		}
		
		public string Droga
		{
			set{droga=value;}
			get{return droga;}
		}
		
		public string ObraSocial
		{
			set{obraSocial=value;}
			get{return obraSocial;}
		}
		
		public int CodEmpleado
		{
			set{codEmpleado=value;}
			get{return codEmpleado;}
		}
		
		public DateTime FechaHora
		{
			set{fechaHora=value;}
			get{return fechaHora;}
		}
		
		public int NTicketFactura
		{
			set{nTicketFactura=value;}
			get{return nTicketFactura;}
		}
		
		public double Importe
		{
			set{importe=value;}
			get{return importe;}
		}
		
		
	}
}
