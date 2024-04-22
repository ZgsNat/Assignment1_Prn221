using _22_NguyenThaiThinh_Ass1.DataAccess;
using _22_NguyenThaiThinh_Ass1.Repository;
using System;
using System.Collections.Generic;
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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace _22_NguyenThaiThinh_Ass1
{
    /// <summary>
    /// Interaction logic for AdminOrder.xaml
    /// </summary>
    public partial class AdminOrder : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private IOrderRepository _orderRepository = new OrderRepository();
        public AdminOrder(IMemberRepository memberRepository, IProductRepository productRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            _productRepository = productRepository;
            lvMembers.ItemsSource = _memberRepository.GetMembers();
            lvProducts.ItemsSource = _productRepository.GetProducts();
        }

        private Order GetOrderObject()
        {
            Order c = null;
            try
            {
                c = new Order
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    MemberId = int.Parse(txtMemberId.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = (txtRequiredDate.Text == "" ? null : DateTime.Parse(txtRequiredDate.Text)),
                    ShippedDate = (txtShippedDate.Text == "" ? null : DateTime.Parse(txtShippedDate.Text)),
                    Freight = (txtFreight.Text == ""? null : Decimal.Parse(txtFreight.Text)),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetOrder");
            }
            return c;
        }
        private Order GetOrderObjectToAdd()
        {
            Order c = null;
            try
            {
                c = new Order
                {
                    MemberId = int.Parse(txtMemberId2.Text),
                    OrderDate = DateTime.Now,
                    RequiredDate = (txtRequiredDate.Text == "" ? null : DateTime.Parse(txtRequiredDate.Text)),
                    ShippedDate = (txtShippedDate.Text == "" ? null : DateTime.Parse(txtShippedDate.Text)),
                    Freight = (txtFreight.Text == "" ? null : Decimal.Parse(txtFreight.Text)),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetOrder");
            }
            return c;
        }
        public void LoadOrderList()
        {
            lvOrders.ItemsSource = _orderRepository.GetOrders();
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = GetOrderObject();

                // Show a confirmation dialog
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to update order {order.OrderId}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _orderRepository.Update(order);
                    LoadOrderList();
                    MessageBox.Show($"{order.OrderId} Update Successfully ", "Update Member");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order selectedOrder = lvOrders.SelectedItem as Order;

                if (selectedOrder != null)
                {
                    // Show a confirmation dialog
                    MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete order {selectedOrder.OrderId}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        // Remove order details related to the selected order
                        var dbcontext = new Ass1_Prn221_Bl5Context();
                        var orderDetailsToRemove = dbcontext.OrderDetails.Where(od => od.OrderId == selectedOrder.OrderId);
                        dbcontext.OrderDetails.RemoveRange(orderDetailsToRemove);
                        dbcontext.SaveChanges();

                        // Delete the selected order
                        _orderRepository.Delete(selectedOrder);

                        // Reload the order list
                        LoadOrderList();

                        MessageBox.Show($"Order {selectedOrder.OrderId} deleted successfully", "Delete Order");
                    }
                }
                else
                {
                    MessageBox.Show("Please select an order to delete", "Delete Order");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu(_memberRepository, _productRepository);
            adminMenu.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order o = GetOrderObjectToAdd();

                // Show a confirmation dialog
                MessageBoxResult result = MessageBox.Show("Are you sure you want to create this order?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _orderRepository.Insert(o);
                    Product temp = lvProducts.SelectedItem as Product;
                    temp.UnitInStock = -int.Parse(txtQuantity.Text);
                    _productRepository.Insert(temp);
                    OrderDetail od = new OrderDetail
                    {
                        OrderId = o.OrderId,
                        ProductId = int.Parse(txtProductId2.Text),
                        UnitPrice = ((Product)lvProducts.SelectedItem).UnitPrice,
                        Quantity = int.Parse(txtQuantity.Text),
                        Discount = float.Parse(txtDiscount.Text)
                    };
                    var dbcontext = new Ass1_Prn221_Bl5Context();
                    dbcontext.OrderDetails.Add(od);
                    dbcontext.SaveChanges();
                    MessageBox.Show("Order created Successfully!");
                    lvProducts.ItemsSource = _productRepository.GetProducts();
                    lvOrders.ItemsSource = _orderRepository.GetOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void lvMemberChange(object sender, SelectionChangedEventArgs e)
        {
            txtMemberId2.DataContext = lvMembers.SelectedItem;
        }

        private async void lvOrdersChange(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var dbcontext = new Ass1_Prn221_Bl5Context();
                Order temp = lvOrders.SelectedItem as Order;
                OrderDetail orderTemp = dbcontext.OrderDetails.FirstOrDefault(od => od.OrderId == temp.OrderId);
                if(orderTemp != null)
                {
                    txtMemberId2.DataContext = lvOrders.SelectedItem;
                    txtProductId2.DataContext = orderTemp;
                    txtQuantity.Text = orderTemp.Quantity.ToString();
                    txtDiscount.Text = orderTemp.Discount.ToString();
                    txtUnitPrice.Text = orderTemp.UnitPrice.ToString();
                }
            }catch (Exception ex) { 
                MessageBox.Show (ex.Message);
            }
        }

        private void lvProductsChange(object sender, SelectionChangedEventArgs e)
        {
            txtProductId2.DataContext = lvProducts.SelectedItem;
        }

        private void btnSortByDate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dbcontext = new Ass1_Prn221_Bl5Context();
                var sortedOrders = dbcontext.Orders.OrderBy(o => o.OrderDate).ToList();
                lvOrders.ItemsSource = sortedOrders;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ExportToExcel(List<Order> orders)
        {
            // Set the license context to NonCommercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                // Create a new worksheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Orders");

                // Set header row
                worksheet.Cells["A1"].Value = "Order ID";
                worksheet.Cells["B1"].Value = "Member ID";
                worksheet.Cells["C1"].Value = "Order Date";
                worksheet.Cells["D1"].Value = "Required Date";
                worksheet.Cells["E1"].Value = "Shipped Date";
                worksheet.Cells["F1"].Value = "Freight";

                // Set the data rows
                int row = 2;
                foreach (var order in orders)
                {
                    worksheet.Cells[row, 1].Value = order.OrderId;
                    worksheet.Cells[row, 2].Value = order.MemberId;
                    worksheet.Cells[row, 3].Value = order.OrderDate.ToString("yyyy-MM-dd");
                    worksheet.Cells[row, 4].Value = order.RequiredDate?.ToString("yyyy-MM-dd");
                    worksheet.Cells[row, 5].Value = order.ShippedDate?.ToString("yyyy-MM-dd");
                    worksheet.Cells[row, 6].Value = order.Freight;
                    row++;
                }

                // Autofit columns
                worksheet.Cells.AutoFitColumns();

                // Save the Excel file
                FileInfo excelFile = new FileInfo("Orders.xlsx");
                excelPackage.SaveAs(excelFile);
            }

            MessageBox.Show("Orders exported to Excel successfully!");
        }


        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Order> orders = (List<Order>)_orderRepository.GetOrders();
                ExportToExcel(orders);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting orders to Excel: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
