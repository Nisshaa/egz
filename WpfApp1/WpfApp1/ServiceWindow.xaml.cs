
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window, INotifyPropertyChanged
    {

        public List<Product> ProductList { get; set; }

        public ServiceWindow(Product product)
        {



        }
        public Product CurrentOrder { get; set; }
        public string WindowName
        {
            get
            {
                return CurrentOrder.ID == 0 ? "Новая услуга" : "Редоктирование улсгуи";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void SaveButton(object sender, RoutedEventArgs e)
        {

            {
                MessageBox.Show("Стоимость заказа должна быть больше ноля");
                return;
            }
            if (CurrentOrder.ID == 0)
                Core.DB.Product.Add(CurrentOrder);
            try
            {
                Core.DB.SaveChanges();
            }
            catch
            {
            }
            DialogResult = true;
        }
    }
}