using System;

namespace Learn
{
    class Program
    {
        static void Main(string[] args)
        {

            string dimeonionsString = Console.ReadLine();
            string[] dimeonsions = dimeonionsString.Split(' ');
            int rowsInput = Convert.ToInt32(dimeonsions[0]);
            int colsInput = Convert.ToInt32(dimeonsions[1]);
            int[,] inputArr = new int[rowsInput, colsInput];
            int[,] outputArr1 = new int[rowsInput, colsInput];
            int[,] outputArr2 = new int[(rowsInput * 2) + 1, (colsInput * 2) + 1];
            string[,] outputArr2Asteriks = new string[(rowsInput * 2) + 1, (colsInput * 2) + 1];
            int brickNumber = 0;
            string errorMessage = "-1";
            int brickSpliter = -2;

            //Check if M and N are even numbers not exceeding 100.
            if (dimeonsions.Length > 2 || dimeonsions.Length < 2 || rowsInput >= 100 || colsInput >= 100 || (rowsInput * colsInput) % 2 != 0)
            {               
                Console.WriteLine("Incorrect coordinates!");
                return;
            }
            //If there is only 2 bricks on layer 1, there gonna be 2 bricks on layer 2
            if (rowsInput == 2 && colsInput == 2)
            {
                Console.WriteLine("Can't build strong brickwork, two bricks are laying on other two!");
                return;
            }
            //Populate int[,] inputArr with user input & int[,] outputArr1 with 0
            for (int i = 0; i < rowsInput; i++)
            {

                string nCordLine = Console.ReadLine();
                string[] nwords = nCordLine.Split(' ');
        
                //Check if the input values AREN'T greater than the coordinates
                if (nwords.Length <= colsInput)
                {
                    for (var j = 0; j < colsInput; j++)
                    {

                        inputArr[i, j] = int.Parse(nwords[j]);
                        outputArr1[i, j] = 0;

                    }
                }
                //Check if the input values ARE greater than the coordinates
                else if (nwords.Length > colsInput)
                {

                    Console.WriteLine("The input lenght is greater than your coordinates!");
                    return;

                }
            }

            //Check if one brick is spanning 3 rows
            for (int x = 0; x < rowsInput; x++)
            {
                for (int y = 0; y < colsInput - 2; y++)
                {
                    if (inputArr[x, y] == inputArr[x, y + 1] && inputArr[x, y + 1] == inputArr[x, y + 2])
                    {

                        Console.WriteLine("There is brick spanning 3 rows!");
                        return;

                    }
                }
            }

            //Check if one brick is spanning 3 columns
            for (int x = 0; x < rowsInput - 2; x++)
            {
                for (int y = 0; y < colsInput; y++)
                {
                    if (inputArr[x, y] == inputArr[x + 1, y] && inputArr[x + 1, y] == inputArr[x + 2, y])
                    {

                        Console.WriteLine("There is brick spanning 3 columns!");
                        return;

                    }
                }
            }

            //populate int[,] outputArr1 & int[,] outputArr1 with the new values
            for (int i = 0; i < rowsInput; i++) 
            {
                for (int j = 0; j < colsInput; j++)
                {
                    //check if the pointer is on the last colum and if so then add vertical brick
                    if (outputArr1[i, j] == 0 && j == colsInput - 1)
                    {

                        brickNumber++;
                        outputArr1[i, j] = outputArr2[(i * 2) + 1, (j * 2) + 1] = brickNumber;
                        outputArr1[i + 1, j] = outputArr2[(i * 2) + 3, (j * 2) + 1] = brickNumber;
                        outputArr2[(i * 2) + 2, (j * 2) + 1] = brickSpliter;

                        //Check if brick from layer 2 is laying on brick from layer 1
                        if (inputArr[i, j] - inputArr[i + 1, j] == 0)
                        {
                            Console.WriteLine(errorMessage + " No solution exists!!!");
                            return;
                        }
                    }
                    //Check if spot on Layer 2 (outputArr1[,]) is ocupate
                    else if (outputArr1[i, j] == 0 && j < colsInput - 1)                                 
                    {
                        brickNumber++;

                        //Check if brick is placed horizontaly on Layer 1
                        if (inputArr[i, j] - inputArr[i, j + 1] == 0)
                        {
                            //Place brick verticaly on layer 2
                            outputArr1[i, j] = outputArr2[(i * 2) + 1, (j * 2) + 1] = brickNumber;
                            outputArr1[i + 1, j] = outputArr2[(i * 2) + 3, (j * 2) + 1] = brickNumber;
                            outputArr2[(i * 2) + 2, (j * 2) + 1] = brickSpliter;

                        }
                        else
                        {
                            //Place brick horizontaly on layer 2
                            outputArr1[i, j] = outputArr2[(i * 2) + 1, (j * 2) + 1] = brickNumber;
                            outputArr1[i, j + 1] = outputArr2[(i * 2) + 1, (j * 2) + 3] = brickNumber;
                            outputArr2[(i * 2) + 1, (j * 2) + 2] = brickSpliter;

                        }
                    }
                }
                Console.WriteLine();
            }

            //Convert int[,] outputArr2 to string[,] outputArr2Asteriks
            for (int i = 0; i < (rowsInput * 2) + 1; i++)                                          
            {
                for (int j = 0; j < (colsInput * 2) + 1; j++)
                {
                    if (outputArr2[i, j] == 0)
                    {
                        outputArr2Asteriks[i, j] = "*";
                    }
                    else if (outputArr2[i, j] == brickSpliter)
                    {
                        outputArr2Asteriks[i, j] = " ";
                    }
                    else
                    {
                        outputArr2Asteriks[i, j] = string.Format("{0}", outputArr2[i, j]);
                    }

                }
            }

            //Visualisation of Layer 2 (int[,] outputArr)
            for (int i = 0; i < rowsInput; i++)                                                    
            {
                for (int j = 0; j < colsInput; j++)
                {
                    Console.Write(string.Format("{0} ", outputArr1[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);

            //Visualisation of Layer 2 (int[,] outputArr), surround each brick with "*"
            for (int i = 0; i < (rowsInput * 2) + 1; i++)
            {
                for (int j = 0; j < (colsInput * 2) + 1; j++)
                {
                    Console.Write(string.Format("{0} ", outputArr2Asteriks[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}