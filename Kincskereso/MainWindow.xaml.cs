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
using System.Drawing;
using System.IO;

namespace Kincskereso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public static class Directions
    {
        public static System.Drawing.Point Up = new System.Drawing.Point(1, 0);
        public static System.Drawing.Point Down = new System.Drawing.Point(1, 2);
        public static System.Drawing.Point Left = new System.Drawing.Point(0, 1);
        public static System.Drawing.Point Right = new System.Drawing.Point(2, 1);
        public static System.Drawing.Point Middle = new System.Drawing.Point(1, 1);
    }
    public partial class MainWindow : Window
    {
        Tile[,] tiles;

        Grid[,] grids;

        Dictionary<TileType, SolidColorBrush> tileBrushes = new()
        {
            [TileType.Sarok] = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#f2f26f")),
            [TileType.Ret] = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#59eb1b")),
            [TileType.Domb] = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#691804")),
            [TileType.Hegy] = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#71b097")),
            [TileType.Erdo] = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#124a09"))
        };

        Player player;

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
            grids = new Grid[8, 8];
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
            if (obj == null)
            {
                return;
            }
            Grid gr = (Grid)obj;
            int x = Grid.GetColumn(gr);
            int y = Grid.GetRow(gr);
            if (!GameStarted)
            {
                if (!((x == 0 || x == 7) && (y == 0 || y == 7)))
                {
                    return;
                }
                player = new Player(new System.Drawing.Point(x, y));
                GameStarted = true;
                GetTextFromBoard(player.Position, Directions.Middle).Text = "X";
                player.Utcount = 0;
                player.Asocount = 0;
                player.Lepescount = 0;
                return;
            }
            var moveX = player.Position.X - x;
            var absX = Math.Abs(moveX);
            var moveY = player.Position.Y - y;
            var absY = Math.Abs(moveY);

            if (absX > 1 || absY > 1 || absX == absY)
            {
                return;
            }
            GetTextFromBoard(player.Position, Directions.Middle).Text = "";
            switch (moveX)
            {
                case 1:
                    GetTextFromBoard(player.Position, Directions.Left).Text = "—";
                    break;
                case -1:
                    GetTextFromBoard(player.Position, Directions.Right).Text = "—";
                    break;
                default:
                    switch (moveY)
                    {
                        case 1:
                            GetTextFromBoard(player.Position, Directions.Up).Text = "|";
                            break;
                        case -1:
                            GetTextFromBoard(player.Position, Directions.Down).Text = "|";
                            break;
                        default:
                            return;
                    };
                    break;
            }
            player.Position = new System.Drawing.Point(x, y);
            GetTextFromBoard(player.Position, Directions.Middle).Text = "X";
            switch (moveX)
            {
                case 1:
                    GetTextFromBoard(player.Position, Directions.Right).Text = "—";
                    break;
                case -1:
                    GetTextFromBoard(player.Position, Directions.Left).Text = "—";
                    break;
                default:
                    switch (moveY)
                    {
                        case 1:
                            GetTextFromBoard(player.Position, Directions.Down).Text = "|";
                            break;
                        case -1:
                            GetTextFromBoard(player.Position, Directions.Up).Text = "|";
                            break;
                        default:
                            return;
                    };
                    break;
            }



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
                    var t2 = new TextBlock
                    {
                        Text = "",
                        TextAlignment = TextAlignment.Center,
                        FontSize = 10,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    Grid.SetColumn(t2, i);
                    Grid.SetRow(t2, j);
                    gr.Children.Add(t2);
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
            grids[x, y] = gr;
            return gr;
        }

        private void Dice(object obj, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int roll = rnd.Next(6);

            MessageBox.Show((roll + 1).ToString());
            Image img = new Image();
            img.Source = new BitmapImage(new Uri($"dice/{roll + 1}.png", UriKind.Relative));
            //dice.Content = img;

        }

        public bool UnpackPoint(System.Drawing.Point p, out int x, out int y)
        {
            x = p.X;
            y = p.Y;
            return true;
        }

        private UIElement GetPointFromGrid(System.Drawing.Point p, Grid gr)
        {
            UnpackPoint(p, out int x, out int y);
            return gr.Children.Cast<UIElement>().FirstOrDefault(e => Grid.GetColumn(e) == x && Grid.GetRow(e) == y)!;
        }

        private TextBlock GetTextFromBoard(System.Drawing.Point playerPosition, System.Drawing.Point direction)
        {
            var gr1 = GetPointFromGrid(playerPosition, Board);
            return (TextBlock)GetPointFromGrid(direction, (Grid)gr1);
        }
    }
}
