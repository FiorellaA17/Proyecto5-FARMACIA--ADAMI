
using System;

namespace Trabajo_integrador
{
	
	public class Empleado
	{
		//atributos
		private string nombre;
		private string apellido;
		private int dni;
		private int codigoEmpleado;
		
		
		//constructores
		public Empleado(string nombre, string apellido, int dni, int codigoEmp)
		{
			this.nombre=nombre;
			this.apellido=apellido;
			this.dni=dni;
			this.codigoEmpleado=codigoEmp;
		}
		
		//propiedades
		
		public string Nombre
		{
			set{nombre=value;}
			get{return nombre;}
		}
		
		public string Apellido
		{
			set{apellido=value;}
			get{return apellido;}
		}
		
		public int Dni
		{
			set{dni=value;}
			get{return dni;}
		}

		public int CodigoEmpleado
		{
			set{codigoEmpleado=value;}
			get{return codigoEmpleado;}
		}
	}
}
