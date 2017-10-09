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

namespace Deserialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    [Serializable]
    public class Car
    {

        private int baujahr;

        public int Baujahr
        {
            get { return baujahr; }
            set { baujahr = value; }
        }
        private string marke;

        public string Marke
        {
            get { return marke; }
            set { marke = value; }
        }
        private string modell;

        public string Modell
        {
            get { return modell; }
            set { modell = value; }
        }




    }
}
