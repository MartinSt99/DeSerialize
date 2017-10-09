using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLib
{
    [Serializable]
    public class MyCarList : IEnumerable
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
        IEnumerator IEnumerable.GetEnumerator()
        {
            return row.GetEnumerator();
        }
        ArrayList row = new ArrayList();
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
