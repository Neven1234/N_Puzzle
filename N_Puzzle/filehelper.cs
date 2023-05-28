using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{

    internal class filehelper
    {
        Puzzle ReadTest(string filename)//space include
        {
            Solvability solvability = new Solvability();
            FileStream file;
            int N;
            StreamReader sr;
            string line;
            file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(file);
            string[] temp;
            line = sr.ReadLine();
            N = int.Parse(line);
            line = sr.ReadLine();
            Puzzle state;
            List<int> puzzle = new List<int>();
            for (int i = 0; i < N; i++)
            {
                line = sr.ReadLine();
                temp = line.Split(' ');
                for (int j = 0; j < N; j++)
                {
                    puzzle.Add(int.Parse(temp[j]));
                }
            }
            sr.Close();
            file.Close();
            state.NPuzzle = N;
            state.matrix = puzzle;
            return state;
        }
        /// ///
        Puzzle ReadTest2(string filename)//space include
        {
            Solvability solvability = new Solvability();
            FileStream file;
            int N;
            StreamReader sr;
            string line;
            file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(file);
            string[] temp;
            line = sr.ReadLine();
            N = int.Parse(line);
            Puzzle state;
            List<int> puzzle = new List<int>();
            for (int i = 0; i < N; i++)
            {
                line = sr.ReadLine();
                temp = line.Split(' ');
                for (int j = 0; j < N; j++)
                {
                    puzzle.Add(int.Parse(temp[j]));
                }
            }
            sr.Close();
            file.Close();
            state.NPuzzle = N;
            state.matrix = puzzle;
            return state;
        }
        void solvePuzzle(Puzzle puzzle, char theWay)
        {

            List<int> test = puzzle.matrix;
            int N = puzzle.NPuzzle;
            A_Star a_star = new A_Star(test, N);
            a_star.start_solver(test, N, theWay);
        }
        public void read()
        {
            Char cont = 'y';
            while (cont == 'y')
            {
                Console.WriteLine("[1] Sample test cases\n[2] Manhatten only test\n" +
                    "[3] Hamming & Manhatten test\n[4] V-Large test\n");
                Console.Write("\nEnter your choice [1-2-3-4]: ");
                char choice = Console.ReadLine()[0];
                switch (choice)
                {
                    case '1':
                        #region SAMPLE CASES
                        Puzzle p1 = ReadTest("Sample Test\\Solvable Puzzles\\8 Puzzle (1).txt");
                        Console.WriteLine("test file name: 8 Puzzle (1).");
                        solvePuzzle(p1, 'm');
                        // test2
                        Puzzle p2 = ReadTest("Sample Test\\Solvable Puzzles\\8 Puzzle (2).txt");
                        Console.WriteLine("test file name: 8 Puzzle (2).");
                        solvePuzzle(p2, 'm');
                        //// test3
                        Puzzle p3 = ReadTest("Sample Test\\Solvable Puzzles\\8 Puzzle (3).txt");
                        Console.WriteLine("test file name: 8 Puzzle (3).");
                        solvePuzzle(p3, 'm');
                        //////// test4
                        Puzzle p4 = ReadTest("Sample Test\\Solvable Puzzles\\15 Puzzle - 1.txt");
                        Console.WriteLine("test file name: 15 Puzzle - 1.");
                        solvePuzzle(p4, 'm');
                        //////// test5
                        Puzzle p5 = ReadTest("Sample Test\\Solvable Puzzles\\24 Puzzle 1.txt");
                        Console.WriteLine("test file name: 24 Puzzle 1.");
                        solvePuzzle(p5, 'm');
                        //////// test6
                        Puzzle p6 = ReadTest("Sample Test\\Solvable Puzzles\\24 Puzzle 2.txt");
                        Console.WriteLine("test file name: 24 Puzzle 2.");
                        solvePuzzle(p6, 'm');
                        /////// unsolvable
                        ////// test1
                        Puzzle pp1 = ReadTest("Sample Test\\Unsolvable Puzzles\\8 Puzzle - Case 1.txt");
                        Console.WriteLine("test file name: 8 Puzzle - Case 1.");
                        solvePuzzle(pp1, 'm');
                        //// test2
                        Puzzle pp2 = ReadTest("Sample Test\\Unsolvable Puzzles\\8 Puzzle(2) - Case 1.txt");
                        Console.WriteLine("test file name: 8 Puzzle(2) - Case 1.");
                        solvePuzzle(pp2, 'm');
                        //// test3
                        Puzzle pp3 = ReadTest("Sample Test\\Unsolvable Puzzles\\8 Puzzle(3) - Case 1.txt");
                        Console.WriteLine("test file name: 8 Puzzle(3) - Case 1.");
                        solvePuzzle(pp3, 'm');
                        //// test4
                        Puzzle pp4 = ReadTest("Sample Test\\Unsolvable Puzzles\\15 Puzzle - Case 2.txt");
                        Console.WriteLine("test file name: 15 Puzzle - Case 2.");
                        solvePuzzle(pp4, 'm');
                        //// test5
                        Puzzle pp5 = ReadTest("Sample Test\\Unsolvable Puzzles\\15 Puzzle - Case 3.txt");
                        Console.WriteLine("test file name: 15 Puzzle - Case 3.");
                        solvePuzzle(pp5, 'm');
                        break;
                    #endregion
                    case '3':
                        #region Manhattan & Hamming
                        Console.WriteLine("[1] Hamming test \n[2] Manhatten test\n");
                        Console.Write("\nEnter your choice [1-2]: ");
                        char Choice = Console.ReadLine()[0];
                        // test1
                        switch (Choice)
                        {
                            case '1':
                                //(hamming)
                                Puzzle ppp1 = ReadTest2("Complete Test\\Solvable puzzles\\Manhattan & Hamming\\50 Puzzle.txt");
                                Console.WriteLine("test file name: 50 Puzzle.");
                                solvePuzzle(ppp1, 'h');
                                Puzzle ppp3 = ReadTest("Complete Test\\Solvable puzzles\\Manhattan & Hamming\\99 Puzzle - 1.txt");
                                Console.WriteLine("test file name: 99 Puzzle - 1.");
                                solvePuzzle(ppp3, 'h');
                                Puzzle ppp5 = ReadTest("Complete Test\\Solvable puzzles\\Manhattan & Hamming\\99 Puzzle - 2.txt");
                                Console.WriteLine("test file name: 99 Puzzle - 2.");
                                solvePuzzle(ppp5, 'h');
                                Puzzle ppp7 = ReadTest2("Complete Test\\Solvable puzzles\\Manhattan & Hamming\\9999 Puzzle.txt");
                                Console.WriteLine("test file name: 9999 Puzzle.");
                                solvePuzzle(ppp7, 'h');
                                break;
                             case '2':
                                //(manhattan)
                                Puzzle ppp2 = ReadTest2("Complete Test\\Solvable puzzles\\Manhattan & Hamming\\50 Puzzle.txt");
                                Console.WriteLine("test file name: 50 Puzzle.");
                                solvePuzzle(ppp2, 'm');
                                // (manhattan)
                                Puzzle ppp4 = ReadTest("Complete Test\\Solvable puzzles\\Manhattan & Hamming\\99 Puzzle - 1.txt");
                                Console.WriteLine("test file name: 99 Puzzle - 1.");
                                solvePuzzle(ppp4, 'm');
                                ////(manhattan)
                                Puzzle ppp6 = ReadTest("Complete Test\\Solvable puzzles\\Manhattan & Hamming\\99 Puzzle - 2.txt");
                                Console.WriteLine("test file name: 99 Puzzle - 2.");
                                solvePuzzle(ppp6, 'm');
                                ////(manhattan)
                                Puzzle ppp8 = ReadTest2("Complete Test\\Solvable puzzles\\Manhattan & Hamming\\9999 Puzzle.txt");
                                Console.WriteLine("test file name: 9999 Puzzle.");
                                solvePuzzle(ppp8, 'm');
                                break;
                        }
                        break;
                    #endregion
                    case '2':
                        #region Manhattan only
                        // /////Manhattan Only
                        // //////test1
                        Puzzle pppp1 = ReadTest("Complete Test\\Solvable puzzles\\Manhattan Only\\15 Puzzle 1.txt");
                        Console.WriteLine("test file name: 15 Puzzle 1.");
                        solvePuzzle(pppp1, 'm');
                        //////test2
                        Puzzle pppp2 = ReadTest("Complete Test\\Solvable puzzles\\Manhattan Only\\15 Puzzle 3.txt");
                        Console.WriteLine("test file name: 15 Puzzle 3.");
                        solvePuzzle(pppp2, 'm');
                        ////////test3
                        Puzzle pppp5 = ReadTest("Complete Test\\Solvable puzzles\\Manhattan Only\\15 Puzzle 4.txt");
                        Console.WriteLine("test file name: 15 Puzzle 4.");
                        solvePuzzle(pppp5, 'm');
                        //test1
                        Puzzle pppp3 = ReadTest("Complete Test\\Solvable puzzles\\Manhattan Only\\15 Puzzle 5.txt");
                        Console.WriteLine("test file name: 15 Puzzle 5.");
                        solvePuzzle(pppp3, 'm');
                        /////unsolvable
                        //////test1
                        Puzzle unsolv1 = ReadTest("Complete Test\\Unsolvable puzzles\\15 Puzzle 1 - Unsolvable.txt");
                        Console.WriteLine("test file name: 15 Puzzle 1 - Unsolvable.");
                        solvePuzzle(unsolv1, 'm');
                        //////test2
                        Puzzle unsolv2 = ReadTest("Complete Test\\Unsolvable puzzles\\99 Puzzle - Unsolvable Case 1.txt");
                        Console.WriteLine("test file name: 99 Puzzle - Unsolvable Case 1.");
                        solvePuzzle(unsolv2, 'm');
                        //////test3
                        Puzzle unsolv3 = ReadTest("Complete Test\\Unsolvable puzzles\\99 Puzzle - Unsolvable Case 2.txt");
                        Console.WriteLine("test file name: 99 Puzzle - Unsolvable Case 2.");
                        solvePuzzle(unsolv3, 'm');
                        //////test4
                        Puzzle unsolv4 = ReadTest("Complete Test\\Unsolvable puzzles\\9999 Puzzle.txt");
                        Console.WriteLine("test file name: 9999 Puzzle.");
                        solvePuzzle(unsolv4, 'm');
                        break;
                    #endregion
                    case '4':
                        #region V-Large
                        /// very large
                        Puzzle veryLarge = ReadTest("Complete Test\\V. Large test case\\TEST.txt");
                        Console.WriteLine("test file name: TEST.");
                        solvePuzzle(veryLarge, 'm');
                        break;
                    #endregion

                }
                Console.WriteLine("****************************************************\n" +
                    "\n Do you want to continue (y-n)");
                cont = Console.ReadLine()[0];
                Console.WriteLine("\n\n");
            }
        }

    }

    
}

