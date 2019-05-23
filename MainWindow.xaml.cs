using System;
using System.Collections.Generic;
using System.Linq;
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

namespace _184988GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int iii = 0;
        Rectangle[,] grid = new Rectangle[20, 20];
        public MainWindow()
        {
            InitializeComponent();
            Point point = new Point();
            drawGrid(point, true);
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            Point[] positions = new Point[400];
            int count = 0;
            bool go = true;
            while (go == true)
            {
                string coords = txtInput.Text.Substring(0, 5);

                int.TryParse(txtInput.Text.Substring(1, txtInput.Text.IndexOf(" ") - 1), out int coord);

                positions[count].X = coord;

                int.TryParse(txtInput.Text.Substring(txtInput.Text.IndexOf(" ") + 1, txtInput.Text.IndexOf(")") - txtInput.Text.IndexOf(" ") - 1), out coord);

                positions[count].Y = coord;

                txtInput.Text = txtInput.Text.Substring(5);
                MessageBox.Show(positions[count].X.ToString() + " " + positions[count].Y.ToString());
                count++;
                if (txtInput.Text == "")
                    go = false;
            }

            for (int i = 0; i < 400; i++)
            {
                drawGrid(positions[i], false);
            }
        }

        private void drawGrid(Point p, bool b)
        {
            Point pos = p;


            if (b == true)
            {
                for (int i = 0; i < 20; i++)
                {
                    pos.X = i * 10;
                    for (int ii = 0; ii < 20; ii++)
                    {
                        pos.Y = ii * 10;
                        grid[i, ii] = new Rectangle();
                        grid[i, ii].Stroke = Brushes.Black;
                        grid[i, ii].Fill = Brushes.White;
                        grid[i, ii].Height = 10;
                        grid[i, ii].Width = 10;

                        Canvas.SetLeft(grid[i, ii], pos.X);
                        Canvas.SetTop(grid[i, ii], pos.Y);

                        canvas.Children.Add(grid[i, ii]);

                    }
                }
            }

            else
            {
                for (int i = 0; i < 20; i++)
                {
                    pos.X = pos.X * 10;
                    for (int ii = 0; ii < 20; ii++)
                    {
                        pos.Y = pos.Y * 10;
                        grid[i, ii] = new Rectangle();
                        grid[i, ii].Stroke = Brushes.Black;
                        grid[i, ii].Fill = Brushes.Black;
                        grid[i, ii].Height = 10;
                        grid[i, ii].Width = 10;

                        Canvas.SetLeft(grid[i, ii], pos.X);
                        Canvas.SetTop(grid[i, ii], pos.Y);

                        canvas.Children.Add(grid[i, ii]);
                    }
                }
            }
        }
    }
}
