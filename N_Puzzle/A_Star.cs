using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


struct Puzzle
{
    public List<int> matrix;
    public int NPuzzle;
}
namespace N_Puzzle
{
    internal class A_Star
    {
        List<int> Initial_state;
        static int size;
        int depth = 0;
        HashSet<string> exist;
        PriorityQueue<State, int> priorty;
        public A_Star(List<int> Initial_state, int size)
        {
            this.Initial_state = Initial_state;
            A_Star.size = size;
            exist = new HashSet<string>();
            priorty = new PriorityQueue<State, int>();

        }
        public void start_solver(List<int> Initial_state, int N, Char name)
        {
            Solvability solvability = new Solvability();
            bool flag = true;
            flag = solvability.Resolvable(Initial_state, N);
            if (flag == true)
            {
                Console.WriteLine(" This Puzzle is solvable");
                DateTime dt = DateTime.Now;
                int[] temp = FindBlank(Initial_state);
                int y = temp[0];
                int x = temp[1];
                int temp_cost;
                if (name == 'h')
                {
                    temp_cost = Calc_Hamming(Initial_state);
                }
                else
                {
                    temp_cost = Calc_Manhatin(Initial_state);
                }
                State node = new State(Initial_state, temp_cost, 0, null, x, y);
                exist.Add(hash_fun(Initial_state));
                priorty.Enqueue(node, temp_cost);
                while (true) // while --> o(E)* body --> S
                {
                    node = priorty.Dequeue();
                    depth = node.level;
                    if (node.cost - node.level == 0)
                    {
                        break;
                    }
                    depth++;
                    find_childs(name, node);
                }
                DateTime dt2 = DateTime.Now;
                TimeSpan result = dt2 - dt;
                Console.WriteLine("time to run this test in seconds:  " + result.Seconds.ToString());
                Console.WriteLine("time to run this test in Milliseconds:  " + result.Milliseconds.ToString());
                Console.WriteLine("number of steps " + "with " + name + " = " + depth + "\n" +
                    "-------------------------------------------------------------------- \n");
                if(size == 3)
                {
                   this.get_path(node);
                }
            }
            else
            {
                Console.WriteLine("The Puzzle is unsolvable \n " +
                    "----------------------------------------");
            }

        }
        public void find_childs(Char name, State node)
        {
            int x = node.x_zero;
            int y = node.y_zero;
            //Moves           
            if(x + 1 < size)
            {
                swap(node.matrix, y, x + 1, x, y);
                if (exist.Contains(hash_fun(node.matrix)) == false)
                {
                    Add_child(node, name, x + 1, y);
                }
                swap(node.matrix, y, x, x + 1, y);
            }
            if(y - 1 >= 0)
            {
                swap(node.matrix, y - 1, x, x, y);
                if (exist.Contains(hash_fun(node.matrix)) == false)
                {
                    Add_child(node, name, x, y - 1);
                }
                swap(node.matrix, y, x, x, y - 1);
            }
            if(x - 1 >= 0)
            {
                swap(node.matrix, y, x - 1, x, y);
                if (exist.Contains(hash_fun(node.matrix)) == false)
                {
                    Add_child(node, name, x - 1, y);
                }
                swap(node.matrix, y, x, x - 1, y);
            }
            if(y + 1 < size)
            {
                swap(node.matrix, y + 1, x, x, y);
                if (exist.Contains(hash_fun(node.matrix)) == false)
                {
                    Add_child(node, name, x, y + 1);
                }
                swap(node.matrix, y, x, x, y + 1);
            }
            
        }

        public int Calc_Hamming(List<int> state)
        {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int actual = state[i * size + j];
                    int expected = (i * size) + j + 1;
                    if (actual == 0 || actual == expected)
                    {
                        continue;
                    }

                    else
                    {
                        count++;
                    }

                }
            }
            return count + depth;
        }
        public int update_hamming(State node, int new_x_zero, int new_y_zero)
        {
            int temp = node.cost;
            if(node.matrix[ node.y_zero*size + node.x_zero ]== node.y_zero*size+node.x_zero+1)
            {
                temp--;
            }
            else if(node.matrix[node.y_zero * size + node.x_zero] ==new_y_zero*size+new_x_zero+1 )
            {
                temp++; 
            }
            return temp + 1;
        }
        public int Calc_Manhatin(List<int> state)
        {
            int sum = 0;
            for (int i = 0; i < state.Count; i++)
            {
                int actual = state[i];
                int expected = i + 1;
                if (actual == 0 || actual == expected)
                {
                    continue;
                }
                else
                {
                    int X_orig = state[i] % size;
                    int Y_orig;
                    if (X_orig == 0)
                    {
                        X_orig = size;
                        Y_orig = (state[i] / size);
                    }
                    else
                    {
                        Y_orig = (state[i] / size) + 1;
                    }
                    int current_X = (i + 1) % size;
                    if (current_X == 0)
                    {
                        current_X = size;
                    }
                    int current_Y = (i / size) + 1;
                    int temperary = Math.Abs(X_orig - current_X) + Math.Abs(Y_orig - current_Y);
                    sum += temperary;
                }
            }
            return sum + depth;
        }
        public int updaate_manh(State node, int new_x_zero, int new_y_zero)
        {
            int temp_cost = node.cost;
            int acutal = node.matrix[node.y_zero*size+node.x_zero];
            int X_orig = acutal % size;
            int Y_orig;
            if (X_orig == 0)
            {
                X_orig = size;
                Y_orig = (acutal / size);
            }
            else
            {
                Y_orig = (acutal / size) + 1;
            }
            X_orig--;
            Y_orig--;
            int old_cost = Math.Abs(X_orig - new_x_zero) + Math.Abs(Y_orig - new_y_zero);
            int new_cost = Math.Abs(X_orig - node.x_zero) + Math.Abs(Y_orig - node.y_zero);
            temp_cost -= old_cost;
            temp_cost += new_cost;
            return temp_cost +1;
        }
        public int[] FindBlank(List<int> state)
        {
            int[] temp = new int[2];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    int actual = state[y * size + x];
                    if (actual == 0)
                    {
                        temp[0] = y;
                        temp[1] = x;
                    }
                }
            }
            return temp;
        }
        //this fun takes (y,x,x,y)
        public List<int> swap(List<int> state, int i, int j, int x_zero, int y_zero)
        {
            int temperary = state[y_zero * size + x_zero];
            state[y_zero * size + x_zero] = state[i * size + j];
            state[i * size + j] = temperary;
            return state;
        }
        public void show(List<int> state)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(state[i * size + j] + " ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("*****************************");
        }
        public void get_path(State node)
        {
            List<List<int>> path = new List<List<int>>();
            while (node.Parent != null)
            {
                path.Add(node.matrix);
                node = node.Parent;
            }
            path.Add(node.matrix);
            for (int i = path.Count - 1; i >= 0; i--)
            {
                this.show(path[i]);
            }
        }
      
        public int mh(Char name, State node , int new_x_zero, int new_y_zero)
        {
            if (name == 'h')
            {
                return update_hamming(node, new_x_zero, new_y_zero);
            }
            else
            {
                return updaate_manh(node, new_x_zero, new_y_zero);
            }
        }
        ///// function to calc coast
        public void Add_child(State node, Char name, int new_x_zero, int new_y_zero)
        {
            List<int> temp_list = new List<int>(node.matrix);
            int cost = mh(name, node, new_x_zero, new_y_zero);
            exist.Add(hash_fun(temp_list));
            State temp_state = new State(temp_list, cost, depth, node, new_x_zero, new_y_zero);
            priorty.Enqueue(temp_state, temp_state.cost);

        }

        public string hash_fun(List<int> list)
        {
            string result = " ";

            for (int i = 0; i < list.Count; i++)
            {

                result += (list[i].ToString());

            }
            return result;
        }

    }
}
