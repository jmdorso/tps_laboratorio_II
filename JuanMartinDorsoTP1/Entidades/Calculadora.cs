using System;

namespace Entidades
{
    public static class Calculadora
    {
        #region "Metodos"
        /// <summary>
        /// Metodo de clase que valida y realiza la operacion pedida entre 2 numeros
        /// </summary>
        /// <param name="num1">El primer numero a operar (Operando)</param>
        /// <param name="num2">El segundo numero a operar(Operando)</param>
        /// <param name="operador">El signo de la operacion que quiero realizar(char)</param>
        /// <returns>el resultado de la operacion</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char operadorAuxiliar;
            double resultado = 0;

            
            operadorAuxiliar = ValidarOperador(operador);

            switch (operadorAuxiliar)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }


        /// <summary>
        /// Metodo para validar que el operador ingresado sea un '+','-','/' o '*'. 
        /// </summary>
        /// <param name="operador">El operador ingresado (char)</param>
        /// <returns>retorna el operador ingresado o en caso de no ser ningun operador valido, retorna un "+"</returns>
        private static char ValidarOperador(char operador)
        {
            char operadorAuxiliar;

            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                operadorAuxiliar = operador;
            }
            else
            {
                operadorAuxiliar = '+';
            }
            return operadorAuxiliar;
        }

        #endregion
    }
}
