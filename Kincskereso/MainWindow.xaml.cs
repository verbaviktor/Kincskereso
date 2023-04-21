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

namespace Kincskereso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Tile[,] tiles;

        Dictionary<TileType, SolidColorBrush> tileBrushes = new()
        {
            [TileType.Sarok] = Brushes.Yellow,
            [TileType.Ret] = Brushes.LightGreen,
            [TileType.Domb] = Brushes.SaddleBrown,
            [TileType.Hegy] = Brushes.Gray,
            [TileType.Erdo] = Brushes.DarkGreen
        };

        internal bool GameStarted;

        internal static Random randomGenerator = new();
        public MainWindow()
        {
            InitializeComponent();
            Feltolt();
        }
        void Feltolt()
        {
            tiles = new Tile[8, 8];
            AddNewGrid(TileType.Sarok, 0, 0);
            AddNewGrid(TileType.Sarok, 7, 0);
            AddNewGrid(TileType.Sarok, 7, 7);
            AddNewGrid(TileType.Sarok, 0, 7);
            int RetCount = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    int type;
                    if ((x == 0 || x == 7) && (y == 0 || y == 7))
                    {
                        type = 0;
                    }
                    else
                    {
                        type = GetRandomType();
                        if (type == 1)
                        {
                            type = 2;
                            //RetCount++;
                        }
                    }
                    AddNewGrid((TileType)type, x, y);
                    
                }
            }
            while (RetCount < 6)
            {
                var x = randomGenerator.Next(8);
                var y = randomGenerator.Next(8);
                if ((x == 0 || x == 7) && (y == 0 || y == 7))
                {
                    continue;
                }
                if (tiles[x,y].Type == TileType.Ret)
                {
                    continue;
                }
                AddNewGrid(TileType.Ret, x, y);
                RetCount++;
            }
        }

        public void GridClick(object obj, MouseButtonEventArgs e)
        {
            MessageBox.Show("asd");
        }

        public int GetRandomType()
        {
            var type = randomGenerator.Next(1, 6);
            return type == 5 ? 4 : type;
        }

        public Grid GetNewGrid(TileType type, int x, int y)
        {
            var gr = new Grid();
            gr.PreviewMouseLeftButtonDown += GridClick;
            for (int i = 0; i < 3; i++)
            {
                gr.ColumnDefinitions.Add(new());
                gr.RowDefinitions.Add(new());
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!((i == 0 || i == 2) && (j == 0 || j == 2)))
                    {
                        var t2 = new Grid();
                        Grid.SetColumn(t2, i);
                        Grid.SetRow(t2, j);
                        gr.Children.Add(t2);
                        t2.Children.Add(new TextBlock
                        {
                            Text = "",
                            TextAlignment = TextAlignment.Center,
                            FontSize = 10,
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center
                        });
                    }
                }
            }
            Grid.SetColumn(gr, x);
            Grid.SetRow(gr, y);
            gr.Tag = type;
            return gr;
        }

        public Grid AddNewGrid(TileType type, int x, int y)
        {
            var gr = GetNewGrid(type, x, y);
            tiles[x, y] = new Tile(type);
            gr.Background = tileBrushes[type];
            var t = Board.Children.Cast<UIElement>().FirstOrDefault(elem => Grid.GetColumn(elem) == x && Grid.GetRow(elem) == y);
            if (t != null)
            {
                Board.Children.Remove(t);
            }
            Board.Children.Add(gr);
            return gr;
        }

        private void Dice()
        {
            Random rnd = new Random();
            int roll = rnd.Next(6);

            MessageBox.Show((roll + 1).ToString());
            Image img = new Image();
            img.Source = new BitmapImage(new Uri($"dice/{roll + 1}.png", UriKind.Relative));
            //dice.Content = img;

        }
    }
}
