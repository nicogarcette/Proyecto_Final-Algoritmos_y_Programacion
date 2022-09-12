/*
 * Creado por SharpDevelop.
 * Usuario: nico
 * Fecha: 4/6/2022
 * Hora: 14:44
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Proyecto6
{
	/// <summary>
	/// Description of Persona.
	/// </summary>
	public class Persona
	{	
		protected string nombre;
		protected string apellido;
		protected int dni;
		
		public Persona(string nom, string ape, int numDni){
			nombre = nom;
			apellido = ape;
			dni = numDni;
		}
		public string Nombre{
			get{return nombre;}
			set{nombre = value;}
		}
		public string Apellido{
			get{return apellido;}
			set{apellido = value;}
		}
		public int Dni{
			get{return dni;}
			set{dni = value;}
		}
		public Persona()
		{
		}
	}
}
