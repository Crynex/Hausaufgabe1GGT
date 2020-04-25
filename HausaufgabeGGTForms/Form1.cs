using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace HausaufgabeGGTForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Bitte geben Sie Zahlen kommasepariert ein: ";
            label2.Text = "Beispieleingabe: ";
            label4.Text = " ";
            label5.Text = " ";
            label7.Text = " ";
            textBox1.Text = "10,25,35,50";
            button11.Text = "2 Zufallszahlen ungerade";
            button10.Text = "2 Zufallszahlen gerade";
            button7.Text = "4 Zufallszahlen gerade";
            button8.Text = "4 Zufallszahlen ungerade";
        }

        //GGT 
        public void button1_Click(object sender, EventArgs e)
        {

            //Liste aufrufen
            string eingabeggt = textBox1.Text;
            var zahleneingabe = eingabeggt.Split(',', ' ', '.', ':', ';', '/');


            List<int> zahl = new List<int>();

            for (int zl = 0; zl < zahleneingabe.Length; ++zl)
            {
                try
                {
                    zahl.Add(Convert.ToInt32(zahleneingabe[zl]));
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }

            if (zahl.Count == 0)
            {
                label5.Text = "Bitte geben Sie Zahlen ein, wie z.B: 10,25";
                textBox1.Text = "10,25";
            }

            if (zahl.Count == 1)
            {
                zahl.Add(Convert.ToInt32(zahl[0]));
            }

            if (zahl[0] == 0)
            {
                label5.Text = "Bitte geben ganze Zahlen ein, 0 durch eine Zahl n ist immer 0";
            }

            int ggtausgabe = zahl[0];

            //GGT aufrufen
            for (int i = 0; i < zahl.Count-1; ++i)
            {
               ggtausgabe = ggt(zahl[i], zahl[i + 1]);
               zahl[i + 1] = ggtausgabe;
            }
            //GGT ausgeben
            label3.Text = "Der größte gemeinsame Teiler der Zahlen: " + textBox1.Text + " ist: ";
            string ausgabeggt = Convert.ToString(ggtausgabe);
            label4.Text = ausgabeggt;


        }

       //KGV
        private void button9_Click_1(object sender, EventArgs e)
        {
            //Liste aufrufen
            string eingabeggt = textBox1.Text;
            var zahleneingabe = eingabeggt.Split(',', ' ', '.', ':', ';', '/');


            List<int> zahl = new List<int>();

            for (int zl = 0; zl < zahleneingabe.Length; ++zl)
            {
                try
                {
                    zahl.Add(Convert.ToInt32(zahleneingabe[zl]));
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }

            if (zahl.Count == 0)
            {
                label5.Text = "Bitte geben Sie Zahlen ein, wie z.B: 10,25";
                textBox1.Text = "10,25";
            }

            if (zahl.Count == 1)
            {
                zahl.Add(Convert.ToInt32(zahl[0]));
            }

            if (zahl[0] == 0)
            {
                label5.Text = "Bitte geben ganze Zahlen ein, 0 durch eine Zahl n ist immer 0";
            }


            //KGV berechnen
            int kgvausgabe = zahl[0];
            kgvausgabe = Kgvliste(zahl);

            //KGV ausgeben
            label6.Text = "Das kleinste gemeinsame Vielfache der Zahlen: " + textBox1.Text + " ist: ";
            string ausgabekgv = Convert.ToString(kgvausgabe);
            label7.Text = ausgabekgv;
        }

        //Beides 
        private void button12_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
            button9.PerformClick();
        }
        
        //GGT
        public static int ggt(int a, int b)
        {
            int tmp = 0;
            int ggt = a;

            while (b != 0)
            {
                tmp = a % b;
                a = b;
                b = tmp;
                ggt = a;
            }

            return ggt;
        }

        //KGV
        public static int Kgv(int a, int b)
        {
            return (a * b) / ggt(a, b);
        }

        //KGV mehrere Zahlen
        public static int Kgvliste(List<int> zahl)
        {
            int kgv = zahl[0];
            for (int i = 1; i < zahl.Count; ++i)
            {
                kgv = Kgv(kgv, zahl[i]);
            }
            return kgv;
        }


        //Zufallszahlen
        private void button2_Click(object sender, EventArgs e)
        {
            generiereZahlen(2, 2, 51);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generiereZahlen(3, 2, 51);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            generiereZahlen(4, 2, 101);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            generiereZahlen(5, 2, 501);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            generiereZahlen(2, 501);
        }

        //4 Zufallszahl gerade
        private void button7_Click(object sender, EventArgs e)
        {
            generiereRandom(4, 2, 101, 0);
        }

        //4 Zufallszahl ungerade
        private void button8_Click(object sender, EventArgs e)
        {
            generiereRandom(4, 2, 101, 1);
        }
        
        //2 Zufallszahl gerade
        private void button10_Click(object sender, EventArgs e)
        {
            generiereRandom(2, 2, 51, 0);
        }

        //2 Zufallszahl ungerade
        private void button11_Click(object sender, EventArgs e)
        {
            generiereRandom(2, 2, 51, 1);
        }

        //Berechnung Zufallszahlen
        private void generiereZahlen(int anzahl, int start, int grenze) 
        {
            textBox1.Text = "";
            Random zufall = new Random();
            for (int zl = 0; zl < anzahl; ++zl)
            {
                int zufallszahl = zufall.Next(start, grenze);
                textBox1.Text += zufallszahl.ToString() + ",";
                Console.WriteLine(zufallszahl);

            }
        }

        private void generiereZahlen(int start, int grenze)
        {
            textBox1.Text = "";
            Random zufall = new Random();
            int anzahl = zufall.Next(2, 11);
            for (int zl = 0; zl < anzahl; ++zl)
            {
                int zufallszahl = zufall.Next(start, grenze);
                textBox1.Text += zufallszahl.ToString() + ",";
                Console.WriteLine(zufallszahl);

            }
        }

        //Gerade oder Ungerade
        private void generiereRandom(int anzahl, int start, int grenze, int rest)
        {
            textBox1.Text = "";
            Random zufall = new Random();
            for (int zl = 0; zl < anzahl; ++zl)
            {
                int zufallszahl = zufall.Next(start, grenze);
                if ( zufallszahl % 2 == rest)
                {
                    textBox1.Text += zufallszahl.ToString() + ",";
                    Console.WriteLine(zufallszahl);
                }
                else
                {
                    zufallszahl += 1;
                    textBox1.Text += zufallszahl.ToString() + ",";
                    Console.WriteLine(zufallszahl);
                }

            }
        }
                           
       
        public void button9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
