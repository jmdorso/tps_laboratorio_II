using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        #region "Atributo"
        private double numero;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor que iniciliza con el valor pasado por parametro tipo Double, a una instancia de tipo Operando
        /// </summary>
        /// <param name="numero">valor a instanciar en el Operando (double)</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }
        
        /// <summary>
        /// Constructor que inicializa con el valor pasador por parametro de tipo string, utilizando la propiedad Numero, a una instancia de tipo Operando
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        /// <summary>
        /// Constructor por defecto que iniciliza en 0 un objeto de tipo Operando reutilizando el constructor con parametro
        /// </summary>
        public Operando()
            : this(0)
        {

        }
        #endregion

        #region "Propiedad"
        /// <summary>
        /// Propiedad que valida el dato recibido y lo asigna a numero
        /// </summary>
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Valida que el parametro recibido sea numerico
        /// </summary>
        /// <param name="strNumero">parametro recibido en formato string</param>
        /// <returns>retorna el valor en formato double o en caso de fallar, devuelve 0</returns>
        private double ValidarOperando(string strNumero)
        {
            double auxRetorno;

            if (!(Double.TryParse(strNumero, out auxRetorno)))
            {
                auxRetorno = 0;
            }

            return auxRetorno;
        }

        /// <summary>
        /// Valida que la cadena este compuestas por 0 y 1. Transforma el parametro string en un arrays de char y compara 1 x 1.
        /// </summary>
        /// <param name="binario">cadena a validar(formato string)</param>
        /// <returns>retorna true si son ceros y unos sino retorna false si tiene algun otro caracter</returns>
        private static bool EsBinario(string binario)
        {
            bool auxRetorno = true;
            char[] arrayBinario = binario.ToCharArray();

            for (int i = 0; i < arrayBinario.Length; i++)
            {
                if (arrayBinario[i] != '0' && arrayBinario[i] != '1')
                {
                    auxRetorno = false;
                    break;
                }
            }

            return auxRetorno;
        }

        /// <summary>
        /// Recibe un string binario, comprobamos si cumple los requisitos de un numero binario, y lo convierte a decimal
        /// </summary>
        /// <param name="binario">numero binario a controlar y covnertir a decimal(formato string)</param>
        /// <returns>retorna el numero decimal en formato string en caso de poder, sino, devuelve "Valor invalido"</returns>
        public string BinarioDecimal(string binario)
        {
            string auxRetorno = "Valor Invalido";
            double numeroDecimalAcumulado = 0;
            char[] arrayBinario = binario.ToCharArray();
            Array.Reverse(arrayBinario);

            //Lo que hacemos dentro del if, es recorrer el array invertido, y si en tal posicion hay un numero 1, 
            //se hace 2 elevado a i(posicion actaul del array)
            //en el else, si el numero ingresado no es binario, quiere decir que ya es decimal,entonces lo devuelve.
            //esto lo hago por si se aprieta el boton convertir a decimal, ya estando en decimal el numero.
            if (EsBinario(binario))
            {
                for (int i = 0; i < arrayBinario.Length; i++)
                {
                    if (arrayBinario[i] == '1')
                    {
                        numeroDecimalAcumulado += Math.Pow(2, i);//2 elevado a i, se va acumulando. 
                    }
                }
                auxRetorno = numeroDecimalAcumulado.ToString();
            }
            else
            {
                auxRetorno = binario;
            }

            return auxRetorno;
        }

        /// <summary>
        /// Recibe un numero decimal en formato double y lo transforma en un numero binario si es posible
        /// </summary>
        /// <param name="numero">parametro a controlar y convertir(formato double)</param>
        /// <returns>retorna un numero binario en un string, o "valor invalido" en caso de no poder realizarse</returns>
        public static string DecimalBinario(double numero)
        {
            string auxRetorno = "Valor Invalido";
            string numeroAuxiilar = numero.ToString();
            long numeroSinSigno;

            ///Controlo que si el numero que le pasamos ya es un binario, devuelva el binario ya ingresado
            ///esto es por si ya apretamos el boton de convertir, para que no siga convirtiendo sobre un numero binario
            if (!EsBinario(numeroAuxiilar))
            {
                numeroSinSigno = Convert.ToInt64(Math.Abs(numero));
                if (numero > 0)
                {
                    auxRetorno = Convert.ToString(numeroSinSigno, 2);
                }
            }
            else
            {
                auxRetorno = numeroAuxiilar;
            }

            return auxRetorno;
        }

        /// <summary>
        /// Recibe un numero decimal en formato string, lo convierte en double, reutiliza el metodo ya creado y lo transforma en un numero binario si es posible
        /// </summary>
        /// <param name="numero">parametro a controlar y convertir(formato string)</param>
        /// <returns>retorna un numero binario en un string, o "valor invalido" en caso de no poder realizarse</returns>
        public static string DecimalBinario(string numero)
        {
            string auxRetorno = "Valor Invalido";
            double numeroDecimal;

            if (Double.TryParse(numero, out numeroDecimal))
            {
                auxRetorno = DecimalBinario(numeroDecimal);
            }

            return auxRetorno;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Metodo que suma 2 objetos del tipo Operando
        /// </summary>
        /// <param name="n1">primer numero a operar (tipo Operando)</param>
        /// <param name="n2">segundo numero a operar (tipo Operando)</param>
        /// <returns>el resultado de la operacion aritmetica en formato double</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            double resultado;

            resultado = n1.numero + n2.numero;

            return resultado;
        }

        /// <summary>
        /// Metodo que resta 2 objetos del tipo Operando
        /// </summary>
        /// <param name="n1">primer numero a operar (tipo Operando)</param>
        /// <param name="n2">segundo numero a operar (tipo Operando)</param>
        /// <returns>el resultado de la operacion aritmetica en formato double</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            double resultado;

            resultado = n1.numero - n2.numero;

            return resultado;
        }

        /// <summary>
        /// Metodo que divide 2 objetos del tipo Operando
        /// </summary>
        /// <param name="n1">primer numero a operar (tipo Operando)</param>
        /// <param name="n2">segundo numero a operar (tipo Operando)</param>
        /// <returns>el resultado de la operacion aritmetica en formato double o en caso de ser una division por 0, retorna double.MinValue</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double resultado;

            if (n2.numero == 0)
            {
                resultado = double.MinValue;
            }
            else
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }

        /// <summary>
        /// Metodo que multiplica 2 objetos del tipo Operando
        /// </summary>
        /// <param name="n1">primer numero a operar (tipo Operando)</param>
        /// <param name="n2">segundo numero a operar (tipo Operando)</param>
        /// <returns>el resultado de la operacion aritmetica en formato double</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            double resultado;

            resultado = n1.numero * n2.numero;

            return resultado;
        }
        #endregion
    }
}
