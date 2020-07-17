using DllVersionCheck.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DllVersionCheck
{
    /// <summary>
    /// Interaction logic for DllVersionCheckHome.xaml
    /// </summary>
    public partial class DllVersionCheckHome : Page
    {
        private static List<Library> libraryObject = new List<Library>();
        public DllVersionCheckHome()
        {
            InitializeComponent();

            var myDataList = LoadData();
            ListView1.ItemsSource = null;
            ListView1.ItemsSource = myDataList;
        }

        private ArrayList LoadData()
        {
            ArrayList itemsList = new ArrayList();
            var result = LibraryVersionHelper.GetAllPAckagesInstalled();
            if(result != null)
            {
                libraryObject = (List<Library>)result;
                foreach (var item in result)
                {
                    var name = item.Title;
                    itemsList.Add(name);
                }
            }

            return itemsList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var text = ListView1.SelectedValue?.ToString();
            if(text != null)
            {
                var obj = libraryObject.Where(x => x.Title.Equals(text)).SingleOrDefault();
                if (obj != null)
                {
                    List<Library> items = new List<Library>();
                    items.Add(new Library() { Title = obj.Title, Version = obj.Version, ProdVersion = obj.ProdVersion ,ProductName = obj.ProductName});
                    libraryObj.ItemsSource = items;
                }
            }
        }
    }
}
