/*
 * Creado por SharpDevelop.
 * Usuario: nico
 * Fecha: 4/6/2022
 * Hora: 15:43
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;

namespace Proyecto6
{
	/// <summary>
	/// Description of Clinica.
	/// </summary>
	public class Clinica
	{	
		private string nombre;
		private ArrayList servicios;
		
		public Clinica(string nom)
		{
			nombre=nom;
			servicios = new ArrayList();
		}
//		Retorna el listado de servicios de la clinica
		public string listadoServicios(){
			string acumulador = "--Servicios--\n";
			
			foreach (Servicio element in servicios) {
				if (element!=null) {
					acumulador += element.Especialidad + "("+ element.listaMedicos() + ")" + "\n";
				}
			}
			return acumulador;
		}
		public void agregarServicio(Servicio aux){
		
			servicios.Add(aux);
		}
		
//	funcion agregarMedico si especialidad de servicio es igual a especialidad del medico, agrega
//	abstracion de los servicios.Ir a buscar los servicios correspondientes.
// metodos que pertenecen al servicio, pero se debe hacer la busqueda en la clinica
		
		public bool agregarMedico(Medico aux){
			bool agrego = false;
			
			foreach (Servicio element in servicios) {
				
				if (element.Especialidad == aux.Especialidad) {
					element.agregarMedico(aux);
					agrego = true;
				}
			}
			return agrego;
		}
		
//		función que invoca eliminarMedico de cada servicio
		public bool eliminarMedico(int legajo ){

			foreach (Servicio element in servicios) {
				if (element.eliminarMedico(legajo)) {
					return true;
				}	
			}
			return false;
		}
		
//		función que invoca internarPaciente del servicio especificado
		public bool internarPaciente(Paciente paciente, string especialidad, int legajo){
			bool confirmar = false;
			foreach (Servicio element in servicios) {
				if (element.Especialidad == especialidad) {
					confirmar = element.internarPaciente(paciente, legajo);
				}
			}
			return confirmar;
		}
		
//		función que invoca darAlta del servicio especificado
		public bool darAlta(int dni, string servicio){
			foreach (Servicio element in servicios) {
				if (element.Especialidad == servicio) {
					return element.darAlta(dni);
				}
			}
			return false;
		}
		
//		retorna una lista de todos los medicos en la clinica
		public string listadoMedicos(){
			string listado = "";
			foreach (Servicio element in servicios) {
				listado += element.listaMedicos() + "\n";
			}
			return listado;
		}

//		retorna una lista de todos los pacientes en la clinica
		public string listadoPacientes(){
			string listado = "";
			foreach (Servicio element in servicios) {
				listado += element.listaPacientes() + "\n";
			}
			return listado;
		}
		public ArrayList Servicios{
			get{return servicios;}
			set{servicios = value;}
		}
		public string Nombre{
			get{return nombre;}
			set{nombre = value;}
		}
		public Clinica()
		{
			servicios = new ArrayList();
		}
		
	}
}
