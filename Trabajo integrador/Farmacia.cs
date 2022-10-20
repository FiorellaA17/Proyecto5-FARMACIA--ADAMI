
using System;
using System.Collections;

namespace Trabajo_integrador
{
	public class Farmacia
	{
		//atributos
		
		private ArrayList ventas=new ArrayList();
		private ArrayList empleados=new ArrayList();
		
		
		//contructores
		
		public Farmacia()
		{

		}
		
		//metodos
		public void agregarVenta(Venta unaV) //agrego una venta
		{	
			ventas.Add(unaV);
		}
		
		
		public void eliminarVenta(int nroticket) //elimino una venta
		{	
			Venta auxv=new Venta("","","",0,DateTime.Now,0,0);
			foreach(Venta t in ventas)
				{
				if(t.NTicketFactura==nroticket)
					{
					auxv=t;
					}

				}
			ventas.Remove(auxv);
			Console.WriteLine("La venta se elimino correctamente");
	
		}
		
		
		public Venta verVenta(int i) //ver la venta iesima
		{
			return (Venta)ventas[i];
		}
									
		
		public int cantidadVentas() //devuelve la cantidad de ventas
		{
			return ventas.Count;
		}
		
		
		public void agregarEmp(Empleado em) //agrega empleado
		{
			empleados.Add(em);
			
		}
		
		public void eliminarEmp(Empleado em) //elimina empleado
		{
			empleados.Remove(em);
		}
		
		public Empleado verEmp(int i) //retorna el empleado iesimo
		{
			return (Empleado)empleados[i];
		}
		
		public ArrayList todosEmp() //devuelve la lista de empleados en la farmacia
		{
			return empleados;
		}
		
		public int cantidadEm() //devuvelve la cantidad de empleados
		{	
			return empleados.Count;
		}
		
		public ArrayList todasVen() //devuelve la lista de ventas en la farmacia
		{	
			return ventas;
		}
			
		
		public bool existeEmpleado(int dni)//funcion que devuelve true si en el arraylist existe un empleado que coincida con el dni que se ingreso
        {
            foreach (Empleado e in empleados)
            {
                if (e.Dni == dni)
                {
                    return true;   
                }
            }
            
            return false;
		}
		
		public bool existeTicket(int ticket)//funcion que devuelve true si existe en el arraylist de ventas el numero de tricket que se ingreso 
		{
			foreach(Venta t in ventas)
			{
				if(t.NTicketFactura==ticket)
				{
					return true;
				}
			}
			
			return false;
		}
	
	}
}

