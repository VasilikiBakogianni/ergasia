using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apallaktikh_ergasia
{
    [Serializable]
    class Player
    {
        public int time;
        public int tries;
        public string name;

        public Player(int tIme, int mistakes, string username)
        {
            time = tIme;
            tries = mistakes;
            name = username;
        }
        public Player getTime(int Time)
        {
            this.time = Time;
            return this;
        }

        public Player getTries(int Tries)
        {
            this.tries = Tries;
            return this;
        }

        public Player getName(string Name)
        {
            this.name = Name;
            return this;
        }
    }
}
