using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GameOfLifeImpl
{
    public class FormsGameOfLifeRealisator : GameOfLifeMainMethods, IGameOfLifeRealisator
    {
        private readonly Color _liveDot = SystemColors.ActiveCaptionText;
        private readonly Color _deadDot = SystemColors.ButtonHighlight;
        public void WriteLiveDot(Label label)
        {
            label.BackColor = _liveDot;
        }

        public void WriteDeadDot(Label label)
        {
            label.BackColor = _deadDot;
        }

        public void WriteLiveDot()
        {
            throw new System.NotImplementedException();
        }

        public void WriteDeadDot()
        {
            throw new System.NotImplementedException();
        }

        public void WriteGeneration(byte[,] grid, List<Label> contorls)
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    var labelByName = contorls.Find(o => o.Name.Equals(string.Concat(i, "_", j)));
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
        }

        public byte[,] GetGridFromLabels(IEnumerable<Label> controls)
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
