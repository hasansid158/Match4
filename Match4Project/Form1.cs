using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match4Project
{
    public partial class Form1 : Form
    {
        private Rectangle[] boardColumns;
        private int[,] board;
        private int turn;

        public Form1()
        {
            InitializeComponent();
            boardColumns = new Rectangle[7];
            board = new int[6,7];
            turn = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, 24, 24, 340, 300);
            for (int x = 0; x < 6; x++)
            {
                for (int i = 0; i < 7; i++)
                {
                    if(x == 0)
                    {
                        this.boardColumns[i] = new Rectangle(32 + 48 * i, 24, 32, 300);
                    }
                    e.Graphics.FillEllipse(Brushes.White, 32 + 48 * i, 32 + 48 * x, 32, 32);
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int columnIndex = this.Column_Number(e.Location);
            if(columnIndex != -1)
            {
                int rowIndex = EmptyRow(columnIndex);
                if(rowIndex != -1)
                {
                    board[rowIndex, columnIndex] = turn;
                    if(turn == 1)
                    {
                        Graphics g = CreateGraphics();
                        g.FillEllipse(Brushes.Red, 32 + 48 * columnIndex, 32 + 48 * rowIndex, 32, 32);
                    }
                    else if (turn == 2)
                    {
                        Graphics g = CreateGraphics();
                        g.FillEllipse(Brushes.Blue, 32 + 48 * columnIndex, 32 + 48 * rowIndex, 32, 32);
                    }

                    int winner = WinPlayer(turn);
                    if(winner != -1)
                    {
                        string player;
                        if (winner == 1)
                            player = "Red";
                        else
                            player = "Blue";

                        MessageBox.Show("Player " + player + " is the winner !!");
                        Application.Restart();
                    }

                    if (turn == 1)
                        turn = 2;
                    else
                        turn = 1;
                    
                }
            }
        }

        private int WinPlayer(int playerToCheck)
        {
            //Verticle
            for (int row = 0; row < board.GetLength(0) - 3; row++)
            {
                for(int col = 0; col < board.GetLength(1); col++)
                {
                    if(AllNumbersEqual(playerToCheck, board[row, col], board[row + 1, col], board[row + 2, col], board[row + 3, col]))
                    {
                        return playerToCheck;
                    }
                }
            }

            //Horizontal
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1) - 3; col++)
                {
                    if (AllNumbersEqual(playerToCheck, board[row, col], board[row, col + 1], board[row, col + 2], board[row, col + 3]))
                    {
                        return playerToCheck;
                    }
                }
            }
            
            //Diagnol left
            for (int row = 0; row < board.GetLength(0) - 3; row++)
            {
                for (int col = 0; col < board.GetLength(1) - 3; col++)
                {
                    if (AllNumbersEqual(playerToCheck, board[row, col], board[row + 1, col + 1], board[row + 2, col + 2], board[row + 3, col + 3]))
                    {
                        return playerToCheck;
                    }
                }
            }

            //Diagnol right
            for (int row = 0; row < board.GetLength(0) - 3; row++)
            {
                for (int col = 3; col < board.GetLength(1); col++)
                {
                    if (AllNumbersEqual(playerToCheck, board[row, col], board[row + 1, col - 1], board[row + 2, col - 2], board[row + 3, col - 3]))
                    {
                        return playerToCheck;
                    }
                }
            }

            return -1;
        }

        private bool AllNumbersEqual(int toCheck, params int[] numbers)
        {
            foreach(int num in numbers)
            {
                if (num != toCheck)
                    return false;
            }
            return true;
        }

        private int Column_Number(Point mouse)
        {
            for (int x = 0; x < boardColumns.Length; x++)
            {
                if((mouse.X >= boardColumns[x].X) && (mouse.Y >= boardColumns[x].Y))
                {
                    if ((mouse.X <= boardColumns[x].X + boardColumns[x].Width) &&
                        (mouse.Y <= boardColumns[x].Y + boardColumns[x].Height))
                    {
                        return x;
                    }
                }
            }
            return -1;
        }

        private int EmptyRow(int col)
        {
            for(int x = 5; x >= 0; x--)
            {
                if (board[x, col] == 0)
                    return x;
            }
            return -1;
        }
    }
}
