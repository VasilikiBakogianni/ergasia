using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apallaktikh_ergasia
{
    [Serializable]
    class Card
    {
        public string image { get; set; }
        
        public Card addImage(string Image)
        {
            this.image = Image;
            return this;
        }
    }
}
