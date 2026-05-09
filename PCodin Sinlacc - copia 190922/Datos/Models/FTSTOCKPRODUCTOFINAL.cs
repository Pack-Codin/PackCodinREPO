using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCodin_Sinlacc.Datos.Models
{
    internal class FTSTOCKPRODUCTOFINAL
    {
        public string ProductoID { get; set; } = string.Empty;
        public string Producto { get; set; } = string.Empty;
        public int MedidaID { get; set; }
        public string Medida { get; set; } = string.Empty;
        public decimal Existencia { get; set; }
        public decimal ExistenciaPallets { get; set; }
        public decimal PendienteEntregarPallets { get; set; }
        public decimal StockRealPallets { get; set; }
        public decimal PendienteEntregar { get; set; }
        public decimal StockReal { get; set; }
        public decimal PendienteProducir { get; set; }
        public decimal Existenciaref { get; set; }
        public decimal PendienteEntregaRef { get; set; }
        public decimal StockRealRef { get; set; }
        public decimal StockMinimo { get; set; }
        public int CategoriaID { get; set; }
        public decimal ValorUnidadPeso { get; set; }
        public decimal ValorUnidadDolar { get; set; }


    }
}
