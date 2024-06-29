using Clases.Excepciones;
using System.Text;

namespace Clases
{
    public abstract class Empleado
    {
        #region Atributos
        protected int id;
        protected string nombre;
        protected string apellido;
        protected int edad;
        protected string departamento;
        #endregion

        #region Propiedades
        //Implementar Excepciones propias
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }  
            set
            {
                apellido = value;
            }
        }

        public int Edad
        {
            get
            {
                return edad;
            }
            set
            {
              edad = value;
            }
        }

        public string Departamento
        {
            get
            {
                return departamento;
            }
            set
            {
                departamento = value;
            }
        }

        public int Id
        { 
            get => id; 
            set => id = value; 
        }
        #endregion

        #region Constructores
        //Implementar sobrecarga de constructores
        public Empleado(string nombre, string apellido, int edad, string departamento, int id):
            this(id, nombre, apellido, edad)
        {
            this.departamento = departamento;

        }

        public Empleado(int id, string nombre, string apellido, int edad)
        {            
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.id = id;
        }

        #endregion

        #region Metodos

        // Método abstracto CalcularSalario
        protected abstract float CalcularSalario();

        // Método virtual MostrarInformacion: implementar con StringBuilder
        public virtual string MostrarInformacion()
        {
            // se usa string builder porq una vez definidos son inmutables
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Id: " + this.id);
            sb.AppendLine("Nombre: " + this.nombre);
            sb.AppendLine("Apellido: " + this.apellido);
            sb.AppendLine("Edad: " + this.edad);
            sb.AppendLine("Departamento: " + this.departamento);
            
            return sb.ToString(); 
        }
        //Sobrecarga del metodo MostrarInformacion(string formato). Si formato es "corto" muestra el id y
        //el nombre y apellido concatenados separado por coma
        public virtual string MostrarInformacion(string formato)
        {
            string dato;

            dato = $"Id: {this.id} -- Nombre: {this.apellido}, {this.nombre}";
            
            if (formato != "Corto")
            {
                dato = MostrarInformacion();
            }

            return dato;
        }


        #endregion

        #region Sobrecarga de operadores
        // Sobrecarga de operador ==

        public static bool operator ==(Empleado a, Empleado b)
        {
            bool esIgual;
            esIgual = false;
            if(a.Id == b.Id && a.apellido == b.apellido)
            {
                esIgual = true;
            }

            return esIgual;
        }

        public static bool operator !=(Empleado a, Empleado b)
        {
            return !(a == b);
        }

        #endregion


    }
}