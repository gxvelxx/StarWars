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

        //충돌감지를 위해
        public int PositionX
        { get { return _vector.X; } }
        public int PositionY
        { get { return _vector.Y; } }

        //충돌감지용 높이와 너비
        public virtual int Height
        { get { return 1; } }
        public virtual int Width
        { get { return 1; } }
    }    
}
