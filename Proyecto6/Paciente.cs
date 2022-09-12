/*
 * Creado por SharpDevelop.
 * Usuario: nico
 * Fecha: 4/6/2022
 * Hora: 14:54
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Proyecto6
{
	/// <summary>
	/// Description of Paciente.
	/// </summary>
	public class Paciente:Persona
	{	
		private string diagnostico;
		private string medicoDesignado;
		
		public Paciente(string nom,string ape, int numDni,string diagnos):base(nom,ape,numDni)
		{
			diagnostico = diagnos;
		}
		
		public string Diagnostico{
			get{return diagnostico;}
			set{diagnostico = value;}
		}
		
		public string MedicoDesignado{
			get{return medicoDesignado;}
			set{medicoDesignado = value;}
		}
		
		public Paciente()
		{
		}
	}
}
