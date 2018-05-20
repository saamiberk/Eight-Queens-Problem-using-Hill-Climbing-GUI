using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eight_Queen
{
    public partial class Form1 : Form
    {
        static int SIZE = 8;        
        int[] queenStartCord = new int[SIZE];      
        int[,] board = new int[8, 8];
        int cost = 0;

        int minValue = int.MaxValue;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            foreach (var pb in this.Controls.OfType<PictureBox>()) pb.BackColor = Color.Transparent;
        }

        // Cost Calculation for each Square
        public int CostCalculate(List<int> temp)
        {
            if (temp.Count > 1)
            {
                for (int i = 1; i < temp.Count; i++)
                {
                    if (temp[0] == temp[i]) // Row check
                    {
                        cost++;
                    }
                    if (Math.Abs(temp[0] - temp[i]) == Math.Abs(0 - (i)))
                    {
                        cost++;
                    }

                }
                temp.RemoveAt(0);
                CostCalculate(temp);
            }
            return cost;
        }

        // Select Each Square for Cost Calculation
        public async Task CheckSquares(int[] array)
        {
            count++;
            
            for (int i = 0; i < 8; i++) // Column
            {
                for (int j = 0; j < 8; j++) // Row
                {
                    cost = 0;
                    if (array[i] != j)
                    {
                        var myList = array.ToList();
                        myList[i] = j;
                        board[j, i] = CostCalculate(myList);
                    }
                    else
                    {
                        board[j, i] = 99;
                    }
                }                
            }

            // Get min list
            var myCord = FindMin(board);

            // Random select min cost cord
            int number = GetRandom(myCord.Count);
            
            // Change queen place to lower cost
            queenStartCord[myCord[number + 1]] = myCord[number];

            await Task.Delay(10);
            await AllImageBoxDisable();
            await ImageBoxEnable(queenStartCord);


        }

        // Find Minimum Value and Cordinates
        public List<int> FindMin(int[,] board)
        {
            minValue = int.MaxValue;
            var minCord = new List<int>();
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == minValue)
                    {

                        minCord.Add(row);
                        minCord.Add(col);

                    }
                    if (board[row, col] < minValue)
                    {
                        minValue = board[row, col];

                        minCord.Clear();
                        minCord.Add(row);
                        minCord.Add(col);

                    }

                }

            }
                      
            return minCord;
        }

        // Select One Between Same Costs
        public int GetRandom(int length)
        {
            Random rnd = new Random();
            int number = 2 * rnd.Next(0, length / 2);
            return number;

        }

        // With Given
        private async void Start_Click(object sender, EventArgs e)
        {
            lbl_log.Text = "Starting...";
            board = new int[8, 8];
            cost = 0;          
            minValue = int.MaxValue;
            count = 0;
            queenStartCord = new int[] { 0, 2, 4, 6, 1, 3, 5, 7 };  //row ;          
            await AllImageBoxDisable();
            await ImageBoxEnable(queenStartCord);
            await Task.Delay(2000);
            lbl_log.Text = "Finding...";
            while (minValue != 0)
            {
                await CheckSquares(queenStartCord);
                await Task.Delay(1);
                lbl_cost.Text = minValue.ToString();
                
            }
            lbl_log.Text = "Success";
        }

        // With Random
        private async void Random_Click(object sender, EventArgs e)
        {
            lbl_log.Text = "Starting...";
            board = new int[8, 8];
            cost = 0;
            minValue = int.MaxValue;
            count = 0;
            queenStartCord = RandomQueenPlaceGenerator();
           
       
            await AllImageBoxDisable();
            await ImageBoxEnable(queenStartCord);
            await Task.Delay(2000);
            lbl_log.Text = "Finding...";
            while (minValue != 0)
            {
                await CheckSquares(queenStartCord);
                await Task.Delay(1);
                lbl_cost.Text = minValue.ToString();

            }
            lbl_log.Text = "Success";
        }

        // Random Generate Eight Queens
        public int[] RandomQueenPlaceGenerator()
        {
            int[] randomQueen = new int[SIZE];
            Random rnd = new Random();
            for (int i = 0; i < SIZE; i++)
            {
                randomQueen[i] = rnd.Next(0, 8);

            }

            return randomQueen;
        }

        // Disable All Queens on Board
        public async Task AllImageBoxDisable()
        {
            foreach (var pb in this.Controls.OfType<PictureBox>()) pb.Visible = false;
            await Task.Delay(1);
        }

        // Queen Image Enable
        public async Task ImageBoxEnable(int[] array)
        {
            string a = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {

                a = a.ToString() + '(' + i.ToString() + ',' +array[i].ToString()+ ')'+' ';
               
                #region 1 Row Images
                if (i == 0)
                {
                    if (array[i] == 0)
                    {
                        queen00.Visible = true;
                        queen00.BringToFront();
                    }
                    else if (array[i] == 1)
                    {
                        queen10.Visible = true;
                        queen10.BringToFront();
                    }
                    else if (array[i] == 2)
                    {
                        queen20.Visible = true;
                        queen20.BringToFront();
                    }
                    else if (array[i] == 3)
                    {
                        queen30.Visible = true;
                        queen30.BringToFront();
                    }
                    else if (array[i] == 4)
                    {
                        queen40.Visible = true;
                        queen40.BringToFront();
                    }
                    else if (array[i] == 5)
                    {
                        queen50.Visible = true;
                        queen50.BringToFront();
                    }
                    else if (array[i] == 6)
                    {
                        queen60.Visible = true;
                        queen60.BringToFront();
                    }
                    else if (array[i] == 7)
                    {
                        queen70.Visible = true;
                        queen70.BringToFront();
                    }
                }

                #endregion

                #region 2 Row Images
                if (i == 1)
                {
                    if (array[i] == 0)
                    {
                        queen01.Visible = true;
                        queen01.BringToFront();

                    }
                    else if (array[i] == 1)
                    {
                        queen11.Visible = true;
                        queen11.BringToFront();
                    }
                    else if (array[i] == 2)
                    {
                        queen21.Visible = true;
                        queen21.BringToFront();
                    }
                    else if (array[i] == 3)
                    {
                        queen31.Visible = true;
                        queen31.BringToFront();
                    }
                    else if (array[i] == 4)
                    {
                        queen41.Visible = true;
                        queen41.BringToFront();
                    }
                    else if (array[i] == 5)
                    {
                        queen51.Visible = true;
                        queen51.BringToFront();
                    }
                    else if (array[i] == 6)
                    {
                        queen61.Visible = true;
                        queen61.BringToFront();
                    }
                    else if (array[i] == 7)
                    {
                        queen71.Visible = true;
                        queen71.BringToFront();
                    }
                }

                #endregion

                #region MyRegion
                if (i == 2)
                {
                    if (array[i] == 0)
                    {
                        queen02.Visible = true;
                        queen02.BringToFront();

                    }
                    else if (array[i] == 1)
                    {
                        queen12.Visible = true;
                        queen12.BringToFront();
                    }
                    else if (array[i] == 2)
                    {
                        queen22.Visible = true;
                        queen22.BringToFront();
                    }
                    else if (array[i] == 3)
                    {
                        queen32.Visible = true;
                        queen32.BringToFront();
                    }
                    else if (array[i] == 4)
                    {
                        queen42.Visible = true;
                        queen42.BringToFront();
                    }
                    else if (array[i] == 5)
                    {
                        queen52.Visible = true;
                        queen52.BringToFront();
                    }
                    else if (array[i] == 6)
                    {
                        queen62.Visible = true;
                        queen62.BringToFront();
                    }
                    else if (array[i] == 7)
                    {
                        queen72.Visible = true;
                        queen72.BringToFront();
                    }
                }

                #endregion

                #region 3 Row Images

                else if (i == 3)
                {
                    if (array[i] == 0)
                    {
                        queen03.Visible = true;
                        queen03.BringToFront();

                    }
                    else if (array[i] == 1)
                    {
                        queen13.Visible = true;
                        queen13.BringToFront();
                    }
                    else if (array[i] == 2)
                    {
                        queen23.Visible = true;
                        queen23.BringToFront();
                    }
                    else if (array[i] == 3)
                    {
                        queen33.Visible = true;
                        queen33.BringToFront();
                    }
                    else if (array[i] == 4)
                    {
                        queen43.Visible = true;
                        queen43.BringToFront();
                    }
                    else if (array[i] == 5)
                    {
                        queen53.Visible = true;
                        queen53.BringToFront();
                    }
                    else if (array[i] == 6)
                    {
                        queen63.Visible = true;
                        queen63.BringToFront();
                    }
                    else if (array[i] == 7)
                    {
                        queen73.Visible = true;
                        queen73.BringToFront();
                    }
                }


                #endregion

                #region 4 Row Images
                else if (i == 4)
                {
                    if (array[i] == 0)
                    {
                        queen04.Visible = true;
                        queen04.BringToFront();

                    }
                    if (array[i] == 1)
                    {
                        queen14.Visible = true;
                        queen14.BringToFront();
                    }
                    if (array[i] == 2)
                    {
                        queen24.Visible = true;
                        queen24.BringToFront();
                    }
                    if (array[i] == 3)
                    {
                        queen34.Visible = true;
                        queen34.BringToFront();
                    }
                    if (array[i] == 4)
                    {
                        queen44.Visible = true;
                        queen44.BringToFront();
                    }
                    if (array[i] == 5)
                    {
                        queen54.Visible = true;
                        queen54.BringToFront();
                    }
                    if (array[i] == 6)
                    {
                        queen64.Visible = true;
                        queen64.BringToFront();
                    }
                    if (array[i] == 7)
                    {
                        queen74.Visible = true;
                        queen74.BringToFront();
                    }

                }

                #endregion

                #region 5 Row Images
                else if (i == 5)
                {

                    if (array[i] == 0)
                    {
                        queen05.Visible = true;
                        queen05.BringToFront();

                    }
                    else if (array[i] == 1)
                    {
                        queen15.Visible = true;
                        queen15.BringToFront();

                    }
                    else if (array[i] == 2)
                    {
                        queen25.Visible = true;
                        queen25.BringToFront();

                    }
                    else if (array[i] == 3)
                    {
                        queen35.Visible = true;
                        queen35.BringToFront();

                    }
                    else if (array[i] == 4)
                    {
                        queen45.Visible = true;
                        queen45.BringToFront();

                    }
                    else if (array[i] == 5)
                    {
                        queen55.Visible = true;
                        queen55.BringToFront();

                    }
                    else if (array[i] == 6)
                    {
                        queen65.Visible = true;
                        queen65.BringToFront();

                    }
                    else if (array[i] == 7)
                    {
                        queen75.Visible = true;
                        queen75.BringToFront();

                    }
                }


                #endregion

                #region 6 Row Images
                else if (i == 6)
                {
                    if (array[i] == 0)
                    {
                        queen06.Visible = true;
                        queen06.BringToFront();
                    }
                    else if (array[i] == 1)
                    {
                        queen16.Visible = true;
                        queen16.BringToFront();

                    }
                    else if (array[i] == 2)
                    {
                        queen26.Visible = true;
                        queen26.BringToFront();

                    }
                    else if (array[i] == 3)
                    {
                        queen36.Visible = true;
                        queen36.BringToFront();

                    }
                    else if (array[i] == 4)
                    {
                        queen46.Visible = true;
                        queen46.BringToFront();

                    }
                    else if (array[i] == 5)
                    {
                        queen56.Visible = true;
                        queen56.BringToFront();

                    }
                    else if (array[i] == 6)
                    {
                        queen66.Visible = true;
                        queen66.BringToFront();


                    }
                    else if (array[i] == 7)
                    {
                        queen76.Visible = true;
                        queen76.BringToFront();

                    }
                }

                #endregion

                #region 7 Row Images
                else if (i == 7)
                {

                    if (array[i] == 0)
                    {
                        queen07.Visible = true;
                        queen07.BringToFront();

                    }
                    else if (array[i] == 1)
                    {
                        queen17.Visible = true;
                        queen17.BringToFront();
                    }
                    else if (array[i] == 2)
                    {
                        queen27.Visible = true;
                        queen27.BringToFront();
                    }
                    else if (array[i] == 3)
                    {
                        queen37.Visible = true;
                        queen37.BringToFront();
                    }
                    else if (array[i] == 4)
                    {
                        queen47.Visible = true;
                        queen47.BringToFront();
                    }
                    else if (array[i] == 5)
                    {
                        queen57.Visible = true;
                        queen57.BringToFront();
                    }
                    else if (array[i] == 6)
                    {
                        queen67.Visible = true;
                        queen67.BringToFront();

                    }
                    else if (array[i] == 7)
                    {
                        queen77.Visible = true;
                        queen77.BringToFront();
                    }
                }
                #endregion


                lbl_count.Text = count.ToString();
                lbl_cordinates.Text = a;
              
                await Task.Delay(1);

            }


        }




       
    }
}



