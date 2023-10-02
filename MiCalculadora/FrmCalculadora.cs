using Entidades;
using System.ComponentModel;

namespace MiCalculadora
{
    public partial class FrmCalculadora : Form
    {
        private Operacion calculadora;
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private Numeracion resultado;
        private ESistema sistema;

        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void setResultado()
        {
            if (cmbOperacion.SelectedItem != null && cmbOperacion.SelectedItem != "")
            {
                this.calculadora = new Operacion(this.primerOperando, this.segundoOperando);
                char operador = char.Parse(cmbOperacion.SelectedItem.ToString());
                this.resultado = calculadora.Operar(operador);
                string resultadoTxt = "";
                if (this.resultado != null)
                {
                    if (this.sistema == this.resultado)
                    {
                        resultadoTxt = this.resultado.Valor.ToString();
                    }
                    else
                    {
                        resultadoTxt = this.resultado.ConvertirA(this.sistema);
                    }
                    lblResultado.Text = String.Format("Resultado: {0}", resultadoTxt);
                }
            }
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtPrimerOperador.Text = string.Empty;
            this.txtSegundoOperador.Text = string.Empty;
            this.lblResultado.Text = "Resultado:";
            this.resultado = null;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (cmbOperacion.SelectedItem != null && txtPrimerOperador.Text != "" && txtSegundoOperador.Text != "")
            {
                this.setResultado();
            }
        }

        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            string closingTxt = "¿Desea cerrar la calculadora?";
            string closingCaption = "Cierre";
            DialogResult closing = MessageBox.Show(closingTxt, closingCaption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (closing == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            this.sistema = ESistema.Binario;
            this.setResultado();
        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            this.sistema = ESistema.Decimal;
            this.setResultado();
        }

        private void txtprimerOperador_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in txtPrimerOperador.Text)
            {
                if (!(c < '0' || c > '9'))
                {
                    this.primerOperando = new Numeracion(txtPrimerOperador.Text, ESistema.Decimal);
                }
                else
                {
                    this.primerOperando = null;
                    this.txtPrimerOperador.Text = "";
                }
            }
        }

        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in txtSegundoOperador.Text)
            {
                if (!(c < '0' || c > '9'))
                {
                    this.segundoOperando = new Numeracion(txtSegundoOperador.Text, ESistema.Decimal);
                }
                else
                {
                    this.segundoOperando = null;
                    this.txtSegundoOperador.Text = "";
                }
            }
        }
    }
}