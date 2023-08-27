using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _15_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cell> cells = new List<Cell>();
        Move_cell move_cell;
        private List<Point> points = new List<Point>();
        public MainWindow()
        {
            InitializeComponent();
            insertArea();
            move_cell = new Move_cell(new Point(cells[15].X, cells[15].Y));
        }
        private void insertArea() {
            ShaflePoints();
            for (int number = 1; number <= points.Count; number++) {                    
                    Button btn = new Button();
                    btn.FontSize = 26;
                    btn.Name = $"btn_{number}";
                    btn.Click += ButtonClick;
                    btn.Content = number;
                    if (number == 16)
                    {
                        btn.Content = "";
                        btn.IsEnabled = false;
                    }
                    myGrid.Children.Add(btn);
                    Grid.SetRow(btn, (int)points[number-1].Y);
                    Grid.SetColumn(btn, (int)points[number - 1].X);
                    cells.Add(new Cell(btn, (int)points[number - 1].X, (int)points[number - 1].Y));
                                
            }
        }
        private void ShaflePoints() {
            Random rnd = new Random(DateTime.Now.Second);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    points.Add(new Point(i, j));
                }
            }
            for (int i = 0; i < points.Count; i++)
            {
                var tmp = points[0];
                points.RemoveAt(0);
                points.Insert(rnd.Next(points.Count), tmp);
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            swapCells((Button)sender);
            WinCheck();
        }

        private void swapCells(Button pButton) {
            Point button = new Point(cells[(int)pButton.Content-1].X, cells[(int)pButton.Content-1].Y);
            Point tmp = move_cell.FreeSpaceCheck(button);
            Grid.SetRow(pButton,(int)tmp.Y);
            Grid.SetColumn(pButton, (int)tmp.X);
            cells[(int)pButton.Content - 1].X = (int)tmp.X;
            cells[(int)pButton.Content - 1].Y = (int)tmp.Y;
            Grid.SetRow(cells[15].Button, move_cell.Y);
            Grid.SetColumn(cells[15].Button, move_cell.X);
        }
        private void WinCheck() {
            int number = 1,x=0;
            foreach (Button item in myGrid.Children) {
                int y = (number - 1) / 4;
                if (cells[(int)item.Content - 1].X!=x++ ||
                    cells[(int)item.Content - 1].Y!=y) {
                    return;
                }
                if (x == 4)
                    x = 0;
                if (number == 13)
                {
                   var res = MessageBox.Show("Win");
                    if(res == MessageBoxResult.OK)
                        this.Close();
                }
                number++;
            }
        
        }
    }
}
