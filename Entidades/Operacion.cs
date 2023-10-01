using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operacion
    {
        private Numeracion primerOperando;
        private Numeracion segundoOperando;

        public Numeracion PrimerOperando
        {
            get
            {
                return this.primerOperando;
            }
            set
            {
                this.primerOperando = value;
            }
        }
        public Numeracion SegundoOperando
        {
            get
            {
                return this.segundoOperando;
            }
            set
            {
                this.segundoOperando = value;
            }
        }

        public Operacion(Numeracion primerOperando, Numeracion segundoOperando)
        {
            PrimerOperando = primerOperando;
            SegundoOperando = segundoOperando;
        }
        public Numeracion Operar(char operador)
        {
            Numeracion resultado = null;
            if (primerOperando != null && segundoOperando != null)
            {
                if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
                {
                    switch (operador)
                    {
                        case '-':
                            resultado = primerOperando - segundoOperando;
                            break;
                        case '*':
                            resultado = primerOperando * segundoOperando;
                            break;
                        case '/':
                            resultado = primerOperando / segundoOperando;
                            break;
                        default:
                            resultado = primerOperando + segundoOperando;
                            break;
                    }
                }
            }
            return resultado;
        }
    }
}
