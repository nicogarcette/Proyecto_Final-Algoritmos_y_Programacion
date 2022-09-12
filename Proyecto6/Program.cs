/*
 * Creado por SharpDevelop.
 * Usuario: nico
 * Fecha: 4/6/2022
 * Hora: 14:43
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Proyecto6
{
	class Program
	{
		public static void Main(string[] args)
		{
//			Clinica.
			Clinica cl1 = new Clinica("san martin");

//			medicos. los creo en el programa
			Medico m1 = new Medico("pedro","gonzalez",1,1,"cirujia","noche");
			Medico m2 = new Medico("sergio","gotta",1234,10,"odontologia","tarde");
			Medico m3 = new Medico("doctor","milagro",1234,10,"dermatologo","noche");
			
//			servicios.
			Servicio s1 = new Servicio("cirujia",m1,3);
			Servicio s2 = new Servicio("odontologia",m1,2);
			Servicio s3 = new Servicio("dermatologo",m1,2);
			
//			agrego servicios a la clinica
			cl1.agregarServicio(s1);
			cl1.agregarServicio(s2);
			cl1.agregarServicio(s3);
//   		agrego medico al servicio
			cl1.agregarMedico(m1);
			cl1.agregarMedico(m2);
			cl1.agregarMedico(m3);
			
			bool terminarPrograma=false;
			
			while (!terminarPrograma) {
//				imprime opciones y lee la opcion del usuario. Tambien valida que la opcion este entre el rango de opciones.
				int opc = validarOpcionIngresada();
				
				switch (opc) {
						case 1:
							agregarMedico(cl1);
							break;
						case 2:
							eliminarMedico(cl1);
							break;
						case 3:
							internarPaciente(cl1);
						break;
						case 4:
							guardiaNocturna(cl1);
							break;
						case 5:
							darAlta(cl1);
						break;
						case 6:
							listadoServicios(cl1);
							break;
						case 7:
							listadoMedicos(cl1);
							break;
						case 8:
							listadoPacientes(cl1);
							break;
						case 0:
							terminarPrograma = true;
							break;
				}
			}
			Console.ReadKey(true);
		}
//		funcion para validar la opcion ingresada por el usuario
		public static int validarOpcionIngresada(){
		
			const string opciones = "********************Opciones********************\n\n1)Agregar un médico.\n2)Eliminar un médico dado.\n3)Internar un paciente.\n4)Listado de los servicios de guardia.\n5)Dar el alta a paciente internado.\n6)Listado de servicios\n7)Listado de médicos\n8)Listado de pacientes de un servicio.\n0)Salir";
			int opc = 10;
			bool valido;
			
			do
			{
				Console.WriteLine(opciones);
//				exception para que el usuario no ingrese un dato que no es numero
				try{
					opc = int.Parse(Console.ReadLine());
					}
				catch (FormatException){
  					Console.WriteLine("Solo ingresa números por favor!");
				}
				if (opc >= 0 && opc <= 8 ) {
					valido=true;
				} else{
					valido = false;
					Console.WriteLine("Ingrese opcion correcta!!\n");
				}
				
			}while (!valido) ;
	
			return opc;
		}
		
//		el usuario ingresa los datos del medico,se crea la instancia medico y se agrega al servicio correspondiente
		public static void agregarMedico(Clinica clinica){
			
			Console.Write("ingrese nombre:");
			string nom = Console.ReadLine();
			Console.Write("ingrese apellido:");
			string ape = Console.ReadLine();
			Console.Write("ingrese dni:");
			int dni = int.Parse(Console.ReadLine());
			Console.Write("ingrese N de legajo:");
			int legajo = int.Parse(Console.ReadLine());
			Console.Write("ingrese especialidad:");
			string especialidad = Console.ReadLine();
			Console.Write("ingrese turno:");
			string turno = Console.ReadLine();
			
			Medico aux = new Medico(nom,ape,dni,legajo,especialidad,turno);
			
			bool confirmarAgregado = clinica.agregarMedico(aux);
			
			if (confirmarAgregado) {
				Console.WriteLine("Medico {0}, agregado con exito!\n",ape);
			}else{
				Console.WriteLine("error");
			}
		}
//		llama a la función eliminarMedico de clinica, que buscará entre sus servicios y eliminará al medico por legajo
		public static void eliminarMedico(Clinica clinica){
			
			Console.Write("ingrese N de legajo:");
			int legajo = int.Parse(Console.ReadLine());
			bool confirmarEliminado = clinica.eliminarMedico(legajo);
			
			if (confirmarEliminado) {
				Console.WriteLine("Medico eliminado con éxito!\n");
			}else{
				Console.WriteLine("error");
			}
		}
		
//		el usuario ingresa los datos del Paciente,se crea la instancia Paciente y se lo agrega a las camas del servicio bajo el cuidado del medico correspondiente
		public static void internarPaciente(Clinica clinica){
			
			Console.Write("ingrese nombre:");
			string nom = Console.ReadLine();
			Console.Write("ingrese apellido:");
			string ape = Console.ReadLine();
			Console.Write("ingrese dni:");
			int dni = int.Parse(Console.ReadLine());
			Console.Write("ingrese diagnostico:");
			string diagnostico = Console.ReadLine();
			
			Paciente aux = new Paciente(nom,ape,dni,diagnostico);
			Console.WriteLine("Especialidad de servicio :");
			string especialidad = Console.ReadLine();
			Console.WriteLine("Legajo del médico a cargo :");
			int legajo = int.Parse(Console.ReadLine());
			
			try {
				bool confirmar = clinica.internarPaciente(aux, especialidad, legajo);
				if (!confirmar) {
					throw new cupoException();
				}
				else{
					Console.WriteLine("Internado con éxito");
				}
			} catch (cupoException) {
				Console.WriteLine("No hay cupo");
				throw;
			}
		}
//		llama a la función darAlta de clinica, que buscara el servicio en que esta internado el paciente, lo removera a este y a su medico designado	
		public static void darAlta(Clinica clinica){
			Console.WriteLine("Ingrese dni del paciente: ");
			int dni = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el servicio el servicio en que se encuentra el paciente: ");
			string servicio = Console.ReadLine();
			bool confirmarAlta = clinica.darAlta(dni, servicio);
			
			if (confirmarAlta) {
				Console.WriteLine("Paciente dado de alta!\n");
			}else{
				Console.WriteLine("error");
			}	
		}
//		imprime por consola el listado de servicios con medicos en guardia nocturna
		public static void guardiaNocturna(Clinica clinica){
			string listado = "";
			foreach (Servicio element in clinica.Servicios) {
				bool verificacion = element.horarioNocturno();
				if (verificacion) {
					listado += element.Especialidad + " " + "\n";
				}
			}
			if (listado == "") {
				listado = "No existen servicios con guardia nocturna";
			}
			Console.WriteLine(listado);
		}
		
//		llama al metodo listado de servicios e imprime el retorno del metodo
		public static void listadoServicios(Clinica clinica){
			
			string listado = clinica.listadoServicios();
			Console.WriteLine(listado);	
		}
//		llama al metodo listado de medicos e imprime el retorno del metodo
		public static void listadoMedicos(Clinica clinica){	
			string listado = clinica.listadoMedicos();
			Console.WriteLine(listado);
		}
//		llama al metodo listado de pacientes e imprime el retorno del metodo
		public static void listadoPacientes(Clinica clinica){	
			string listado = clinica.listadoPacientes();
			Console.WriteLine(listado);
		}
	}
}