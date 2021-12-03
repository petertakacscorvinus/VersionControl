﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTervezesiMintak.Abstractions
{
    public abstract class Toy:Label
    {
        public Toy()
        {
            AutoSize = false;
            Width = Height = 50;
            Paint += Toy_Paint;

        }

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected abstract void DrawImage(Graphics g);

        public void MoveToy()
        {
            Left++;
        }
    }
}
