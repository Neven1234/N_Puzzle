using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    internal class State
    {
        public List<int> matrix;
        public int cost;
        public int level;
        public State Parent;
        public int x_zero, y_zero;
        
        public State(List<int> matrix, int cost, int level, State Parent, int x_zero, int y_zero)
        {
            this.matrix = matrix;   
            this.cost = cost;
            this.level = level;
            this.Parent = Parent;
            this.x_zero = x_zero;
            this.y_zero = y_zero;
        }

        
    }
     
}
