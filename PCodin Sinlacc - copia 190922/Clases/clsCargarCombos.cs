using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCodin_Sinlacc.Datos;

namespace PCodin_Sinlacc.Clases
{
    class clsCargarCombos
    {
        public static void MostrarComboZona(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from T in hb.ZONA
                                where T.Estado == "SI"
                                orderby T.Descripcion
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Descripcion,
                                    Estado = T.Estado
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarCategorias(ComboBox Combo, TextBox Text, bool Pulso)
        {
            using (var hb = new DBdatos())
            {
                if (Pulso == false)
                {

                    var Consulta = (from T in hb.Categorias_InsPro
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion,
                                        Estado = T.Estado
                                    });                   

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;

                }
                else
                {
                    var Consulta = (from T in hb.Categorias_InsPro
                                    where (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text))
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion,
                                        Estado = T.Estado
                                    });
                    
                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        
        public static void MostrarComboConceptosAI(ComboBox Combo, TextBox Text, CheckBox chekAI,bool Pulso)
        {
            using (var hb = new DBdatos())
            {
                if (Pulso == false)
                {

                    var Consulta = (from T in hb.Tipo_Gasto
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion,
                                        Estado = T.Estado
                                    });

                    if (chekAI.Checked)
                        Consulta = (from C in Consulta
                                    where C.Estado == "SI"
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    where C.Estado == "NO"
                                    select C);

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;

                }
                else
                {
                    var Consulta = (from T in hb.Tipo_Gasto
                                    where (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text))
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion,
                                        Estado = T.Estado
                                    });

                    if (chekAI.Checked)
                        Consulta = (from C in Consulta
                                    where C.Estado == "SI"
                                    select C);
                    else
                        Consulta = (from C in Consulta
                                    where C.Estado == "NO"
                                    select C);

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboConcepto(ComboBox Combo, TextBox Text, bool Pulso)
        {
            using (var hb = new DBdatos())
            {
                if (Pulso == false)
                {

                    var Consulta = (from T in hb.Tipo_Gasto
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion,
                                        Estado = T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;

                }
                else
                {
                    var Consulta = (from T in hb.Tipo_Gasto
                                    where (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text))
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion,
                                        Estado = T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboInsProConMedida(ComboBox Combo, ComboBox ComboMedida ,TextBox Text, string InsPro,bool Filtro)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Productos_Insumos
                                    where T.Ins_Prod == InsPro
                                        && T.Estado == "SI"
                                        && T.Pallet == "NO"
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion + " - " + T.Codigo, 
                                        T.Medida,
                                        T.Medidas_Producto.Descripcion
                                    }) ;

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    ComboMedida.ValueMember = "Medida";
                    ComboMedida.DisplayMember = "Descripcion";
                    Combo.DataSource = Resultados;
                    ComboMedida.DataSource = Resultados;
                }
                if(Filtro == true)
                {
                    var Consulta = (from T in hb.Productos_Insumos
                                    where (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text) || T.Codigo == Text.Text) && T.Ins_Prod == InsPro
                                    && T.Estado == "SI"
                                    && T.Pallet == "NO"
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion + " - " + T.Codigo,
                                        T.Medida,
                                        T.Medidas_Producto.Descripcion
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    ComboMedida.ValueMember = "Medida";
                    ComboMedida.DisplayMember = "Descripcion";
                    Combo.DataSource = Resultados;
                    ComboMedida.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboInsProConMedida2(ComboBox Combo, ComboBox ComboMedida, TextBox Text, string InsPro, bool Filtro) // sin subproducto
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Productos_Insumos
                                    where T.Ins_Prod == "INS"
                                        && T.Subproducto == "NO"
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion + " - " + T.Codigo,
                                        T.Medida,
                                        T.Medidas_Producto.Descripcion
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    ComboMedida.ValueMember = "Medida";
                    ComboMedida.DisplayMember = "Descripcion";
                    Combo.DataSource = Resultados;
                    ComboMedida.DataSource = Resultados;
                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Productos_Insumos
                                    where (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text) || T.Codigo == Text.Text) && T.Ins_Prod == InsPro
                                    && T.Subproducto == "NO"
                                    && T.Ins_Prod == "INS"
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion + " - " + T.Codigo,
                                        T.Medida,
                                        T.Medidas_Producto.Descripcion
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    ComboMedida.ValueMember = "Medida";
                    ComboMedida.DisplayMember = "Descripcion";
                    Combo.DataSource = Resultados;
                    ComboMedida.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboInformes(ComboBox Combo, TextBox Text, bool Filtro )
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Informes
                                    orderby T.ID
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion + " - " + T.ID,
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Informes
                                    where (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text))
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion + " - " + T.ID,
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;                    
                }
            }
        }
        public static void MostrarComboInformesSegunModulo(ComboBox Combo, TextBox Text, bool Filtro,int ModuloID)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Informes
                                    where T.Modulo_ID == ModuloID
                                    orderby T.ID
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion + " - " + T.ID,
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Informes
                                    where (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text))
                                        && T.Modulo_ID == ModuloID
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion + " - " + T.ID,
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboProducto(ComboBox Combo, TextBox Text, bool Filtro, CheckBox CheckAI)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Productos_Insumos
                                    where T.Ins_Prod == "PRO" && T.Estado == "SI"
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion,
                                        T.Estado                                      
                                    });

                    if (CheckAI.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Estado == "SI"
                                    select C);
                    }
                    else
                    {
                        Consulta = (from C in Consulta
                                    where C.Estado == "NO"
                                    select C);
                    }

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";                    
                    Combo.DataSource = Resultados;
                    
                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Productos_Insumos
                                    where (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text) || T.Codigo == (Text.Text)) && T.Ins_Prod == "PRO"
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    if (CheckAI.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Estado == "SI"
                                    select C);
                    }
                    else
                    {
                        Consulta = (from C in Consulta
                                    where C.Estado == "NO"
                                    select C);
                    }

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboArticuloPorCodigo(ComboBox Combo , string CodigoArticulo)
        {
            using (var hb = new DBdatos())
            {
                
                
                   
                   
                        var Consulta = (from T in hb.Productos_Insumos
                                        where
                                        T.Codigo == CodigoArticulo
                                        orderby T.Descripcion
                                        select new
                                        {
                                            Id = T.Codigo,
                                            Tittle = T.Descripcion + " - " + T.Codigo,
                                            T.Estado
                                        });

                        var Resultados = Consulta.ToList();

                        Combo.ValueMember = "Id";
                        Combo.DisplayMember = "Tittle";
                        Combo.DataSource = Resultados;
                    
                
            }
        }
        public static void MostrarComboMedioPago(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {




                var Consulta = (from T in hb.MEDIOPAGO
                                where
                                T.Visible == "SI"
                                orderby T.Descripcion
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Descripcion,                                  
                                });

                var Resultados = Consulta.ToList();

                Resultados.Insert(0, new { Id = 0, Tittle = "" });

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
                Combo.SelectedIndex = 0;

            }
        }
        //public static void MostrarComboMedioPago2(ComboBox Combo)
        //{
        //    using (var hb = new DBdatos())
        //    {




        //        var Consulta = (from T in hb.MEDIOPAGO
        //                        where
        //                        T.Visible == "SI"
        //                        orderby T.Descripcion
        //                        select new
        //                        {
        //                            Id = T.ID,
        //                            Tittle = T.Descripcion,
        //                        });

        //        var Resultados = Consulta.ToList();

        //        Combo.ValueMember = "Id";
        //        Combo.DisplayMember = "Tittle";
        //        Combo.DataSource = Resultados;


        //    }
        //}
        public static void MostrarComboArticuloPorCodigo(ComboBox Combo, TextBox Text , string CodigoArticulo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from T in hb.Productos_Insumos
                                where T.Codigo == CodigoArticulo 
                                    && T.Estado == "SI"                              
                                orderby T.Descripcion
                                select new
                                {
                                    Id = T.Codigo,
                                    Tittle = T.Descripcion + " - " + T.Codigo,
                                    T.Estado
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarComboInsProSinCheck(ComboBox Combo, TextBox Text, string INSPRO,bool Filtro, string Subproducto)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Productos_Insumos
                                    where T.Ins_Prod == INSPRO && T.Estado == "SI"
                                        && T.Subproducto == Subproducto
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion + " - " + T.Codigo,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;

                }
                if (Filtro == true)
                {
                    var ConsultaCodBarra = (from COD in hb.CODIGOBARRA
                                            where COD.CodigoBarra1 == Text.Text
                                                && COD.Estado == "SI"
                                            select new
                                            {
                                                Id = COD.Producto_ID,
                                                Tittle = COD.Productos_Insumos.Descripcion + " - " + COD.Productos_Insumos.Codigo
                                            });


                    if (ConsultaCodBarra.ToList().Count > 0)
                    {
                        var Resultados1 = ConsultaCodBarra.ToList();

                        Combo.ValueMember = "Id";
                        Combo.DisplayMember = "Tittle";
                        Combo.DataSource = Resultados1;
                    }
                    else
                    {
                        var Consulta = (from T in hb.Productos_Insumos
                                        where
                                        (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text) || T.Codigo == Text.Text)
                                        && T.Estado == "SI"
                                        orderby T.Descripcion
                                        select new
                                        {
                                            Id = T.Codigo,
                                            Tittle = T.Descripcion + " - " + T.Codigo,
                                            T.Estado
                                        });

                        var Resultados = Consulta.ToList();

                        Combo.ValueMember = "Id";
                        Combo.DisplayMember = "Tittle";
                        Combo.DataSource = Resultados;
                    }
                }
            }
        }
        public static void MostrarComboSubProductos(ComboBox Combo, TextBox Text, bool Filtro)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Productos_Insumos
                                    where T.Subproducto == "SI" && T.Estado == "SI"
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion + " - " + T.Codigo,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;

                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Productos_Insumos
                                    where T.Subproducto == "SI" &&
                                    (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text) || T.Codigo == Text.Text)
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion + " - " + T.Codigo,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboInsPro(ComboBox Combo, TextBox Text, bool Filtro)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Productos_Insumos
                                    where T.Estado == "SI"
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion + " - " + T.Codigo,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;

                }
                if (Filtro == true)
                {
                    
                    var ConsultaCodBarra = (from COD in hb.CODIGOBARRA
                                            where COD.CodigoBarra1 == Text.Text
                                                && COD.Estado == "SI"
                                            select new
                                            {
                                                Id = COD.Producto_ID,
                                                Tittle = COD.Productos_Insumos.Descripcion + " - " + COD.Productos_Insumos.Codigo
                                            });


                    if (ConsultaCodBarra != null)
                    {
                        var Resultados1 = ConsultaCodBarra.ToList();

                        Combo.ValueMember = "Id";
                        Combo.DisplayMember = "Tittle";
                        Combo.DataSource = Resultados1;
                    }
                    else
                    {
                        var Consulta = (from T in hb.Productos_Insumos
                                        where
                                        (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text) || T.Codigo == Text.Text)
                                        orderby T.Descripcion
                                        select new
                                        {
                                            Id = T.Codigo,
                                            Tittle = T.Descripcion + " - " + T.Codigo,
                                            T.Estado
                                        });

                        var Resultados = Consulta.ToList();

                        Combo.ValueMember = "Id";
                        Combo.DisplayMember = "Tittle";
                        Combo.DataSource = Resultados;
                    }
                }
            }
        }
        public static void MostrarComboArticulosMagdalena(ComboBox Combo, TextBox Text, bool Filtro)
        {
            using (var hb = new DBdatos2())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.ARTICULO
                                    where T.Visible == 1
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion + " - " + T.Codigo,                                        
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;

                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.ARTICULO
                                    where
                                    (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text) || T.Codigo == Text.Text)
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion + " - " + T.Codigo,                                      
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        //public static void MostrarComboInsPro(ComboBox Combo, TextBox Text, bool Filtro)
        //{
        //    using (var hb = new DBdatos())
        //    {
        //        if (Filtro == false)
        //        {
        //            var Consulta = (from T in hb.Productos_Insumos
        //                            where T.Estado == "SI"
        //                            orderby T.Descripcion
        //                            select new
        //                            {
        //                                Id = T.Codigo,
        //                                Tittle = T.Descripcion + " - " + T.Codigo,
        //                                T.Estado
        //                            });

        //            var Resultados = Consulta.ToList();

        //            Combo.ValueMember = "Id";
        //            Combo.DisplayMember = "Tittle";
        //            Combo.DataSource = Resultados;

        //        }
        //        if (Filtro == true)
        //        {
        //            var Consulta = (from T in hb.Productos_Insumos
        //                            where
        //                            (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text) || T.Codigo == Text.Text)
        //                            orderby T.Descripcion
        //                            select new
        //                            {
        //                                Id = T.Codigo,
        //                                Tittle = T.Descripcion + " - " + T.Codigo,
        //                                T.Estado
        //                            });

        //            var Resultados = Consulta.ToList();

        //            Combo.ValueMember = "Id";
        //            Combo.DisplayMember = "Tittle";
        //            Combo.DataSource = Resultados;
        //        }
        //    }
        //}
        public static void MostrarComboInsumoSegunProductoSeleccionado(ComboBox Combo, ComboBox ComboProducto ,TextBox Text, bool Filtro)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Formula_Producto
                                    where T.Productos_Insumos.Ins_Prod == "INS" 
                                        && T.Producto_ID == ComboProducto.SelectedValue.ToString()
                                        && T.Productos_Insumos.Estado == "SI"
                                    orderby T.Productos_Insumos.Descripcion
                                    select new
                                    {
                                        Id = T.Productos_Insumos.Codigo,
                                        Tittle = T.Productos_Insumos.Descripcion + " - " + T.Productos_Insumos.Codigo,
                                        T.Productos_Insumos.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;

                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Formula_Producto
                                    where T.Productos_Insumos.Ins_Prod == "INS"
                                        && (T.Productos_Insumos.Descripcion.StartsWith(Text.Text) || T.Productos_Insumos.Descripcion.Contains(Text.Text) || T.Productos_Insumos.Codigo == Text.Text)
                                        && T.Producto_ID == ComboProducto.SelectedValue.ToString()
                                    orderby T.Productos_Insumos.Descripcion
                                    select new
                                    {
                                        Id = T.Productos_Insumos.Codigo,
                                        Tittle = T.Productos_Insumos.Descripcion + " - " + T.Productos_Insumos.Codigo,
                                        T.Productos_Insumos.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboInsumoSegunProductoSeleccionado2(ComboBox Combo, string ProductoID, TextBox Text, bool Filtro) // POR PARAMETRO PRODUCTO ID
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Formula_Producto
                                    where T.Productos_Insumos.Ins_Prod == "INS"
                                        && T.Producto_ID == ProductoID
                                        && T.Productos_Insumos.Estado == "SI"
                                    orderby T.Productos_Insumos.Descripcion
                                    select new
                                    {
                                        Id = T.Productos_Insumos.Codigo,
                                        Tittle = T.Productos_Insumos.Descripcion + " - " + T.Productos_Insumos.Codigo,
                                        T.Productos_Insumos.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;

                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Formula_Producto
                                    where T.Productos_Insumos.Ins_Prod == "INS"
                                        && (T.Productos_Insumos.Descripcion.StartsWith(Text.Text) || T.Productos_Insumos.Descripcion.Contains(Text.Text) || T.Productos_Insumos.Codigo == Text.Text)
                                    orderby T.Productos_Insumos.Descripcion
                                    select new
                                    {
                                        Id = T.Productos_Insumos.Codigo,
                                        Tittle = T.Productos_Insumos.Descripcion + " - " + T.Productos_Insumos.Codigo,
                                        T.Productos_Insumos.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarMedidas(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from T in hb.Medidas_Producto
                                where T.Estado == "SI"
                                orderby T.Descripcion
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Descripcion,                                    
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarModulo(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from T in hb.Modulos
                                orderby T.ID
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Nombre,
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarModuloPorUsuario(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var ConsultaModulosActivos = (from C in hb.Acceso_Usuario
                                              where C.Usuario_ID == clsVariablesGenerales.UsuarioID
                                               && C.Menu_Item.Tipo == "Informe"
                                              select new
                                              {
                                                  C.Menu_Item.Modulo_ID
                                              }).Distinct().ToList();

                List<int> ListModulosActivos = new List<int>();

                foreach(var i in ConsultaModulosActivos)
                {
                    ListModulosActivos.Add((int)i.Modulo_ID);
                }

                var Consulta = (from T in hb.Modulos
                                where ListModulosActivos.Contains(T.ID)
                                orderby T.ID
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Nombre,
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarEmpleadosEnLista(CheckedListBox checkedListBox)
        {
            using (var hb = new DBdatos())
            {

                var Consulta = (from T in hb.Empleados
                                where T.Estado == "SI"
                                orderby T.Nombre , T.ID
                                select T);
                               
                var Resultados = Consulta.ToList();

                foreach (var item in Resultados)
                {
                    if (!checkedListBox.Items.Contains(item.Nombre + " - " + item.ID))
                        checkedListBox.Items.Add(item.Nombre + " - " + item.ID);
                }
            }
        }
        //public static void MostrarSeccion(ComboBox Combo)
        //{
        //    using (var hb = new DBdatos())
        //    {
        //        var Consulta = (from S in hb.Seccion
        //                        where S.Estado_ID == "SI"
        //                        orderby S.Descripcion
        //                        select new
        //                        {
        //                            Id = S.ID,
        //                            Tittle = S.Descripcion,
        //                        });

        //        var Resultados = Consulta.ToList();

        //        Combo.ValueMember = "Id";
        //        Combo.DisplayMember = "Tittle";
        //        Combo.DataSource = Resultados;
        //    }
        //}
        public static void MostrarSeccionSegunCircuito(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from S in hb.Seccion_Circuito
                                where S.Seccion.Estado_ID == "SI"
                                orderby S.Orden
                                group S by new { S.Seccion_ID,S.Seccion.Descripcion } into Grupo                             
                                select new
                                {
                                    Id = Grupo.Key.Seccion_ID,
                                    Tittle = Grupo.Key.Descripcion + " - " + Grupo.Key.Seccion_ID
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarSeccion(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from S in hb.Seccion
                                where S.Estado_ID == "SI"
                                orderby S.Descripcion
                                group S by new { S.ID, S.Descripcion } into Grupo
                                select new
                                {
                                    Id = Grupo.Key.ID,
                                    Tittle = Grupo.Key.Descripcion + " - " + Grupo.Key.ID
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarMoneda(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from S in hb.Moneda
                                where S.Estado == "SI"
                                orderby S.Descripcion                               
                                select new
                                {
                                    Id = S.ID,
                                    Tittle = S.Descripcion
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarComboUsuarios(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from S in hb.Usuarios
                                where S.Estado == "SI"
                                orderby S.Nombre
                                select new
                                {
                                    Id = S.ID,
                                    Tittle = S.Nombre
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarModulos(ComboBox ComboModulo,ComboBox ComboItem)
        {
            using (var hb = new DBdatos())
            {
                var ConsultaModulo = (from T in hb.Modulos
                                      orderby T.Nombre
                                      select new
                                      {
                                          IdMod = T.ID,
                                          TittleMod = T.Nombre,
                                      });

                var ResultadosModulo = ConsultaModulo.ToList();

                ComboModulo.ValueMember = "idMod";
                ComboModulo.DisplayMember = "TittleMod";
                ComboModulo.DataSource = ResultadosModulo;

                //if (ComboModulo.SelectedIndex != -1)
                //{
                //    var ConsultaItem = (from T in hb.Menu_Item
                //                        where T.Modulo_ID == (int)ComboModulo.SelectedValue
                //                        orderby T.Descripcion
                //                        select new
                //                        {
                //                            Id = T.ID,
                //                            Tittle = T.Descripcion,
                //                        });



                    
                //    var ResultadosItem = ConsultaItem.ToList();

                    
                //    ComboItem.ValueMember = "Id";
                //    ComboItem.DisplayMember = "Tittle";
                //    ComboItem.DataSource = ResultadosItem;
                    
                //}
            }
        }
        public static void MostrarItem(ComboBox ComboModulo , ComboBox ComoboItem)
        { 
            if(ComboModulo.SelectedIndex != -1)
            {
                using (var hb = new DBdatos())
                {
                    var Consulta = (from T in hb.Menu_Item
                                    where T.Modulo_ID == (int)ComboModulo.SelectedValue
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion,
                                    });

                    var Resultados = Consulta.ToList();

                    ComoboItem.ValueMember = "Id";
                    ComoboItem.DisplayMember = "Tittle";
                    ComoboItem.DataSource = Resultados;
                }
            }
        }
        public static void MostrarItemsTodos(ComboBox ComboModulo, ComboBox ComoboItem)
        {
            if (ComboModulo.SelectedIndex != -1)
            {
                using (var hb = new DBdatos())
                {
                    //var Consulta = (from T in hb.Menu_Item
                    //                where T.Modulo_ID == (int)ComboModulo.SelectedValue
                    //                orderby T.Descripcion
                    //                select new
                    //                {
                    //                    Id = T.ID,
                    //                    Tittle = T.Descripcion,
                    //                });

                    //var Resultados = Consulta.ToList();
                    var Consulta =
                        (
                            from mi in hb.Menu_Item
                            where mi.Estado == "SI"
                                && mi.Modulo_ID == (int)ComboModulo.SelectedValue
                            select new
                            {
                                ID = mi.ID,
                                Tittle = mi.Descripcion,
                                Tipo = "Menu"
                            }

                        ).Concat
                        (
                            from inf in hb.Informes
                            where inf.Modulo_ID == (int)ComboModulo.SelectedValue
                            select new
                            {
                                ID = inf.ID,
                                Tittle = inf.Descripcion,
                                Tipo = "Informe"
                            }

                        );

                    var Resultados = Consulta.ToList();   

                    ComoboItem.ValueMember = "ID";
                    ComoboItem.DisplayMember = "Tittle";
                    ComoboItem.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboInsumosProductos(ComboBox Combo, TextBox Text, bool Filtro , CheckBox CheckAI)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Productos_Insumos
                                    where T.Estado == "SI"
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion + " - " + T.Ins_Prod ,
                                        T.Estado
                                    });

                    if (CheckAI.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Estado == "SI"
                                    select C);
                    }
                    else
                    {
                        Consulta = (from C in Consulta
                                    where C.Estado == "NO"
                                    select C);
                    }

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Productos_Insumos
                                    where (T.Descripcion.Contains(Text.Text) || T.Codigo == Text.Text)
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.Codigo,
                                        Tittle = T.Descripcion + " - " + T.Ins_Prod,
                                        T.Estado
                                    });

                    if (CheckAI.Checked)
                    {
                        Consulta = (from C in Consulta
                                    where C.Estado == "SI"
                                    select C);
                    }
                    else
                    {
                        Consulta = (from C in Consulta
                                    where C.Estado == "NO"
                                    select C);
                    }

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboPuestos(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from T in hb.Puestos
                                where T.Estado == "SI"
                                orderby T.Descripcion
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Descripcion 
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }

        public static void MostrarComboEmpleados(ComboBox Combo, TextBox Text, bool Filtro)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Empleados
                                    where T.Estado == "SI"
                                    orderby T.Nombre
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Nombre,
                                        T.Estado
                                    });                   

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Empleados
                                    where (T.Nombre.StartsWith(Text.Text) || T.Nombre.Contains(Text.Text)) && T.Estado == "SI"
                                    orderby T.Nombre
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Nombre,
                                        T.Estado
                                    });               

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboVendores(ComboBox Combo, TextBox Text, bool Filtro)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Empleados
                                    where T.Estado == "SI"
                                        && T.Puestos.Descripcion == "Vendedor"
                                    orderby T.Nombre
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Nombre,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Empleados
                                    where (T.Nombre.StartsWith(Text.Text) || T.Nombre.Contains(Text.Text)) && T.Estado == "SI"
                                        && T.Puestos.Descripcion == "Vendedor"
                                    orderby T.Nombre
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Nombre,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboEmpleadosPorPuesto(ComboBox Combo, TextBox Text, bool Filtro , int Puesto)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Empleados
                                    where T.Estado == "SI"
                                        && T.Puesto_ID == Puesto
                                    orderby T.Nombre
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Nombre,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Empleados
                                    where (T.Nombre.StartsWith(Text.Text) || T.Nombre.Contains(Text.Text)) && T.Estado == "SI"
                                         && T.Puesto_ID == Puesto
                                    orderby T.Nombre
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Nombre,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboChofer(ComboBox Combo, TextBox Text, bool Filtro)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Empleados
                                    where T.Estado == "SI"
                                        && T.Seccion.Descripcion == "TRANSPORTE"
                                    orderby T.Nombre
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Nombre,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Empleados
                                    where (T.Nombre.StartsWith(Text.Text) || T.Nombre.Contains(Text.Text)) && T.Estado == "SI"
                                        && T.Seccion.Descripcion == "TRANSPORTE"
                                    orderby T.Nombre
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Nombre,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboClientes(ComboBox Combo, TextBox Text, bool Filtro , String Tipo , int Sugerido)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Clientes
                                    where T.Estado == "SI"
                                        && T.Tipo == Tipo
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;

                    if (Sugerido > 0)
                    {
                        Combo.SelectedValue = Sugerido;
                        Combo.Text = Resultados.Where(x => x.Id == Sugerido).FirstOrDefault().Tittle;
                    }
                    else
                    {
                        Combo.SelectedIndex = -1;

                    }

                    
                    
                    
                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Clientes
                                    where (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text)) && T.Estado == "SI"
                                        && T.Tipo == Tipo
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion,
                                        T.Estado
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboUsuario(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from T in hb.Usuarios
                                where T.Estado == "SI"
                                orderby T.Nombre
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Nombre,
                                    Estado = T.Estado
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarComboCiudades(ComboBox Combo, TextBox Text, bool Filtro)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.Ciudades
                                    where T.Estado == "SI"
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion,                                       
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Ciudades
                                    where (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text)) 
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion,                                       
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboTipoCliente(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from T in hb.Tipo_Cliente
                                orderby T.Descripcion
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Descripcion
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarComboMedida(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from T in hb.Medidas_Producto
                                where T.Estado == "SI"
                                orderby T.Descripcion
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Descripcion
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarCombomMovProduccion(ComboBox Combo , string Modulo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from T in hb.Movimientos_Produccion
                                where T.Estado == "SI"
                                    && T.Modulo == Modulo
                                orderby T.Descripcion
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Descripcion
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarComboMovimientos(ComboBox Combo, int Modulo , string Sugerido)
        {
            using (var hb = new DBdatos())
            {
               

                var Consulta = (from T in hb.MOVIMIENTOS
                                where T.Estado == "SI"
                                    && T.Modulo_ID == Modulo
                                orderby T.Descripcion
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Descripcion,
                                    T.Codigo
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
                if (Sugerido != "")
                {
                    Combo.SelectedValue = Sugerido;
                    Combo.Text = Resultados.Where(x => x.Codigo == Sugerido).FirstOrDefault().Tittle;
                }
                else
                    Combo.SelectedIndex = -1;

                
            }
        }
        public static void MostrarCombomItems(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from T in hb.Menu_Item
                                where T.Estado == "SI" && T.Modulo_ID == (int)Combo.SelectedValue
                                orderby T.Descripcion
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Descripcion
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
            }
        }
        public static void MostrarCombomListaPrecio(ComboBox Combo , int Sugerido)
        {
            using (var hb = new DBdatos())
            {
                var Consulta = (from T in hb.LISTAPRECIO
                                where T.Estado == "SI"
                                orderby T.Descripcion
                                select new
                                {
                                    Id = T.ID,
                                    Tittle = T.Descripcion
                                });

                var Resultados = Consulta.ToList();

                Combo.ValueMember = "Id";
                Combo.DisplayMember = "Tittle";
                Combo.DataSource = Resultados;
                if (Sugerido > 0)
                {
                    Combo.SelectedValue = Sugerido;
                    Combo.Text = Resultados.Where(x => x.Id == Sugerido).FirstOrDefault().Tittle;
                }
                else
                    Combo.SelectedIndex = -1;
            }
        }
        public static void MostrarComboMantemimientoTipo(ComboBox Combo, TextBox Text, bool Filtro)
        {
            using (var hb = new DBdatos())
            {
                if (Filtro == false)
                {
                    var Consulta = (from T in hb.MANTENIMIENTOTIPO
                                    orderby T.ID
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion + " - " + T.ID,
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
                if (Filtro == true)
                {
                    var Consulta = (from T in hb.Informes
                                    where (T.Descripcion.StartsWith(Text.Text) || T.Descripcion.Contains(Text.Text))
                                    orderby T.Descripcion
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion + " - " + T.ID,
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;
                }
            }
        }
        public static void MostrarComboCaja(ComboBox Combo)
        {
            using (var hb = new DBdatos())
            {
               

                    var Consulta = (from T in hb.CAJA
                                    orderby T.Descripcion
                                    where T.Estado == "SI"
                                    select new
                                    {
                                        Id = T.ID,
                                        Tittle = T.Descripcion,                                      
                                    });

                    var Resultados = Consulta.ToList();

                    Combo.ValueMember = "Id";
                    Combo.DisplayMember = "Tittle";
                    Combo.DataSource = Resultados;             
            }
        }
    }
}
