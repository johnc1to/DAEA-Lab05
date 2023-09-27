using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab05
{
    /// <summary>
    /// Lógica de interacción para ListadoWindow.xaml
    /// </summary>
    /// <summary>
    /// Lógica de interacción para ListadoWindow.xaml
    /// </summary>
    public partial class ListadoWindow : Window
    {
        public static string connectionString = "Data Source=LAB1504-19\\SQLEXPRESS;Initial Catalog=Neptuno3;User ID=userTecsup;Password=123456";
        public ListadoWindow()
        {
            InitializeComponent();
            DateTime fechaInicio = new DateTime(1994, 08, 04); // Cambia esta fecha según tus necesidades
            DateTime fechaFin = new DateTime(1994, 09, 01); // Cambia esta fecha según tus necesidades

            Clientes clientes = ListarClientes(fechaInicio, fechaFin);

            // Asigna la lista de detalles de pedido a tu DataGrid
            McDataGrid.ItemsSource = clientes.Detalles;
        }
        private static Clientes ListarClientes(DateTime fechaInicio, DateTime fechaFin)
        {
            Clientes clientes = new Clientes();
            clientes.FechaInicio = fechaInicio;
            clientes.FechaFin = fechaFin;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "ListarClientes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                DetalleCliente detalle = new DetalleCliente
                                {
                                    Idcliente = reader["idCliente"].ToString(),
                                    Nombrecompañia = reader["NombreCompañia"].ToString(),
                                    Nombrecontacto = reader["NombreContacto"].ToString(),
                                    Cargocontacto = reader["CargoContacto"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    Ciudad = reader["Ciudad"].ToString(),
                                    Region = reader["Region"].ToString(),
                                    Codpostal = reader["CodPostal"].ToString(),
                                    Pais = reader["Pais"].ToString(),
                                    Telefono = reader["Telefono"].ToString(),
                                    Fax = reader["Fax"].ToString(),
                                    Activo = reader["Activo"].ToString()
                                };
                                clientes.Detalles.Add(detalle);
                            }
                        }
                    }
                }
                connection.Close();
            }
            return clientes;
        }
    }
}
