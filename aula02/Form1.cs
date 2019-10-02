using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aula02
{
    public partial class Form1 : Form
    {
        private decimal altura;
        private decimal peso;
        private int[] dias;
        private List<int> anos;
        private Dictionary<int, string> meses;

        public Form1()
        {
            InitializeComponent();

            dias = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };

            anos = new List<int>()
            {
                1994,
                1995,
                1996,
                1997,
                1998,
                1999,
                2000,
                2001,
                2002,
                2003
            };

            anos.Add(2004);

            meses = new Dictionary<int, string>()
            {
                {1, "Janeiro" },
                {2, "Fevereiro" },
                {3, "Março" },
                {4, "Abril" },
                {5, "Maio" },
                {6, "Junho" },
                {7, "Julho" },
                {8, "Agosto" },
                {9, "Setembro" },
                {10, "Outubro" },
                {11, "Novembro" },
                {12, "Dezembro" }
            };

            /* 
            int indice = 0;
            //dias.Leght é o tamanho que no caso do dias, o tamanho é 31 devido o array. Enquanto indice for menor que 31, irá executar o While(Enquanto)
            while(indice < dias.Length)
            {
                cbxDias.Items.Add(dias[indice]);
                indice++;
            }
            Vai criar uma variavel inteira chamada i que vai receber 0, se o int é menor que o dias.lenght vai executar, 
            depois de executado vai adicionar +1, enquanto for verdadeiro, quando for falso(atingir 31) sai da execusão
            */
            for(int i = 0; i < dias.Length; i++)
            {
                cbxDias.Items.Add(dias[i]);
            }
            //foreach significa "para cada", no caso, para cada ano vai adicionar na variável anos
            foreach(int ano in anos)
            {
                cbxAnos.Items.Add(ano);
            }

            //É de onde está buscando os dados, ou seja de onde vai receber as informações para preencher os campos vem dos meses
            cbxMeses.DataSource = new BindingSource(meses, null);
            cbxMeses.DisplayMember = "Value";
            cbxMeses.ValueMember = "Key";
        }
        private string VerificarImc(decimal peso, decimal altura, out decimal imc)
        {
            imc = peso / (altura * altura);
            if (imc < (decimal)18.5)
            {
                return "Abaixo do peso";
            }
            else if (imc >= (decimal)18.5 && imc < 25)
            {
                return "Peso normal";
            }
            else if (imc >= 25 && imc < 30)
            {
                return "Sobrepeso";
            }
            else if (imc >= 30 && imc < 35)
            {
                return "Obesidade grau 1";
            }
            else if (imc >= 35 && imc < 39)
            {
                return "Obesidade grau 2";
            }
            else
            {
                return "Obesidade grau 3";
            }
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            //TryParse retorna um bool
            //Sinal ! inverte o valor, por exemplo, se der verdadeiro não vai entrar no if, se der falso vai entrar
            if(!decimal.TryParse(textAltura.Text, out altura))
            {
                MessageBox.Show("Altura inválida");
            }
            if (!decimal.TryParse(textPeso.Text, out peso))
            {
                MessageBox.Show("Peso inválida");
            }

            var descricao = VerificarImc(peso, altura, out var imc);
            MessageBox.Show($"Nome: {nome}\nNascimento: {cbxDias.Text} de {cbxMeses.Text} de {cbxAnos.Text}\nIMC: {imc.ToString("N2")}\n\n{descricao}");
        }
    }
}
