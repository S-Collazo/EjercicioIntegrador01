namespace Entidades
{
    public enum ESistema
    {
        Decimal,
        Binario
    }

    public class Numeracion
    {
        private ESistema sistema;
        private double valorNumerico;

        public ESistema Sistema
        {
            get
            {
                return this.sistema;
            }
        }
        public string Valor
        {
            get
            {
                return ConvertirA(this.sistema);
            }
        }

        public Numeracion(double valor, ESistema sistema)
        {
            string valorConvertido = Convert.ToString(valor);
            IncializarValores(valorConvertido, sistema);
        }
        public Numeracion(string valor, ESistema sistema)
        {
            IncializarValores(valor, sistema);
        }


        private void IncializarValores(string valor, ESistema sistema)
        {
            this.sistema = sistema;
            if (sistema == ESistema.Binario)
            {
                this.valorNumerico = Convert.ToDouble(Convert.ToInt32(valor, 2));
            }
            else if (sistema == ESistema.Decimal && Double.TryParse(valor, out double valorDecimal))
            {
                this.valorNumerico = valorDecimal;
            }
            else
            {
                this.valorNumerico = Double.MinValue;
            }

        }
        public string ConvertirA(ESistema sistema)
        {
            string conversion = "";

            if (sistema == ESistema.Decimal)
            {
                conversion = Convert.ToString(BinarioADecimal(Convert.ToString(this.valorNumerico)));
            }
            else
            {
                conversion = DecimalABinario(Convert.ToString(this.valorNumerico));
            }
            return conversion;
        }
        private bool EsBinario(string valor)
        {
            foreach (char c in valor)
            {
                if (!(c != 0 || c != 1))
                {
                    return false;
                }
            }
            return true;
        }
        private double BinarioADecimal(string valor)
        {
            int valorConvertido = Convert.ToInt32(Convert.ToDecimal(valor));
            valorConvertido = Math.Abs(valorConvertido);
            string stringConvertido = Convert.ToString(valorConvertido);

            double valorDecimal = 0;
            if (EsBinario(stringConvertido) && Double.TryParse(stringConvertido, out double conversion))
            {
                valorDecimal = conversion;
            }
            return valorDecimal;
        }
        private string DecimalABinario(int valor)
        {
            int valorConvertido = Math.Abs(valor);
            string conversion = Convert.ToString(valorConvertido, 2);

            string valorBinario = "Numero invalido";
            if (EsBinario(conversion))
            {
                valorBinario = conversion;
            }
            return valorBinario;
        }
        private string DecimalABinario(string valor)
        {
            int valorConvertido = Convert.ToInt32(Convert.ToDecimal(valor));
            string valorBinario = DecimalABinario(valorConvertido);

            return valorBinario;
        }

        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            if (n2 is not null && n1.Sistema == n2.Sistema)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return !(n1 == n2);
        }
        public static bool operator ==(ESistema sistema, Numeracion numeracion)
        {
            if (sistema == numeracion.Sistema)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(ESistema sistema, Numeracion numeracion)
        {
            return !(sistema == numeracion);
        }
        public static Numeracion operator +(Numeracion n1, Numeracion n2)
        {
            double suma = n1.valorNumerico + n2.valorNumerico;

            Numeracion resultado = new(suma, n1.Sistema);
            return resultado;
        }

        public static Numeracion operator -(Numeracion n1, Numeracion n2)
        {
            double resta = n1.valorNumerico - n2.valorNumerico;

            Numeracion resultado = new(resta, n1.Sistema);
            return resultado;
        }
        public static Numeracion operator *(Numeracion n1, Numeracion n2)
        {
            double multiplicacion = n1.valorNumerico * n2.valorNumerico;

            Numeracion resultado = new(multiplicacion, n1.Sistema);
            return resultado;
        }
        public static Numeracion operator /(Numeracion n1, Numeracion n2)
        {
            if(n2.valorNumerico == 0)
            {
                n2.valorNumerico = 1;
            }
            double division = n1.valorNumerico / n2.valorNumerico;
  
            Numeracion resultado = new(division, n1.Sistema);
            return resultado;
        }
    }
}