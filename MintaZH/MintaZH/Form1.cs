﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MintaZH.Entities;

namespace MintaZH
{
    public partial class Form1 : Form
    {
        List<OlympicResult> results = new List<OlympicResult>();
        
        public Form1()
        {
            InitializeComponent();
            Betolt("Summer_olympic_Medals.csv");
        }

        void Betolt (string fajlnev)
        {
            using (StreamReader sr = new StreamReader(fajlnev))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] mezok = sor.Split(',');
                    OlympicResult or = new OlympicResult();
                    or.Year = int.Parse(mezok[0]);
                    or.Country = mezok[3];
                    int[] mtomb = new int[3];
                    mtomb[0] = int.Parse(mezok[5]);
                    mtomb[1] = int.Parse(mezok[6]);
                    mtomb[2] = int.Parse(mezok[7]);
                    results.Add(or);
                }
            }


        }
    }
}
