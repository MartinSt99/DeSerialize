using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows;
using CarLib;

namespace Serialization
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MyCarList carList = new MyCarList();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tempcar = new Car();
                tempcar.Modell = txtModell.Text;
                tempcar.Marke = txtMarke.Text;
                tempcar.Baujahr = int.Parse(txtBaujahr.Text);
                carList.Add(tempcar);
                lbxItems.Items.Add(tempcar.Marke + " " + tempcar.Modell + " " + tempcar.Modell);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSerialize_Click(object sender, RoutedEventArgs e)
        {
            Stream streamWrite = File.Create("../../../MyElementList.xml");
            var soapWrite = new SoapFormatter();
            soapWrite.Serialize(streamWrite, carList);
            streamWrite.Close();
        }

        private void btnSerialize_Binary_Click(object sender, RoutedEventArgs e)
        {
            var memorystream = new MemoryStream();
            var bf = new BinaryFormatter();
            bf.Serialize(memorystream, carList);
            var SerialBytes = memorystream.ToArray();
            File.WriteAllBytes("../../../serialbin.bin", SerialBytes);
        }
    }
}
