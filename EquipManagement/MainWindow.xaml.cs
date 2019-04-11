using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EquipManagement
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<Classes> classList;
        ObservableCollection<Equipment> itemsList;

       
        public MainWindow()
        {
            InitializeComponent();

            DbAction.CreateDatabase();
           
            if (selection.SelectedIndex == 1)
            {
                selection2.Visibility = Visibility.Hidden;
                itemName.Visibility = Visibility.Visible;
                selection4.Visibility = Visibility.Visible;

                classList = new ObservableCollection<Classes>(DbAction.QueryClasses());
                itemsList = new ObservableCollection<Equipment>(DbAction.QueryItems());
                itemPrice.Visibility = Visibility.Visible;
                if (classList.Count() != 0)
                {
                    selection4.ItemsSource = classList;
                    actionbutton.Visibility = Visibility.Visible;
                }
                else
                {
                    
                    
                    selection4.IsEnabled = false;

                }
            }
            Classrooms.ItemsSource = classList;
            Items.ItemsSource = itemsList;

        }

        private void Selection_SelectionChanged(object sender, SelectionChangedEventArgs e) // on change of selection picker
        {



        }

        private void Selection2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Selection3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Selection4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Actionbutton_Click(object sender, RoutedEventArgs e)
        {
            if (selection.SelectedIndex == 0)
            {
                Classes claz = new Classes();
                claz.ClassName = 11;//int.Parse(nameclass.Text);

                DbAction.InsertToDB(claz);
                classList.Add(claz);
            }
        }
    }
}
