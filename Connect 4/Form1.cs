using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect_4
{
    public partial class Form1 : Form
    {
        private const int Rows = 6;
        private const int Columns = 7;

        private Color player1Color = Color.Red;
        private Color player2Color = Color.Blue;
        private Color currentColor = Color.Red;
        private Button[,] buttons = new Button[Rows, Columns];

        public Form1()
        {
            InitializeComponent();
            CreateButtonGrid();
        }
        private void CreateButtonGrid()
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.RowCount = Rows;
            tableLayoutPanel.ColumnCount = Columns;

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Button button = new Button();
                    button.Margin = new Padding(0);
                    button.BackColor = Color.White;
                    button.Width = 50;
                    button.Height = 50;

                    button.Click += Button_Click;

                    tableLayoutPanel.Controls.Add(button, col, row);
                    buttons[row, col] = button;

                }
            }

            Controls.Add(tableLayoutPanel);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if(clickedButton.BackColor == Color.White)
            {
                clickedButton.BackColor = currentColor;

                if(CheckWin(clickedButton))
                {
                    MessageBox.Show($"{currentColor} wins!");
                    ResetGame();
                }
                currentColor = (currentColor == player1Color) ? player2Color : player1Color;
            }

            else
            {
                return;
            }
        }

        private bool CheckWin(Button clickedButton)
        {
            int row = int.Parse(clickedButton.Text.Split('-')[0]);
            int col = int.Parse(clickedButton.Text.Split('-')[1]);

            if(CheckHorizontalWin(row,col))
            {
                return true;
            }
            return false;
        }

        private bool CheckHorizontalWin(int row, int col)
        {
            
            return false;
        }
        private void ResetGame()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    buttons[row, col].BackColor = Color.Empty;
                }
            }
        }

    }
}
