using System.Drawing;
using System.Windows.Forms;

namespace GameOfLifeImpl
{
    public class FormsGameOfLifeRealisator : IGameOfLifeRealisator
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

        public void WriteGeneration(byte[,] grid)
        {
            
        }
    }
}
