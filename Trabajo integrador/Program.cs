/*
 * Created by SharpDevelop.
 * User: Windows
 * Date: 2/6/2021
 * Time: 18:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Trabajo_integrador
{		
	//creo mis propias excepciones
	
		class OEpcionxception:Exception{} 
		
		class ExisteEmpleadoException: Exception
		{
			public string mensajedni;
			public ExisteEmpleadoException (string m)
			{	
				mensajedni=m;
			}
		
		}

		class DatoInvalidoException: Exception
		{
			public string mensaje;
        	public DatoInvalidoException(string m)
        	{
            	mensaje = m;
        	}
		}
		
		class NroTicketInvalidoException:Exception
		{
			public string mensajeTicket;
			public NroTicketInvalidoException(string m)
			{
				mensajeTicket=m;
			}
		
		}
		
	class Program
	{
		
			
		public static void Main(string[] args)
		{
			
			//declaro variables 
			int opcion=0;
			Farmacia farmacia=new Farmacia();
		
			DateTime f1=new DateTime(2021,06,01,12,30,00);
			DateTime f2=new DateTime(2021,06,18,13,12,00);
			DateTime f3=new DateTime(2021,06,04,11,21,15);
			//instancio ventas de ejemplo
			Venta venta1=new Venta("La sante","amoxicilina","pami",1,f1,1,800);
			farmacia.agregarVenta(venta1);
			Venta venta2=new Venta("tafirol","paracetamol","osde",2,f2,2,300);
			farmacia.agregarVenta(venta2);
			Venta venta3=new Venta("Termofren","paracetamol","osecac",1,f1,3,500);
			farmacia.agregarVenta(venta3);
			Venta venta4=new Venta("bago","nitrofurantoina","particular",1,f1,4,820.50);
			farmacia.agregarVenta(venta4);
			Venta venta5=new Venta("actron","ibuprofeno","pami",1,f2,5,700);
			farmacia.agregarVenta(venta5);
			Venta venta6=new Venta("anaflex","paracetamol","osecac",3,f3,6,460);
			farmacia.agregarVenta(venta6);
			//instancio empleados de ejemplo
			Empleado empleado1=new Empleado("Tony","Stark",12457896,1);
			Empleado empleado2=new Empleado("Bruce","Banner",21456398,2);
			Empleado empleado3=new Empleado("Natasha","Romanoff",14523698,3);
			farmacia.agregarEmp(empleado1);
			farmacia.agregarEmp(empleado2);
			farmacia.agregarEmp(empleado3);
			
			
			//bucle de MENU PRINCIPAL
			do{
				Console.Clear(); //limpia la pantalla
				Console.WriteLine("____________________________________________________________________________________________________");
				Console.WriteLine("___________________________________________FARMACIA_________________________________________________");
				Console.WriteLine("____________________________________________________________________________________________________");
				Console.WriteLine("menu principal: ");
				Console.WriteLine("	");
				Console.WriteLine("1) Agregar una venta de medicamento");
				Console.WriteLine("2) Eliminar venta de medicamento por N° de ticket");
				Console.WriteLine("3) Informar porcentaje de ventas realizadas en la primer quincena que hayan sido por obra social");
				Console.WriteLine("4) Listar todas las ventas de los medicamentos segun droga");
				Console.WriteLine("5) Agregar Empleado");
				Console.WriteLine("6) Borrar empleado");
				Console.WriteLine("7) Listado de Empleados");
				Console.WriteLine("8) Salir del programa");
				Console.WriteLine("____________________________________________________________________________________________________");
				Console.Write("Elija una opcion: ");
				
				//manejo de excepcion en menu
				try
				{
				opcion=int.Parse(Console.ReadLine()); //agrego esta linea en el try ya que usuario podria agregar una letra 
				
				}
				
				//este manejador controla si el ingreso del dato no es el formato que esperaba
				catch(FormatException){ 
					
					Console.WriteLine("El dato ingresado No es una opcion valida...");
					Console.WriteLine("Presione cualquier letra para volver al menu principal...");
					Console.ReadKey(true);
                    continue;
				}
				
				//creo este manejador general para controlar cualquier otra excepcion que surja
				catch (Exception){
					
					Console.WriteLine("Ha ocurrido un error");
					Console.WriteLine("Presione cualquier letra para volver al menu principal...");
					Console.ReadKey(true);
					continue;
				}
				
				switch(opcion){
						
						case 1: //agregar venta
								MenuAgregoVenta(farmacia);
								break;
								
						case 2: //eliminar venta por nro de ticket	
								MenuEliminoVenta(farmacia);
								break;
						
						case 3: //porcentaje
								MenuPorcentaje(farmacia);
								break;
							
						case 4: //lista de medicamentos segun droga
								MenuListaPorDroga(farmacia);
								break;
							
						case 5:	//agregar empleado	
								MenuAgregoEmpleado(farmacia);
								break;
							
						case 6: //borrar empleado
								MenuBorrarEmpleado(farmacia);
								break;
								
						case 7: //Lista de empleados
								MenuListaEmpleados(farmacia);
								break;
								
							
						case 8: //salgo del programa				
								break;
						
						default:
								
								Console.WriteLine("El numero que elegio no existe en este menu, elija nuevamente");
								Console.ReadKey(true);
								break;
					}
			
				}
			
			while(opcion!=8);
			
			
			Console.ReadKey(true);
			
		}//FIN MAIN
		
			
		public static int porcentajeVentas(Farmacia farmacia) //retorno el porcentaje de ventas dentro de los 15 dias que hayan sido por obra social
		{
			ArrayList OS=new ArrayList(); //armo una lista auxiliar donde guardo las ventas con obra social
			int conteoOS=0; //conteo de la lista
			int porcentaje=0;
			
			
			foreach(Venta v in farmacia.todasVen())
			{
				if(v.ObraSocial!="particular" && v.FechaHora.Day<=15 && v.FechaHora.Month== DateTime.Today.Month)
				{
					OS.Add(v);
				}
			}
			conteoOS=OS.Count;
			try
			{
				porcentaje=conteoOS*100/farmacia.cantidadVentas();//verifico que la cantidad de ventas no sea cero
			}
			
			catch(DivideByZeroException){ //si es cero,atrapo el error y aviso que no hay ventas
				Console.WriteLine("No hay ventas");
			}
			
			return porcentaje;
			
		}
		public static void MenuAgregoVenta(Farmacia farmacia)
		{
			try{
					Console.WriteLine("Ingrese los siguientes datos para agregar la venta");
											
					Console.Write("Nombre comercial: ");
					string nom=Console.ReadLine();
											
					Console.Write("Droga del medicamento: ");
					string dro=Console.ReadLine();
											
					Console.Write("Obra social/particular: ");
					string os=Console.ReadLine();
											
					Console.Write("Codigo de empleado: ");
					int cod=int.Parse(Console.ReadLine());
											
					DateTime fechaAhora=DateTime.Now;
									
					Console.Write("Numero de ticket-factura: ");
					int ticket=int.Parse(Console.ReadLine());
											
					Console.WriteLine("Importe: ");
					int importe=int.Parse(Console.ReadLine());
														
					Venta unaV=new Venta(nom,dro,os,cod,fechaAhora,ticket,importe);
					farmacia.agregarVenta(unaV);
					Console.WriteLine("La venta se agrego correctamente");
					
					Console.WriteLine("presione cualquier tecla para volver al menu principal...");
					Console.ReadKey(true);
						
				}
				
			catch(FormatException)
				{				
					Console.WriteLine("No se pudo agregar la venta!! Hubo un error en la carga de datos.");
					Console.WriteLine("Presione cualquier tecla para volver al menu principal...");
					Console.ReadKey(true);
		                 
				}
								
			//poniendo exception capturamos cualquier tipo de exception
			catch(Exception)
				{
									
					Console.WriteLine("Se produjo un error!!");
					Console.WriteLine("Presione cualquier tecla para volver al menu principal...");
					Console.ReadKey(true);
			
				}
					
			}
			
		public static void MenuEliminoVenta(Farmacia farmacia)
		{
			try{
					Console.Write("ingrese numero de ticket para borrar la venta: ");
					int nroticket=int.Parse(Console.ReadLine());
								
					if(farmacia.existeTicket(nroticket)==true)//si el numero de ticket existe, se elimina la venta
					{
						farmacia.eliminarVenta(nroticket);
					}
								
					else //si el numero de ticket no existe, se lanza la excepcion
					{
						throw new NroTicketInvalidoException("Numero de ticket invalido");
					}
								
					Console.WriteLine("Presione cualquier tecla para volver al menu principal...");
					Console.ReadKey(true);
				}
								
				catch(NroTicketInvalidoException n)
				{
					Console.WriteLine(n.mensajeTicket);
					Console.WriteLine("Presione cualquier tecla para volver al menu principal...");
					Console.ReadKey(true);
								
				}
				catch(Exception)
				{
					Console.WriteLine("error en el ingreso del numero de ticket");
					Console.WriteLine("Presione cualquier tecla para volver al menu principal...");
					Console.ReadKey(true);
				}
				
		}
			
		public static void MenuPorcentaje(Farmacia farmacia)
		{
				Console.Write("El porcentaje de ventas realizadas en la primer quincena que han sido por obra social es del {0} %",porcentajeVentas(farmacia));
				Console.WriteLine("");
				Console.WriteLine("Presione cualquier tecla para volver al menu principal...");
				Console.ReadKey(true);
		}
		
		public static void MenuListaPorDroga(Farmacia farmacia)
		{
				Console.Write("Ingrese el nombre de la droga por la cual quiere listar las ventas de medicamento: ");
				string droga=Console.ReadLine();
				int conteo=0;
								
				Console.WriteLine("---------------------------------------------------");
								
				foreach(Venta v in farmacia.todasVen())
				{
						if(droga==v.Droga)
						{
							Console.WriteLine("Nombre Comercial del medicamento: {0}", v.NomComercial);
							Console.WriteLine("Droga: {0}",v.Droga);
							Console.WriteLine("Obra Social o particular: {0}",v.ObraSocial);
							Console.WriteLine("codigo de empleado: {0}",v.CodEmpleado);
							Console.WriteLine("fecha y hora: {0}", v.FechaHora);
							Console.WriteLine("Numero de ticket-factura: {0}", v.NTicketFactura);
							Console.WriteLine("importe: {0}",v.Importe);
							Console.WriteLine("---------------------------------------------------");
							conteo++;
						}
									
				}
			
				Console.WriteLine("En el mes de {0} se realizaron {1} ventas en total con la droga {2}",DateTime.Now.ToString("MMMMM"),conteo,droga);
				Console.WriteLine("");
				Console.ReadKey(true);
		}
			
		public static void MenuAgregoEmpleado(Farmacia farmacia)
		{
			try{
					Console.WriteLine("Ingrese los siguientes datos para agregar al empleado");
					
					Console.Write("Nombre: ");
					string nom=Console.ReadLine();
								
					Console.Write("Apellido: ");
					string ape=Console.ReadLine();
								
					Console.Write("Numero de DNI: ");
					int dni=int.Parse(Console.ReadLine());
								
					int codigoemp=farmacia.cantidadEm()+1;
								
					if (nom=="" | ape=="" | dni<0 )
				    {
					  throw new DatoInvalidoException("Hay un error en los datos ingresados, el empleado no fue dado de alta");//lanzo excepcion
				  	}
								
					if(farmacia.existeEmpleado(dni)==false)
					{
						Empleado Emp=new Empleado(nom,ape,dni,codigoemp);
						farmacia.agregarEmp(Emp);
						Console.WriteLine("se agrego correctamente el empleado");
					}
								
					else
					{
						throw new ExisteEmpleadoException("Ya existe un empleado con el DNI ingresado");//lanzo mi propia excepcion
					}
							
					Console.WriteLine("presione cualquier tecla para volver al menu principal...");
					Console.ReadKey(true);
				}
								
				catch(DatoInvalidoException m)
				{
					Console.WriteLine(m.mensaje);
					Console.ReadKey(true);
				}
				catch(ExisteEmpleadoException m)
				{
					Console.WriteLine(m.mensajedni);
					Console.ReadKey(true);
				}
								
				catch(Exception)
				{
					Console.WriteLine("hubo un error");
					Console.ReadKey(true);
				}
		}
			
		public static void MenuBorrarEmpleado(Farmacia farmacia)
		{
				Console.WriteLine("");
				Console.Write("Ingrese el codigo de empleado a borrar: ");
				int codig=int.Parse(Console.ReadLine());
				Console.WriteLine("");
							
				//Empleado aux=new Empleado("","",0,0);
				Empleado aux=null;
							
				foreach(Empleado e in farmacia.todosEmp())
				{
					if(codig==e.CodigoEmpleado)
					{
						aux= e;
						Console.WriteLine("el empleado:");
						Console.WriteLine("nombre: {0}",aux.Nombre);
						Console.WriteLine("apellido: {0}",aux.Apellido);
						Console.WriteLine("dni: {0}", aux.Dni);
									
					}
								
				}
							
				farmacia.eliminarEmp(aux);
				Console.WriteLine("El empleado se elimino correctamente");
				Console.WriteLine("---------------------------------------------------");
				Console.ReadKey(true);
		}
			
		public static void MenuListaEmpleados(Farmacia farmacia)
		{
			Console.WriteLine("");
			Console.WriteLine("Listado de empleados en la farmacia");
			Console.WriteLine("");
			Console.WriteLine("Hay un total de {0} empleados", farmacia.cantidadEm());
			Console.WriteLine("---------------------------------------------------");
							
			foreach(Empleado v in farmacia.todosEmp())
			{
				Console.WriteLine("Nombre: {0}", v.Nombre);
				Console.WriteLine("Apellido: {0}",v.Apellido);
				Console.WriteLine("DNI: {0}",v.Dni);
				Console.WriteLine("codigo de empleado: {0}",v.CodigoEmpleado);
				Console.WriteLine("---------------------------------------------------");
									
			}
			
			Console.ReadKey(true);
		}
		
	}
}