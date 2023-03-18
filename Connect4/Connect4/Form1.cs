using System.CodeDom;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Connect4
{
    public partial class Form1 : Form
    {
        int NUMBER_OF_ROWS;
        int NUMBER_OF_COLS;
        const int CIRCLE_DIAMETER = 50;
        const int LEFT_SHIFT = 50;
        const int TOP_SHIFT = 50;
        int SEPARATOR = 10;
        Graphics[,] grid;  
        int[,] cellStatus;
        bool player1;


        public Form1()
        {
            InitializeComponent();
        }

        private void Draw_Grid()
        {
            cellStatus = new int[NUMBER_OF_ROWS, NUMBER_OF_COLS];
            player1 = true;
            label1.BackColor = Color.FromArgb(255, 0, 0, 255); ;

            Color yellow = Color.FromArgb(255, 255, 255, 0);
            SolidBrush solidYellow = new SolidBrush(yellow);
            Color white = Color.FromArgb(255, 255, 255, 255);
            SolidBrush solidWhite = new SolidBrush(white);
            Pen yellowPen = new Pen(yellow);
            Pen whitePen = new Pen(white);
            yellowPen.Width = 1;

            Graphics graphics = this.CreateGraphics();
            graphics.Clear(Color.White);
            graphics.FillRectangle(
                solidYellow,
                LEFT_SHIFT,
                TOP_SHIFT,
                NUMBER_OF_COLS * CIRCLE_DIAMETER + (NUMBER_OF_COLS + 1) * SEPARATOR,
                NUMBER_OF_ROWS * CIRCLE_DIAMETER + (NUMBER_OF_ROWS + 1) * SEPARATOR
            );

            int topShift = TOP_SHIFT + SEPARATOR;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                int leftShift = LEFT_SHIFT + SEPARATOR;
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    grid[row, col] = this.CreateGraphics();
                    grid[row, col].DrawEllipse(whitePen, leftShift, topShift, CIRCLE_DIAMETER, CIRCLE_DIAMETER);
                    grid[row, col].FillEllipse(solidWhite, leftShift, topShift, CIRCLE_DIAMETER, CIRCLE_DIAMETER);
                    leftShift += CIRCLE_DIAMETER + SEPARATOR;
                }
                topShift += CIRCLE_DIAMETER + SEPARATOR;
            }
        }

        private void Form1_paint(object sender, PaintEventArgs e)
        {
           
            
        }

        public void checkHorizontal()
        {
            for(int i = grid.GetLength(0)-1; i >= 0; i--)
            {
                for (int j = 0; j<grid.GetLength(1)-3; j++) 
                {
                    //Console.WriteLine(grid[i, j]);
                    //if(j-1 < 0 || j - 2 < 0 || j - 3 < 0) { continue; }
                    int currentCellStatus = cellStatus[i, j];
                    if (currentCellStatus != 0 && currentCellStatus ==  cellStatus[i, j+1] && currentCellStatus == cellStatus[i, j+2] && currentCellStatus == cellStatus[i, j + 3])
                    {
                        if(currentCellStatus == 1)
                        {
                            MessageBox.Show("The Blue player is the winner!!");
                            Draw_Grid();
                        }
                        else
                        {
                            MessageBox.Show("The Red player is the winner!!");
                            Draw_Grid();
                        }
                    }
                }
            }
        }

        public void checkVertical()
        {
            for (int i = grid.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    //Console.WriteLine(grid[i, j]);
                    //if(j-1 < 0 || j - 2 < 0 || j - 3 < 0) { continue; }
                    int currentCellStatus = cellStatus[i, j];
                    if (currentCellStatus != 0 && currentCellStatus == cellStatus[i - 1, j] && currentCellStatus == cellStatus[i - 2, j] && currentCellStatus == cellStatus[i - 3, j])
                    {
                        if (currentCellStatus == 1)
                        {
                            MessageBox.Show("The Blue player is the winner!!");
                            Draw_Grid();
                        }
                        else
                        {
                            MessageBox.Show("The Red player is the winner!!");
                            Draw_Grid();
                        }
                    }
                }
            }
        }

        public void checkLeftDiagonal()
        {
            for (int i = 0; i < grid.GetLength(0) - 3; i++)
            {
                for (int j = 0; j < grid.GetLength(1) - 3; j++)
                {
                    //Console.WriteLine(grid[i, j]);
                    //if(j-1 < 0 || j - 2 < 0 || j - 3 < 0) { continue; }
                    int currentCellStatus = cellStatus[i, j];
                    if (currentCellStatus != 0 && currentCellStatus == cellStatus[i + 1, j + 1] && currentCellStatus == cellStatus[i + 2, j + 2] && currentCellStatus == cellStatus[i + 3, j + 3])
                    {
                        if (currentCellStatus == 1)
                        {
                            MessageBox.Show("The Blue player is the winner!!");
                            Draw_Grid();
                        }
                        else
                        {
                            MessageBox.Show("The Red player is the winner!!");
                            Draw_Grid();
                        }
                    }
                }
            }
        }
        public void checkRighttDiagonal()
        {
            for (int i = 0; i < grid.GetLength(0) - 3; i++)
            {
                for (int j = 0; j < grid.GetLength(1) ; j ++)
                {
                    //Console.WriteLine(grid[i, j]);
                    //if(j-1 < 0 || j - 2 < 0 || j - 3 < 0) { continue; }
                    int currentCellStatus = cellStatus[i, j];
                    if (currentCellStatus != 0 
                        && currentCellStatus == cellStatus[i + 1, j - 1]
                        && currentCellStatus == cellStatus[i +2, j - 2]
                        && currentCellStatus == cellStatus[i + 3, j - 3])
                    {
                        if (currentCellStatus == 1)
                        {
                            MessageBox.Show("The Blue player is the winner!!");
                            Draw_Grid();
                        }
                        else
                        {
                            MessageBox.Show("The Red player is the winner!!");
                            Draw_Grid();
                        }
                    }
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Color blue = Color.FromArgb(255, 0, 0, 255);
            SolidBrush solidBlue = new SolidBrush(blue);
            Color red = Color.FromArgb(255, 255, 0, 0);
            SolidBrush solidRed = new SolidBrush(red);
            int click = e.X;

            int leftShift = LEFT_SHIFT + SEPARATOR;
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                int topShift = TOP_SHIFT + SEPARATOR + (NUMBER_OF_ROWS - 1) * (CIRCLE_DIAMETER + SEPARATOR);
                if (click >= leftShift && click < leftShift + CIRCLE_DIAMETER + SEPARATOR)
                {
                    for (int row = grid.GetLength(0) - 1; row >= 0; row--)
                    {
                        if (cellStatus[row, col] == 0)
                        {

                            if (player1 == true)
                            {
                                grid[row, col].FillEllipse(solidBlue, leftShift, topShift, CIRCLE_DIAMETER, CIRCLE_DIAMETER);
                                label1.BackColor = red;
                                cellStatus[row, col] = 1;
                                player1 = false;
                                checkHorizontal();
                                checkLeftDiagonal();
                                
                                checkRighttDiagonal();
                            }
                            else
                            {
                                grid[row, col].FillEllipse(solidRed, leftShift, topShift, CIRCLE_DIAMETER, CIRCLE_DIAMETER);
                                label1.BackColor = blue;
                                cellStatus[row, col] = 2;
                                player1 = true;
                                checkHorizontal();
                                checkLeftDiagonal();
                                
                                checkRighttDiagonal();
                            }
                            break;
                        }
                        else { topShift -= CIRCLE_DIAMETER + SEPARATOR; }

                    }
                    break;
                }
                else
                {
                    leftShift += CIRCLE_DIAMETER + SEPARATOR;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NUMBER_OF_ROWS = 4;
            NUMBER_OF_COLS = 7;
            grid = new Graphics[NUMBER_OF_ROWS, NUMBER_OF_COLS];
            Draw_Grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NUMBER_OF_ROWS = 6;
            NUMBER_OF_COLS = 10;
            grid = new Graphics[NUMBER_OF_ROWS, NUMBER_OF_COLS];
            Draw_Grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NUMBER_OF_ROWS = 8;
            NUMBER_OF_COLS = 15;
            grid = new Graphics[NUMBER_OF_ROWS, NUMBER_OF_COLS];
            Draw_Grid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}