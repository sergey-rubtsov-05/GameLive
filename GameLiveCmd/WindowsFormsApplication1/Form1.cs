using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameOfLifeImpl;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private byte[,] _grid;

        readonly FormsGameOfLifeRealisator _gameOfLife = new FormsGameOfLifeRealisator();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const int gridSize = 6;
            int x;
            int y = 10;
            for (int i = 0; i < gridSize; i++)
            {
                x = 10;
                y = y + 10;
                for (int j = 0; j < gridSize; j++)
                {
                    var label = new Label();
                    label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                    label.Location = new System.Drawing.Point(x + (j * 10), y);
                    x += 2;
                    label.Name = i + "_" + j;
                    label.Size = new System.Drawing.Size(10, 10);
                    label.TabIndex = 0;
                    label.Text = "";
                    label.Click += ChangeDotStatus;
                    Controls.Add(label);
                }
                y += 2;
            }
        }

        private void ChangeDotStatus(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = label.BackColor == SystemColors.ActiveCaptionText ? SystemColors.ButtonHighlight : SystemColors.ActiveCaptionText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _grid = _gameOfLife.MakeRandomGeneration();
            _gameOfLife.WriteGeneration(_grid, Controls);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _grid = _gameOfLife.GetGridFromLabels(Controls);
            _grid = _gameOfLife.CalculateNextGeneration(_grid);
            _gameOfLife.WriteGeneration(_grid, Controls);
        }
    }
}
