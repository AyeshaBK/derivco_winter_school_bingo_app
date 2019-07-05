using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoAppClasses.Classes
{
   public class StripGenerator
    {



        int[][,] strips = 
        {
                    new int[,]
                    { 
                        {4,0,28,31,0,0,60,78,0},
                        {0,14,27,0,0,59,63,0,83},
                        {8,0,25,0,49,51,0,0,89},

                        {0,0,24,0,45,57,69,0,81},
                        {0,19,0,35,40,0,64,79,0 },
                        {6,15,23,38,0,0,0,72,0 },

                        {0,16,0,33,0,50,62,75,0 },
                        {0,10,0,36,46,0,0,70,86},
                        {3,0,29,0,0,58,66,0,90},

                        {2,0,0,30,43,0,0,76,84},
                        {1,17,20,0,0,0,61,0,87},
                        {0,12,26,39,0,55,65,0,0},

                        {0,0,21,0,47,52,0,77,85},
                        {7,18,0,0,41,53,0,74,0},
                        {0,0,0,34,48,56,68,73,0},

                        {0,11,0,37,44,0,67,0,80},
                        {5,0,22,32,0,54,0,0,82},
                        {9,13,0,0,42,0,0,71,88}
                    },


                    new int[,]  
                    { 
                        {5,10,0,32,48,0,69,0,0},
                        {0,18,0,35,40,55,0,0,87},
                        {0,17,21,0,46,0,0,78,81},

                        {8,0,0,36,0,57,63,76,0},
                        {7,16,0,0,49,0,0,77,90},
                        {0,19,27,0,44,54,0,79,0},

                        {0,12,28,0,0,52,65,0,86},
                        {0,0,22,38,45,58,0,75,0},
                        {1,0,25,0,41,0,64,0,83},

                        {9,0,0,0,42,0,62,74,88},
                        {0,13,20,37,0,0,66,71,0},
                        {0,0,26,0,0,53,61,70,80},

                        {2,0,0,30,0,50,68,0,85},
                        {0,14,24,0,47,56,60,0,0},
                        {0,15,29,39,0,0,0,73,82},

                        {4,0,0,33,43,0,67,0,89},
                        {6,11,23,34,0,59,0,0,0},
                        {3,0,0,31,0,51,0,72,84}
                    },

                    new int[,] 

                    { 
                        {0,0,0,31,47,0,67,73,87},
                        {5,18,21,0,0,0,64,78,0},
                        {0,0,28,37,43,52,61,0,0},

                        {9,13,24,0,0,58,0,0,89},
                        {0,16,0,32,40,0,60,0,86},
                        {1,11,26,0,42,0,0,76,0},

                        {3,19,0,0,0,56,0,74,82},
                        {7,10,25,34,0,0,0,71,0},
                        {0,0,0,0,46,51,68,70,81},

                        {0,0,0,0,48,54,65,79,80},
                        {8,14,23,39,0,53,0,0,0},
                        {0,0,0,36,45,0,63,77,90},

                        {2,15,27,0,0,0,62,0,88},
                        {0,17,0,38,41,59,0,0,83},
                        {6,0,22,35,0,57,0,75,0},

                        {4,0,0,33,0,55,66,0,85},
                        {0,12,29,30,49,50,0,0,0},
                        {0,0,20,0,44,0,69,72,84}
                    }
        };



        int[] row1Nums = new int[9];
        int[] row2Nums = new int[9];
        int[] row3Nums = new int[9];
        int[] row4Nums = new int[9];
        int[] row5Nums = new int[9];
        int[] row6Nums = new int[9];
        int[] row7Nums = new int[9];
        int[] row8Nums = new int[9];
        int[] row9Nums = new int[9];
        int[] row10Nums = new int[9];
        int[] row11Nums = new int[9];
        int[] row12Nums = new int[9];
        int[] row13Nums = new int[9];
        int[] row14Nums = new int[9];
        int[] row15Nums = new int[9];
        int[] row16Nums = new int[9];
        int[] row17Nums = new int[9];
        int[] row18Nums = new int[9];

        List<Ball> ballList1 = new List<Ball>(1);
        List<Ball> ballList2 = new List<Ball>(1);
        List<Ball> ballList3 = new List<Ball>(1);
        List<Ball> ballList4 = new List<Ball>(1);
        List<Ball> ballList5 = new List<Ball>(1);
        List<Ball> ballList6 = new List<Ball>(1);
        List<Ball> ballList7 = new List<Ball>(1);
        List<Ball> ballList8 = new List<Ball>(1);
        List<Ball> ballList9 = new List<Ball>(1);
        List<Ball> ballList10 = new List<Ball>(1);
        List<Ball> ballList11 = new List<Ball>(1);
        List<Ball> ballList12 = new List<Ball>(1);
        List<Ball> ballList13 = new List<Ball>(1);
        List<Ball> ballList14 = new List<Ball>(1);
        List<Ball> ballList15 = new List<Ball>(1);
        List<Ball> ballList16 = new List<Ball>(1);
        List<Ball> ballList17 = new List<Ball>(1);
        List<Ball> ballList18 = new List<Ball>(1);




        public Strip GetStrip()
        {
            Random random = new Random();
            int num = random.Next(0,3);
            int[,] stripNumbers = strips[num];


            //Filling rows
            Row ticket1row1 = new Row();
            Row ticket1row2 = new Row();
            Row ticket1row3 = new Row();
            Row ticket2row1 = new Row();
            Row ticket2row2 = new Row();
            Row ticket2row3 = new Row();
            Row ticket3row1 = new Row();
            Row ticket3row2 = new Row();
            Row ticket3row3 = new Row();
            Row ticket4row1 = new Row();
            Row ticket4row2 = new Row();
            Row ticket4row3 = new Row();
            Row ticket5row1 = new Row();
            Row ticket5row2 = new Row();
            Row ticket5row3 = new Row();
            Row ticket6row1 = new Row();
            Row ticket6row2 = new Row();
            Row ticket6row3 = new Row();



            SplitArrays(stripNumbers);
            //PrintRowNumbers();

            ticket1row1.ID = "1";
            ticket1row2.ID = "2";
            ticket1row3.ID = "3";
            ticket2row1.ID = "4";
            ticket2row2.ID = "5";
            ticket2row3.ID = "6";
            ticket3row1.ID = "7";
            ticket3row2.ID = "8";
            ticket3row3.ID = "9";
            ticket4row1.ID = "10";
            ticket4row2.ID = "11";
            ticket4row3.ID = "12";
            ticket5row1.ID = "13";
            ticket5row2.ID = "14";
            ticket5row3.ID = "15";
            ticket6row1.ID = "16";
            ticket6row2.ID = "17";
            ticket6row3.ID = "18";


          

            //Fill each Row with balls.
            FillRowsWithBalls();

            PrintBallListNumbers();


            //Set ballList for Rows

            ticket1row1.BallList = ballList1;
            ticket1row2.BallList = ballList2;
            ticket1row3.BallList = ballList3;
            ticket2row1.BallList = ballList4;
            ticket2row2.BallList = ballList5;
            ticket2row3.BallList = ballList6;
            ticket3row1.BallList = ballList7;
            ticket3row2.BallList = ballList8;
            ticket3row3.BallList = ballList9;
            ticket4row1.BallList = ballList10;
            ticket4row2.BallList = ballList11;
            ticket4row3.BallList = ballList12;
            ticket5row1.BallList = ballList13;
            ticket5row2.BallList = ballList14;
            ticket5row3.BallList = ballList15;
            ticket6row1.BallList = ballList16;
            ticket6row2.BallList = ballList17;
            ticket6row3.BallList = ballList18;

















            //set Ticket Fields

            Ticket ticket1 = new Ticket();
            Ticket ticket2 = new Ticket();
            Ticket ticket3 = new Ticket();
            Ticket ticket4 = new Ticket();
            Ticket ticket5 = new Ticket();
            Ticket ticket6 = new Ticket();


            ticket1.ID = "1";
            ticket2.ID = "2";
            ticket3.ID = "3";
            ticket4.ID = "4";
            ticket5.ID = "5";
            ticket6.ID = "6";

            List<Row> ticket1rows = new List<Row>();
            List<Row> ticket2rows = new List<Row>();
            List<Row> ticket3rows = new List<Row>();
            List<Row> ticket4rows = new List<Row>();
            List<Row> ticket5rows = new List<Row>();
            List<Row> ticket6rows = new List<Row>();


            ticket1rows.Add(ticket1row1);
            ticket1rows.Add(ticket1row2);
            ticket1rows.Add(ticket1row3);

            ticket2rows.Add(ticket2row1);
            ticket2rows.Add(ticket2row2);
            ticket2rows.Add(ticket2row3);

            ticket3rows.Add(ticket3row1);
            ticket3rows.Add(ticket3row2);
            ticket3rows.Add(ticket3row3);

            ticket4rows.Add(ticket4row1);
            ticket4rows.Add(ticket4row2);
            ticket4rows.Add(ticket4row3);

            ticket5rows.Add(ticket5row1);
            ticket5rows.Add(ticket5row2);
            ticket5rows.Add(ticket5row3);

            ticket6rows.Add(ticket6row1);
            ticket6rows.Add(ticket6row2);
            ticket6rows.Add(ticket6row3);


            ticket1.rows = ticket1rows;
            ticket2.rows = ticket2rows;
            ticket3.rows = ticket3rows;
            ticket4.rows = ticket4rows;
            ticket5.rows = ticket5rows;
            ticket6.rows = ticket6rows;




            //Set strip fields
            Strip strip = new Strip();
            strip.ID = 1;

            List<Ticket> ticketList = new List<Ticket>();
            ticketList.Add(ticket1);
            ticketList.Add(ticket2);
            ticketList.Add(ticket3);
            ticketList.Add(ticket4);
            ticketList.Add(ticket5);
            ticketList.Add(ticket6);

            strip.Tickets = ticketList;


            return strip;
            




        }
        

        public static void DisplayArray(int[,] array)
        {
            int linecount = 0;


            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    Console.Write(array[i, k] + "  ");
                }

                linecount++;

                if (linecount == 3 || linecount == 6 || linecount == 9 || linecount == 12 || linecount == 15)
                {
                    Console.WriteLine();
                }

                Console.WriteLine();
                

            }
        }

        public void SplitArrays(int[,] array)
        {

            
            for (int i = 0; i < array.GetLength(0); i++)
            {

                switch(i)
                {
                    case 0:
                        for (int k = 0; k < 9; k++)
                        {
                            row1Nums[k] = array[i, k];
                        }
                        break;
                    case 1:
                        for (int k = 0; k < 9; k++)
                        {
                            row2Nums[k] = array[i, k];
                        }
                        break;
                    case 2:
                        for (int k = 0; k < 9; k++)
                        {
                            row3Nums[k] = array[i, k];
                        }
                        break;
                    case 3:
                        for (int k = 0; k < 9; k++)
                        {
                            row4Nums[k] = array[i, k];
                        }
                        break;
                    case 4:
                        for (int k = 0; k < 9; k++)
                        {
                            row5Nums[k] = array[i, k];
                        }
                        break;
                    case 5:
                        for (int k = 0; k < 9; k++)
                        {
                            row6Nums[k] = array[i, k];
                        }
                        break;
                    case 6:
                        for (int k = 0; k < 9; k++)
                        {
                            row7Nums[k] = array[i, k];
                        }
                        break;
                    case 7:
                        for (int k = 0; k < 9; k++)
                        {
                            row8Nums[k] = array[i, k];
                        }
                        break;
                    case 8:
                        for (int k = 0; k < 9; k++)
                        {
                            row9Nums[k] = array[i, k];
                        }
                        break;
                    case 9:
                        for (int k = 0; k < 9; k++)
                        {
                            row10Nums[k] = array[i, k];
                        }
                        break;
                    case 10:
                        for (int k = 0; k < 9; k++)
                        {
                            row11Nums[k] = array[i, k];
                        }
                        break;
                    case 11:
                        for (int k = 0; k < 9; k++)
                        {
                            row12Nums[k] = array[i, k];
                        }
                        break;
                    case 12:
                        for (int k = 0; k < 9; k++)
                        {
                            row13Nums[k] = array[i, k];
                        }
                        break;
                    case 13:
                        for (int k = 0; k < 9; k++)
                        {
                            row14Nums[k] = array[i, k];
                        }
                        break;
                    case 14:
                        for (int k = 0; k < 9; k++)
                        {
                            row15Nums[k] = array[i, k];
                        }
                        break;
                    case 15:
                        for (int k = 0; k < 9; k++)
                        {
                            row16Nums[k] = array[i, k];
                        }
                        break;
                    case 16:
                        for (int k = 0; k < 9; k++)
                        {
                            row17Nums[k] = array[i, k];
                        }
                        break;
                    case 17:
                        for (int k = 0; k < 9; k++)
                        {
                            row18Nums[k] = array[i, k];
                        }
                        break;


                }
                

            }
            

        }

        public void PrintRowNumbers()
        {
            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row1Nums[i] + " ");
            }
            Console.WriteLine();


            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row2Nums[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row3Nums[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();



            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row4Nums[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row5Nums[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row6Nums[i] + " ");
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row7Nums[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row8Nums[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row9Nums[i] + " ");
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row10Nums[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row11Nums[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row12Nums[i] + " ");
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row13Nums[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row14Nums[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row15Nums[i] + " ");
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row16Nums[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row17Nums[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Console.Write(row18Nums[i] + " ");
            }

        }


        public void FillRowsWithBalls()
        {

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row1Nums[i];
                ballList1.Add(b);
                
            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row2Nums[i];
                ballList2.Add(b);

            }

            for (int i = 0; i < row3Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row3Nums[i];
                ballList3.Add(b);

            }

            for (int i = 0; i < row4Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row4Nums[i];
                ballList4.Add(b);

            }

            for (int i = 0; i < row5Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row5Nums[i];
                ballList5.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row6Nums[i];
                ballList6.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row7Nums[i];
                ballList7.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row8Nums[i];
                ballList8.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row9Nums[i];
                ballList9.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row10Nums[i];
                ballList10.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row11Nums[i];
                ballList11.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row12Nums[i];
                ballList12.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row13Nums[i];
                ballList13.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row14Nums[i];
                ballList14.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row15Nums[i];
                ballList15.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row16Nums[i];
                ballList16.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row17Nums[i];
                ballList17.Add(b);

            }

            for (int i = 0; i < row1Nums.Length; i++)
            {
                Ball b = new Ball();
                b.BallNum = row18Nums[i];
                ballList18.Add(b);
            }

            


        }




        public void PrintBallListNumbers()
        {
            
            foreach(Ball b in ballList1)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();

            foreach (Ball b in ballList2)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();


            foreach (Ball b in ballList3)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine();


            foreach (Ball b in ballList4)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();

            foreach (Ball b in ballList5)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();


            foreach (Ball b in ballList6)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine();

            foreach (Ball b in ballList7)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();

            foreach (Ball b in ballList8)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();


            foreach (Ball b in ballList9)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine();

            foreach (Ball b in ballList10)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();

            foreach (Ball b in ballList11)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();


            foreach (Ball b in ballList12)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine();


            foreach (Ball b in ballList13)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();

            foreach (Ball b in ballList14)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();


            foreach (Ball b in ballList15)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine();

            foreach (Ball b in ballList16)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();

            foreach (Ball b in ballList17)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();


            foreach (Ball b in ballList18)
            {
                Console.Write(b.BallNum + " ");
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine();

            

        }










    }
}
