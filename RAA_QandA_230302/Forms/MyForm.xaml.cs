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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.DB;


namespace RAA_QandA_230302
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class MyForm : Window
    {
        public List<Element> elements;
        public MyForm(List<Element> items)
        {
            InitializeComponent();

            this.elements = items;
            lbxData.ItemsSource = elements;

            lbxData.SelectAll();
        }

        public List<Element> GetSelectedItemsWPF()
        {
            List<Element> returnList = new List<Element>();

            foreach(Element item in lbxData.SelectedItems)
            {
                returnList.Add(item);
            }

            return returnList;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
