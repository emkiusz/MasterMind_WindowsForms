using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMind
{
    public partial class Form1 : Form
    {
        public int[] losu = new int[4];
        Random rnd = new Random();
        List<int> cyfry = new List<int>{1,2,3,4,5,6,7,8,9};

        //TextBox[] txtbox = new TextBox[40];
        //TextBox[] wynik = new TextBox[10];
        //TextBox[] wybor = new TextBox[4];
        public int krok = 0;

        public Form1()
        {
            InitializeComponent();

            TextBox[] txtbox = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7,
            textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16,
            textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25,
            textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, textBox33, textBox34, textBox35,
            textBox36, textBox37, textBox38, textBox39, textBox40};

            TextBox[] wynik = { textBox41, textBox42, textBox43, textBox44, textBox45, textBox46, textBox47, textBox48, textBox49, textBox50 };

            TextBox[] wybor = { textBox51, textBox52, textBox53, textBox54 };

            for (int x = 0; x <= 3; x++)
            {
                losu[x] = cyfry[rnd.Next(0, (cyfry.Count)-1)];
                cyfry.Remove(losu[x]);
                wybor[x].Text = "1";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> cyfry2 = new List<int>();

            TextBox[] txtbox = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7,
            textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16,
            textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25,
            textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, textBox33, textBox34, textBox35,
            textBox36, textBox37, textBox38, textBox39, textBox40};

            TextBox[] wynik = { textBox41, textBox42, textBox43, textBox44, textBox45, textBox46, textBox47, textBox48, textBox49, textBox50 };

            TextBox[] wybor = { textBox51, textBox52, textBox53, textBox54 };

            for (int i = 0; i <= 3; i++)
            {
                txtbox[i + krok].Text = wybor[i].Text;
            }

            for (int i = 0; i <= 3; i++)
            {
                if (!cyfry2.Contains(int.Parse(wybor[i].Text)))
                {
                    cyfry2.Add(int.Parse(wybor[i].Text));
                    for (int j = 0; j <= 3; j++)
                    {
                        if (wybor[i].Text == losu[j].ToString())
                        {
                            if (i == j)
                            {
                                wynik[krok / 4].Text += "x";
                            }
                            else
                            {
                                wynik[krok / 4].Text += "+";
                            }
                        }
                    }
                }
            }

            int temp = (wynik[krok / 4].Text).Length - 4;
            if (temp < 0)
            {
                for (int i = 0; i < temp*-1; i++)
                {
                    wynik[krok / 4].Text += "-";
                }
            }
            krok += 4;

            if (krok / 4 > 9)
            {
                MessageBox.Show("Przegrales! Szukane liczby to: " + losu[0] + ", " + losu[1] + ", " + losu[2] + ", " + losu[3]);
            }
            else
            {
                if (wynik[(krok/4)-1].Text == "xxxx")
                {
                    MessageBox.Show("Wygrales w " + krok / 4 + " krokach! Szukane liczby to: " + losu[0] + ", " + losu[1] + ", " + losu[2] + ", " + losu[3]);
                }
            }
        }
    }
}
