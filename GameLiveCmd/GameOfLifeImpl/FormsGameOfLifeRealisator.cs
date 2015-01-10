using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GameOfLifeImpl
{
    public class FormsGameOfLifeRealisator : GameOfLifeParameters
    {
        private readonly Color _liveDot = SystemColors.ActiveCaptionText;
        private readonly Color _deadDot = SystemColors.ButtonHighlight;

        private void WriteLiveDot(Label label)
        {
            label.BackColor = _liveDot;
        }

        private void WriteDeadDot(Label label)
        {
            label.BackColor = _deadDot;
        }

        public void WriteGeneration(byte[,] grid, Label[,] contorls)
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    var labelByName = contorls[i, j];
                    if (grid[i, j] == 1)
                    {
                        WriteLiveDot(labelByName);
                    }
                    else
                    {
                        WriteDeadDot(labelByName);
                    }
                }
            }
            Thread.Sleep(100);
        }

        public byte[,] GetGridFromLabels(Label[,] controls)
        {
            var grid = new byte[GridSize,GridSize];
            foreach (var label in controls)
            {
                var labelNameParts = label.Name.Split('_');
                var i = int.Parse(labelNameParts[0]);
                var j = int.Parse(labelNameParts[1]);
                if (label.BackColor == _liveDot)
                    grid[i, j] = 1;
                else
                    grid[i, j] = 0;
            }
            return grid;
        }
    }
}
