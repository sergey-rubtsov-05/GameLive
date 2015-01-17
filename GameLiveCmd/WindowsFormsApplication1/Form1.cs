using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using Autofac;
using GameOfLifeImpl;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private byte[,] _grid;
        private readonly Label[,] _labels; 
        private readonly List<long> _elapsMs = new List<long>();

        readonly IGameOfLifeMainMethods _gameOfLife;//new GameOfLifeMainMethodsMultiThread();
        readonly FormsGameOfLifeRealisator _gameOfLifeForForms = new FormsGameOfLifeRealisator();
        public Form1()
        {
            InitializeComponent();
            var builder = new ContainerBuilder();
            switch (MessageBox.Show(Resources.useMultiThread, Resources.useMultiThread,
                MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                {
                    builder.RegisterType<GameOfLifeMainMethodsMultiThread>().As<IGameOfLifeMainMethods>();
                    break;
                }
                case DialogResult.No:
                {
                    builder.RegisterType<GameOfLifeMainMethodsSingleThread>().As<IGameOfLifeMainMethods>();
                    break;
                }
            }
            var container = builder.Build();
            _gameOfLife = container.Resolve<IGameOfLifeMainMethods>();
            const int gridSize = GameOfLifeParameters.GridSize;
            _labels = new Label[gridSize, gridSize];
            int x;
            const int labelSize = 12;
            int y = labelSize + 70;
            for (int i = 0; i < gridSize; i++)
            {
                x = labelSize;
                y = y + labelSize;
                for (int j = 0; j < gridSize; j++)
                {
                    var label = new Label();
                    label.BackColor = SystemColors.ButtonHighlight;
                    label.Location = new Point(x + (j * labelSize), y);
                    x += 2;
                    label.Name = i + "_" + j;
                    label.Size = new Size(labelSize, labelSize);
                    label.TabIndex = 0;
                    label.Text = "";
                    label.Click += ChangeDotStatus;
                    _labels[i,j] = label;
                    Controls.Add(label);
                }
                y += 2;
                Height += labelSize;
                Width += labelSize;
            }
        }

        private void ChangeDotStatus(object sender, EventArgs e)
        {
            var label = (Label)sender;
            label.BackColor = label.BackColor == SystemColors.ActiveCaptionText ? SystemColors.ButtonHighlight : SystemColors.ActiveCaptionText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(numericUpDown1.Value);
            }
        }

        private void DoGenerations(object sender, DoWorkEventArgs e)
        {
            var iterationCount = int.Parse(e.Argument.ToString());
            for (var i = 0; i < iterationCount; i++)
            {
                _gameOfLifeForForms.WriteGeneration(_grid, _labels);
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                _grid = _gameOfLife.CalculateNextGeneration(_grid);
                stopwatch.Stop();
                _elapsMs.Add(stopwatch.ElapsedMilliseconds);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _grid = _gameOfLifeForForms.GetGridFromLabels(_labels);
            _grid = _gameOfLife.CalculateNextGeneration(_grid);
            _gameOfLifeForForms.WriteGeneration(_grid, _labels);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _grid = _gameOfLife.MakeRandomGeneration();
            _gameOfLifeForForms.WriteGeneration(_grid, _labels);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            long sum = 0;
            foreach (var elapsM in _elapsMs)
            {
                sum += elapsM;
            }
            var res = sum/_elapsMs.Count;
            MessageBox.Show(res.ToString(CultureInfo.InvariantCulture));
        }
    }
}
