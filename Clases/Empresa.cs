using Clases.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Empresa
    {
        #region Atributos
        private List<Empleado> empleados;
        private Dictionary<int, Empleado> diccionarioEmpleados;
        private Stack<Empleado> pilaEmpleados;
        private static DateTime inicioActividades;
        private string nombre;

        #endregion

        #region Propiedades
        public static DateTime InicioActividades { get => inicioActividades; set => inicioActividades = value; }
        public List<Empleado> Empleados { get => empleados; set => empleados = value; }
        public Dictionary<int, Empleado> DiccionarioEmpleados { get => diccionarioEmpleados; set => diccionarioEmpleados = value; }
        public Stack<Empleado> PilaEmpleados { get => pilaEmpleados; set => pilaEmpleados = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        #endregion

        #region Constructores
        private Empresa() //private para no generar una empresa sin nombre
        {
            empleados = new List<Empleado>();
            diccionarioEmpleados = new Dictionary<int, Empleado>(); 
            pilaEmpleados = new Stack<Empleado>();

        }

        public Empresa(string nombre):this()
        {
            this.nombre = nombre;
        }

        static Empresa()
        {
            inicioActividades = DateTime.Now;
        }


        #endregion

        #region metodos

        public bool AñadirEmpleado(Empleado empleado)
        {
            bool agrego;
            agrego = false;
            if (!BuscarEmpleado(empleado))
            {
                this.empleados.Add(empleado); //agregar un empleado a la lista
                this.diccionarioEmpleados.Add(empleado.Id, empleado); //agregar un empleado a un diccionario
               // this.diccionarioEmpleados[empleado.Id] = empleado; //agregar un empleado a un diccionario
                this.pilaEmpleados.Push(empleado); //apilar un empleado
                agrego = true;
            }
            else
            {
                throw new EmpleadoNoEncotradoException("El empleado ya se encuentra en la lista", empleado); 
            }
            return agrego;
      
        }

        private bool BuscarEmpleado(Empleado unEmpleado)
        {
            bool existe;
            existe = false;

            foreach(Empleado empleado in this.empleados)
            {
                if (empleado == unEmpleado)
                {
                    existe = true;
                    break;
                }
            }
            // en foreach evitar el uso del else

            return existe;
        }

        public string MostrarEmpleados()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var empleado in empleados)
            {
                sb.Append(empleado.MostrarInformacion());
            }
            return sb.ToString();
        }

        public Empleado BuscarPorId(int id)//cambiar por dni
        {
            Empleado emp;
            emp = null;
            if (this.diccionarioEmpleados.ContainsKey(id))
            {
                emp = this.diccionarioEmpleados[id];
            }
            else
            {
                throw new EmpleadoNoEncotradoException($"No se encuentra el empleado con id: {id} en la nómina");
            }

            return emp;
        }

        public string MostrarUltimoEmpleado()
        {
            string cadena;
            cadena = "No hay empleados en la pila";
            if(this.pilaEmpleados.Count > 0)
            {
                var ultimo = this.pilaEmpleados.Peek();
                cadena = ultimo.MostrarInformacion();
            }
            return cadena;
        }
        #endregion
    }
}
