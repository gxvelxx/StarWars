using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    //총알, 플레이어, 에너미, 보스 등 써야함
    internal class Object
    {
        protected Vector _vector;

        public Object(Vector vector)
        {
            _vector = vector;
        }
    }
}
