/*
 * Creado por SharpDevelop.
 * Usuario: nico
 * Fecha: 4/6/2022
 * Hora: 14:47
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Proyecto6
{
	/// <summary>
	/// Description of Medico.
	/// </summary>
	public class Medico:Persona
	{	
		private int numeroLegajo;
		private string especialidad;
		private string horario;
		
		public Medico(string nom,string ape, int numDni,int legajo,string especialidad,string turno):base(nom,ape,numDni)
		{
			numeroLegajo = legajo;
			this.especialidad = especialidad;
			horario = turno;
		}
		public int NumeroLegajo{
			get{return numeroLegajo;}
			set{numeroLegajo = value;}
		}
		public string Horario{
			get{return horario;}
			set{horario = value;}
		}
		public string Especialidad{
			get{return especialidad;}
			set{especialidad = value;}
		}
		public Medico()
		{
		}
	}
}
