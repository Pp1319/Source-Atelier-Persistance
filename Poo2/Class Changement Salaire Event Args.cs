using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Poo3
{
    public class ChangementSalaireEventArgs : EventArgs
    {
        private decimal _ancienSalaire;
        private decimal _nouveauSalaire;

        public ChangementSalaireEventArgs(decimal ancienSalaire, decimal nouveauSalaire)
        {
            AncienSalaire = ancienSalaire;
            NouveauSalaire = nouveauSalaire;
        }

        public decimal AncienSalaire { get => _ancienSalaire; set => _ancienSalaire = value; }
        public decimal NouveauSalaire { get => _nouveauSalaire; set => _nouveauSalaire = value; }
    }
}
