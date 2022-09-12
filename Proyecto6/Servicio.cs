/*
 * Creado por SharpDevelop.
 * Usuario: nico
 * Fecha: 4/6/2022
 * Hora: 14:59
 */
using System;
using System.Collections;

namespace Proyecto6
{
	/// <summary>
	/// Description of Servicio.
	/// </summary>
	public class Servicio
	{	
		private string especialidad;
		private Medico jefe;
		private ArrayList medicos;
		private int cupoCamas;
		private Paciente[] pacientes;
			
		public Servicio(string especialidad, Medico jefe, int cupo){
			this.especialidad = especialidad;
			this.jefe = jefe;
			cupoCamas = cupo;
			pacientes = new Paciente[cupo];
			medicos = new ArrayList();
		}
//		funcion agregarMedico si especialidad de servicio es igual a especialidad del medico, agrega
		public void agregarMedico(Medico aux){
			medicos.Add(aux);
		}
//		función de eliminarMedico por número de legajo
		public bool eliminarMedico(int legajo){
			
			for (int i = 0; i < medicos.Count; i++) {
				Medico aux1=(Medico)medicos[i];
				if (aux1.NumeroLegajo == legajo) {
					medicos.RemoveAt(i);
					return true;
				}
			}
			return false;
		}	
		
//		interna un paciente con un médico determinado
		public bool internarPaciente(Paciente paciente, int legajo){
			for (int i = 0; i < pacientes.GetLength(0); i++) {
				if (pacientes[i] == null) {
					foreach (Medico element in medicos) {
						if (element.NumeroLegajo == legajo) {
							paciente.MedicoDesignado = element.Apellido;
						}
					}
					cupoCamas--;
					pacientes[i] = paciente;
					return true;
				}
			}
			return false;
		}
//		dar de alta paciente.busca paciente por dni, si lo encuentra elimina.
		public bool darAlta(int dni){
			for (int i = 0; i < pacientes.GetLength(0); i++) {
				if (pacientes[i]!=null) {
					if (pacientes[i].Dni == dni) {
						pacientes[i] = null;
						return true;
					}
				}
			}
			return false;
		}
//		retorna un string con la lista de medicos
		public string listaMedicos(){

			string acumulador = "--Medicos de " + especialidad +"--\n";
			
			foreach (Medico element in medicos) {
				if (element != null) {
					acumulador += element.Nombre+" "+ element.Apellido+"\n";
				}
			}
			return acumulador;
		}
		public string listaPacientes(){

			string acumulador = "--Pacientes en " + especialidad +"--\n";
			
			foreach (Paciente element in pacientes) {
				if (element != null) {
					acumulador += element.Nombre+" "+element.Apellido+"\n";
				}
			}
			return acumulador;
		}
//		retorna un string con la lista de medicos de horario nocturno
		public bool horarioNocturno(){
			bool verificacion = false;
			foreach (Medico element in medicos) {
				if (element.Horario == "noche") {
					verificacion = true;
					break;					
				}
			}
			return verificacion;
		}
		public ArrayList Medicos{
			get{return medicos;}
			set{medicos = value;}
		}
		public Medico Jefe{
			get{return jefe;}
			set{jefe = value;}
		}
		public Paciente[] Pacientes{
			get{return pacientes;}
			set{pacientes = value;}
		}
		public int CupoCamas{
			get{return cupoCamas;}
			set{cupoCamas = value;}
		}
		public string Especialidad{
			get{return especialidad;}																							
		}
		public Servicio()
		{
			medicos= new ArrayList();
			pacientes=new Paciente[5];
			
		}
	}
}
