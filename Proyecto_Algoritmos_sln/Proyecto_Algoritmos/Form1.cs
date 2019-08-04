using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Algoritmos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Dictionary<String, List<int>> Paridad(string[] lista)
        {
            int num;
            List<int> par = new List<int>();
            List<int> impar = new List<int>();
            for (int i = 0; i < lista.Length; i++)
            {
                num = Convert.ToInt32(lista[i]);
                if (num % 2 == 0)
                    par.Add(num);
                else if (num % 2 !=0)
                    impar.Add(num);

            }

            Dictionary<String, List<int>> response = new Dictionary<String, List<int>>();

            response["pares"] = par;
            response["impares"] = impar;
            

            return response;
        }

        private void TxtNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool space, numero, back;
            space = !char.IsWhiteSpace(e.KeyChar);
            numero = !char.IsDigit(e.KeyChar);
            back = !char.IsControl(e.KeyChar);

            if (space == true && numero == true && back == true)
            {
                e.Handled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string text;
            text = txtNumeros.Text;
            string[] arr = text.Split(' ');

            

            Dictionary<String, List<int>> dictParidad = Paridad(arr);

            List<int> pares = dictParidad["pares"];
            pares.Sort();
            List<int> impares = dictParidad["impares"];
            impares.Reverse();
            listBox2.DataSource = pares;
            listBox3.DataSource = impares;

            //foreach (var value in dictParidad)
            //{
            //    int rep = 1;
            //    if (dictParidad.Contains(value))
            //        dictParidad[rep]++;
            //    else
            //       dictParidad[value] = 1;
            //    listBox4.Items.Add("Value" + value + "occurred" + rep + "times.");
            //}

            List<double> numimpar = new List<double>();
            List<double> numpar = new List<double>();

            for (int i = 0; i < pares.Count; i++)
            {
                numpar.Add(Convert.ToDouble(pares[i]));
            }

            for (int i = 0; i < impares.Count; i++)
            {
                numimpar.Add(Convert.ToDouble(impares[i]));
            }

            List<double> numeros = new List<double>();
            for (int i = 0; i < arr.Length; i++) 
            {
                numeros.Add(Convert.ToDouble(arr[i]));
            }
            if (pares.Count > impares.Count)
            {
                txtRes.Text = "El promedio es:  " + Promedio(numeros).ToString();
            }
            else if (impares.Count > pares.Count)
            {
                txtRes.Text = "La mediana es: " + Mediana(numeros).ToString();
            }
            else if (impares.Count == pares.Count)
            {

                txtRes.Text = "El promedio de los pares es:  " + Promedio(numpar).ToString() + "\r\n" +
                    "La mediana de los impares es: " + Mediana(numimpar).ToString();
            }
            if ((Sumatotal(numeros) % 5) == 0)
            {
                double ln;
                ln = Math.Log10(Promedio(numeros));
                txtRes.Text += "\r\n" + "El logaritmo decimal del promedio de los numeros introducidos es: " + ln;
            }
            if (Multtotal(numeros) > 1000)
            {
                double raiz;
                double med = Mediana(numeros);
                raiz = Math.Pow(med, (1.0/3.0));
                txtRes.Text += "\r\n" + "La raiz cubica de la mediana de los numeros introducidos es: " + raiz;
            }

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private double Mediana (List<double> imp)
        {
            imp.Sort();
            double mediana;
            double posicion = imp.Count / 2;
            posicion = Math.Floor(posicion);
            mediana = imp[Convert.ToInt32(posicion)];

            return mediana;
        }

        private double Promedio (List<double> par)
        {
            double promedio;
            double suma = 0;
            for (int i = 0; i < par.Count; i++)
            {
                suma += par[i];
            }
            promedio = suma / par.Count;
            return promedio;
        }

        private int Sumatotal(List<double> list)
        {
            int st = 0;
            for (int i = 0; i < list.Count; i++) 
            {
                st += Convert.ToInt32(list[i]);
            }
            return st;
        }

        private int Multtotal(List<double> list)
        {
            int mt = 1;
            for (int i = 0; i < list.Count; i++)
            {
                mt *= Convert.ToInt32(list[i]);
            }
            return mt;
        }
 

        }
         
    }

       
    

