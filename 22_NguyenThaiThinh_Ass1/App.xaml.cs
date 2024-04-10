using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using _22_NguyenThaiThinh_Ass1.Repository;
namespace _22_NguyenThaiThinh_Ass1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            CongfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void CongfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(IMemberRepository), typeof(MemberRepository));
            services.AddSingleton(typeof(IProductRepository), typeof(ProductRepository));
            services.AddSingleton(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddSingleton<MainWindow>();
        }
        private void OnStartUp(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }

}
