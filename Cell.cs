using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _15_wpf
{
    internal class Cell
    {
        private Button _button;
        private int _row;
        private int _col;
        public int X { get { return _col; } set { _col = value; } }
        public int Y { get { return _row; } set { _row = value; } }
        public Button Button { get { return _button; }set { _button = value; } }
        public Cell(Button button,int x, int y) { 
            _button = button;
            _col = x;
            _row = y;
        }
    }
}
