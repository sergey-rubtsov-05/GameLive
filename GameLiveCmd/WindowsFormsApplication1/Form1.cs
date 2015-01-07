using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GameOfLifeImpl;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private byte[,] _grid;
        private readonly List<Label> _labels; 

        readonly FormsGameOfLifeRealisator _gameOfLife = new FormsGameOfLifeRealisator();
        public Form1()
        {
            InitializeComponent();
            _labels = new List<Label>();
            const int gridSize = 20;
            int x;
            int y = 10;
            for (int i = 0; i < gridSize; i++)
            {
                x = 10;
                y = y + 10;
                for (int j = 0; j < gridSize; j++)
                {
                    var label = new Label();
                    label.BackColor = SystemColors.ButtonHighlight;
                    label.Location = new Point(x + (j * 10), y);
                    x += 2;
                    label.Name = i + "_" + j;
                    label.Size = new Size(10, 10);
                    label.TabIndex = 0;
                    label.Text = "";
                    label.Click += ChangeDotStatus;
                    _labels.Add(label);
                    Controls.Add(label);
                }
                y += 2;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ChangeDotStatus(object sender, EventArgs e)
        {
            var label = (Label)sender;
            label.BackColor = label.BackColor == SystemColors.ActiveCaptionText ? SystemColors.ButtonHighlight : SystemColors.ActiveCaptionText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _grid = _gameOfLife.MakeRandomGeneration();
            _gameOfLife.WriteGeneration(_grid, _labels);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _grid = _gameOfLife.GetGridFromLabels(_labels);
            _grid = _gameOfLife.CalculateNextGeneration(_grid);
            _gameOfLife.WriteGeneration(_grid, _labels);
        }
    }
}
