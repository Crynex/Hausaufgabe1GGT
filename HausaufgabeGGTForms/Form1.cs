﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HausaufgabeGGTForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Text = "berechnen";
            label1.Text = "Bitte geben Sie die Zahlen für die Sie den Größten gemeinsamen Teiler haben wollen kommasepariert ein: ";
            label2.Text = "Beispieleingabe: ";
            textBox1.Text = "10,25,35,50";
            label5.Text = " ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartPosition:
            string eingabeggt = textBox1.Text;
            var zahleneingabe = eingabeggt.Split(',', ' ', '.', ':', ';', '/');


            List<int> zahl = new List<int>();

            for(int zl = 0; zl<zahleneingabe.Length; ++zl)
            {
                try{
                    zahl.Add(Convert.ToInt32(zahleneingabe[zl]));
                }
                catch
                {

                }
            }

            if(zahl.Count == 0)
            {
                label5.Text = "Bitte geben Sie Zahlen ein, wie z.B: ";
                textBox1.Text = "10,25";
                goto StartPosition;
            }

            if(zahl.Count == 1)
            {
                zahl.Add(Convert.ToInt32(zahl[0]));
            }

            int tmp = zahl[0] % zahl[1];
            int ggt = zahl[0];

            for (int zl = 0; zl < zahl.Count-1; ++zl)
            {
                while (zahl[zl + 1] != 0)
                {
                    tmp = ggt % zahl[zl+1];
                    zahl[zl] = zahl[zl+1];
                    zahl[zl + 1] = tmp;
                    ggt = zahl[zl];
                }
            }

            label3.Text = "Der größte gemeinsame Teiler der Zahlen: " + textBox1.Text + " ist: ";
            string ggtausgabe = Convert.ToString(ggt);
            label4.Text = ggtausgabe;

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

        private void button7_Click(object sender, EventArgs e)
        {
            generiereGerade(4, 2, 100, 2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            generiereUngerade(4, 2, 100, 2);
        }

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

        private void generiereUngerade(int anzahl, int start, int grenze, int modulu)
        {
            textBox1.Text = "";
            Random zufall = new Random();
            for (int zl = 0; zl < anzahl; ++zl)
            {
                int zufallszahl = zufall.Next(start, grenze);
                if ( zufallszahl % modulu != 0)
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
        private void generiereGerade(int anzahl, int start, int grenze, int modulu)
        {
            textBox1.Text = "";
            Random zufall = new Random();
            for (int zl = 0; zl < anzahl; ++zl)
            {
                int zufallszahl = zufall.Next(start, grenze);
                if (zufallszahl % modulu == 0)
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

    }
}
