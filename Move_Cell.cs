using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _15_wpf
{
    internal class Move_cell
    {
        Point _point;
        public Point FreeButton { get { return _point; } }
        public int X { get { return (int)_point.X; } }
        public int Y { get { return (int)_point.Y; } }
        public Move_cell(Point Free_point)
        {
            _point = Free_point;
        }
        public Point FreeSpaceCheck(Point pButton)
        {
            if (up(pButton) || down(pButton) || left(pButton) || right(pButton))
            {
                Point tmp = _point;
                (_point.X, _point.Y) = (pButton.X, pButton.Y);
                return tmp;
            }
            else { return pButton; }

        }
        private bool up(Point loc)
        {
            if (_point.Y == loc.Y - 1 && _point.X == loc.X)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool down(Point loc)
        {
            if (_point.Y == loc.Y + 1 && _point.X == loc.X)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool left(Point loc)
        {
            if (_point.X == loc.X - 1 && _point.Y == loc.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool right(Point loc)
        {
            if (_point.X == loc.X + 1 && _point.Y == loc.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
