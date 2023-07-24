using Games.GameGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
namespace Games
{
    public partial class Form1 : Form
    {
        GamePacManPlayer pacman;
        public static  int Score = 0;
        public static int Health= 100;
        GameGrid grid;
        public static List<Ghost> ghosts = new List<Ghost>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GameGrid grid = new GameGrid("maze.txt", 20, 70);
           Image pacManImage = Game.getGameObjectImage('P');
           Image pacMan = Game.getGameObjectImage('G');
            GameCell startCelll = grid.getCell(3, 10);
            GameCell startCells = grid.getCell(6 , 22);
            GameCell startCell = grid.getCell(8, 10);
           GameCell startCell2 = grid.getCell(16  , 6);
           GameCell startCell3 = grid.getCell(16, 14);
           Ghost ghost = new HorizontalGhost(pacMan, startCelll);
            Ghost ghost1 = new VerticalGhost(pacMan, startCells);
            Ghost ghost2 = new RandomGhost(pacMan, startCell2);
            Ghost ghost3 = new RandomGhost(pacMan, startCell3);
            pacman = new GamePacManPlayer(pacManImage, startCell);
           

            printMaze(grid);
            ghosts.Add(ghost);
            ghosts.Add(ghost1);
            ghosts.Add(ghost2);
            ghosts.Add(ghost3);
        }
       
        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e )
        {
          
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                pacman.move(GameDirection.Up);
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
               pacman.move(GameDirection.Down);
            }

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
             pacman.move(GameDirection.Right);
            }

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                 pacman.move(GameDirection.Left);
            }
          
            moveGhost(pacman);
            textBox1.Text = Score.ToString();
            textBox2.Text = Health.ToString();
        }
        public static void moveGhost(GamePacManPlayer pacman)
        {
            foreach (Ghost g in ghosts)
            {
                GameCell playerCell = pacman.CurrentCell;
                // GameCell currentCell = g.CurrentCell1;
                    GameCell nextCell = g.Move();
                if (Collision.CheckCollision(playerCell))
                {
                    DecreaseHealth();
                    // Collision detected between player and ghost
                  //  pacman.CanMove = false;
                    g.IsStopped = false;
                   
                }
            }
        }
        public static void DecreaseHealth()
        {
            Health -= 1;
            if (Health == 0)
            {
                // Game over logic
                // You can handle the game over condition according to your requirements
                // For example, show a message box or end the game
                MessageBox.Show("Game Over!");
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

        }


    }
}
