using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poo3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }

        private void EventValidated(object sender, EventArgs e)
        {
            Salarie sal = new Salarie("Peyramard", "Florian", "65pio89");
            sal.SalaireBrut = 1500m;
            sal.ChangementSalaire += Salaire_ChangementSalaire;
            sal.SalaireBrut = decimal.Parse(textBox1.Text);
        }
        private void Salaire_ChangementSalaire(object sender,ChangementSalaireEventArgs e)
        {
            MessageBox.Show(string.Format("Le salaire de base {0} a été augmenté à {1} augmentation {2}",e.AncienSalaire, e.NouveauSalaire,Calcultxaug(e.AncienSalaire,e.NouveauSalaire)));
        }
        private decimal Calcultxaug(decimal anciensal, decimal nouveausal)
        {
            decimal calcultxaug = ((nouveausal - anciensal) / anciensal) * 100;
            return calcultxaug;
        }

    }
}
