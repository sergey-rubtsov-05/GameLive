using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
                    label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                    label.Location = new System.Drawing.Point(x + (j * 10), y);
                    x += 2;
                    label.Name = "label" + i + "_" + j;
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
    }
}
