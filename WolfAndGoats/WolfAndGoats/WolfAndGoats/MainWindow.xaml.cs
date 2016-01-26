using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace WolfAndGoats
{
    // Graphic and drawing window
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawingWindow DrawBoard = new DrawingWindow();
            Color DefaultColor = Colors.DarkSeaGreen;
            DrawBoard.CreateCells(GameBoard, DefaultColor);
            Brush DefaultBrush = Brushes.DarkSlateGray;
            DrawBoard.CreateBorder(BorderBoard, DefaultBrush);

        }

        private void StartTheGame(object sender, RoutedEventArgs e)
        {
            GameBuilder Game = new GameBuilder();
            Game.StartPosition();
        }
    }

    public class DrawingWindow
    {
        public void CreateCells(Grid GameBoard, Color ChoiceColor)
        {
            const int c_MakeBoard = 8;
            int temp;
            for (int counterRow = 0; counterRow < c_MakeBoard; counterRow++)
            {
                temp = counterRow % 2 == 0 ? 0 : 1;
                for (int counterCol = temp; counterCol < c_MakeBoard; counterCol = counterCol + 2)
                {
                    Rectangle MakeColorCells = new Rectangle();
                    MakeColorCells.Fill = new SolidColorBrush(ChoiceColor);      //SkyBlue
                    GameBoard.Children.Add(MakeColorCells);
                    Grid.SetColumn(MakeColorCells, counterCol);
                    Grid.SetRow(MakeColorCells, counterRow);
                }
            }
        }

        public void CreateBorder(Border BorderBoard, Brush ChoiceColor)
        {
            BorderBoard.BorderBrush = ChoiceColor;
            BorderBoard.BorderThickness = new Thickness(7);
        }
    }


    // Logical part
    public enum Cells { Cell = 0, Wolf = -1, Goats = 1 };

    public class GameBuilder
    {
        public int[,] Board { get; set; } =                                                                           // Make board 8x8
            { { (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell},
            { (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell},
            { (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell},
            { (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell},
            { (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell},
            { (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell},
            { (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell},
            { (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell, (int)Cells.Cell} };

        public void StartPosition()
        {
            Board[0, 7] = (int)Cells.Goats;
            for (int setGoats = 0; setGoats < 8; setGoats = setGoats + 2)
            {
                Board[7, setGoats] = (int)Cells.Goats;
            }
        }

        public void ChangeBoard(int[,] copyBoard, int xPos, int yPos)
        {
            if (Board[xPos, yPos] == (int)Cells.Goats)
            {

            }
            else if (Board[xPos, yPos] == (int)Cells.Wolf)
            {

            }
            else if (Board[xPos, yPos] == (int)Cells.Cell)
            {

            }
        }
    }

    public abstract class Animals
    {
        public abstract void Move(int[,] Board);
        public abstract bool Win(GameBuilder Game);

    }
    public class Goat : Animals
    {



        public override void Move(int[,] Board)
        {

        }

        public override bool Win(GameBuilder Game)
        {
            Wolf Enemy = new Wolf();
            if (Enemy.CanMove())
            {
                return true;
            }
            return false;
        }
    }

    public class Wolf : Animals
    {





        public override void Move(int[,] Board)
        {
            throw new NotImplementedException();
        }

        public override bool Win(GameBuilder Game)
        {
            const int c_WinPoints = 4;
            for (int counter = 0; counter < c_WinPoints; counter++)
            {
                if (Game.Board[1, counter] == counter * 2)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CanMove()
        {

        }
    }

}
