using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows;
using CarLib;

namespace Deserialization
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            Stream streamRead = File.OpenRead("../../../MyElementList.xml");
            var soapRead = new SoapFormatter();
            var rowSoap = (MyCarList) soapRead.Deserialize(streamRead);
            streamRead.Close();
            foreach (var item in rowSoap)
            {
                var x = (Car) item;
                listBox.Items.Add(x.Marke + " " + x.Modell + " " + x.Baujahr);
            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            var SerialBytes = File.ReadAllBytes("../../../serialbin.bin");
            var memorystreamd = new MemoryStream(SerialBytes);
            var bfd = new BinaryFormatter();
            var carlist = bfd.Deserialize(memorystreamd) as MyCarList;
            foreach (var item in carlist)
            {
                var x = (Car) item;
                listBox.Items.Add(x.Marke + " " + x.Modell + " " + x.Baujahr);
            }
        }
    }
}
