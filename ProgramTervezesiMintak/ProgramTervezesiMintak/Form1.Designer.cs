﻿namespace ProgramTervezesiMintak
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnBall = new System.Windows.Forms.Button();
            this.btnCollor = new System.Windows.Forms.Button();
            this.btnCar = new System.Windows.Forms.Button();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(0, 207);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(799, 164);
            this.mainPanel.TabIndex = 0;
            // 
            // btnBall
            // 
            this.btnBall.Location = new System.Drawing.Point(13, 13);
            this.btnBall.Name = "btnBall";
            this.btnBall.Size = new System.Drawing.Size(75, 23);
            this.btnBall.TabIndex = 1;
            this.btnBall.Text = "Ball";
            this.btnBall.UseVisualStyleBackColor = true;
            this.btnBall.Click += new System.EventHandler(this.btnBall_Click);
            // 
            // btnCollor
            // 
            this.btnCollor.Location = new System.Drawing.Point(111, 13);
            this.btnCollor.Name = "btnCollor";
            this.btnCollor.Size = new System.Drawing.Size(75, 23);
            this.btnCollor.TabIndex = 2;
            this.btnCollor.Text = "Collor";
            this.btnCollor.UseVisualStyleBackColor = true;
            this.btnCollor.Click += new System.EventHandler(this.btnCollor_Click);
            // 
            // btnCar
            // 
            this.btnCar.Location = new System.Drawing.Point(213, 13);
            this.btnCar.Name = "btnCar";
            this.btnCar.Size = new System.Drawing.Size(75, 23);
            this.btnCar.TabIndex = 3;
            this.btnCar.Text = "Car";
            this.btnCar.UseVisualStyleBackColor = true;
            this.btnCar.Click += new System.EventHandler(this.btnCar_Click);
            // 
            // createTimer
            // 
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Comint next";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCar);
            this.Controls.Add(this.btnCollor);
            this.Controls.Add(this.btnBall);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnBall;
        private System.Windows.Forms.Button btnCollor;
        private System.Windows.Forms.Button btnCar;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Label label1;
    }
}

