using _22_NguyenThaiThinh_Ass1.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
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

namespace _22_NguyenThaiThinh_Ass1
{
    /// <summary>
    /// Interaction logic for AdminReport.xaml
    /// </summary>
    public partial class AdminReport : Window
    {
        private Ass1_Prn221_Bl5Context context;

        public AdminReport()
        {
            InitializeComponent();
            context = new Ass1_Prn221_Bl5Context();
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = StartDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = EndDatePicker.SelectedDate ?? DateTime.MaxValue;

            var query = from order in context.Orders
                        where order.OrderDate.Date >= startDate.Date && order.OrderDate.Date <= endDate.Date
                        join orderDetail in context.OrderDetails on order.OrderId equals orderDetail.OrderId
                        group new { orderDetail.UnitPrice, orderDetail.Quantity } by order.OrderDate.Date into g
                        orderby g.Sum(x => x.UnitPrice * x.Quantity) descending
                        select new { SaleDate = g.Key, TotalSales = g.Sum(x => x.UnitPrice * x.Quantity) };

            try
            {
                SalesListView.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OrdersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string temp = SalesListView.SelectedItem.ToString();
                string[] parts = temp.Split('=')[1].Trim().Split(' ');
                string dateString = parts[0] + " " + parts[1] + " " + parts[2];

                // Parse the date string into a DateTime object
                DateTime saleDate = DateTime.Parse(dateString);

                if (saleDate != null)
                {

                    DateTime selectedSaleDate = saleDate;


                    var ordersInSelectedDay = context.Orders
                        .Where(o => o.OrderDate.Date == selectedSaleDate.Date) 
                        .ToList();

                    OrdersListView.ItemsSource = ordersInSelectedDay;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
