using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows;

namespace Serialization
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {


        public MyCarList carList = new MyCarList();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void DisplayInBox()
        {
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
                lbxItems.Items.Add(tempcar.Modell);
            }
            catch (Exception exception)
            {
            }
        }
        [Serializable]
        public class MyCarList
        {
            public void Add(Car c)
            {
                row.Add(c);
            }

            public override string ToString()
            {
                string temp = null;
                foreach (Car my in row)
                    temp += my.ToString() + "\n";
                return (temp);
            }

            ArrayList row = new ArrayList();
        }
        [Serializable]
        public class Car
        {
            public Car()
            {
                
            }
            public Car(string Marke, string Modell, int Baujahr)
            {
                this.modell = Modell;
                baujahr = Baujahr;
                marke = Marke;
            }
            private int baujahr;

            private string marke;

            private string modell;

            public int Baujahr
            {
                get { return baujahr; }
                set { baujahr = value; }
            }

            public string Marke
            {
                get { return marke; }
                set { marke = value; }
            }

            public string Modell
            {
                get { return modell; }
                set { modell = value; }
            }
        }

        private void btnSerialize_Click(object sender, RoutedEventArgs e)
        {
            SoapFormatter formatter = new SoapFormatter();
            Stream objfilestream = new FileStream("Myserialzed.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            Stream streamWrite = File.Create("MyElementList.xml");
            SoapFormatter soapWrite = new SoapFormatter();
            soapWrite.Serialize(streamWrite, carList);
            streamWrite.Close();
        }
    }
}