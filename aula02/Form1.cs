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

            int indice = 0;
            while(indice < dias.Length)
            {
                cbxDias.Items.Add(dias[indice]);
                indice++;
            }
            for(int i = 0; i < dias.Length; i++)
            {
                cbxDias.Items.Add(dias[i]);
            }
            //
            foreach(int ano in anos)
            {
                cbxAnos.Items.Add(ano);
            }

            //
            cbxMeses.DataSource = new BindingSource(meses, null);
            //
            cbxMeses.DisplayMember = "Value";
            //
            cbxMeses.ValueMember = "Key";
        }
    }
}
