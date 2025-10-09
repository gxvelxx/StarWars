using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    internal class Bullet : Object
    {
        //총알 모양 및 속도
        private const string _bulletFrame = "⇑";
        private const int _bulletSpeed = 1;
        private bool _isActive;

        //Weapon 사용
        public bool isActive
        {
            get { return _isActive; }
        }

        //플레이어 총
        public Bullet(Vector startPosition) 
            : base(new Vector(startPosition.X + 3, startPosition.Y - 1))
        {
            _isActive = true;
        }

        public void Move()
        {
            if (!_isActive)
            {
                return;
            }
            _vector.Y -= _bulletSpeed;

            if (_vector.Y < 0)
            {
                _isActive = false;
            }
        }

        public void Create()
        {
            if (!_isActive)
            {
                return;
            }
            if (_vector.X < 0 ||  _vector.Y < 0 ||
                _vector.X >= Console.WindowWidth ||
                _vector.Y >= Console.WindowHeight)
            {
                return;
            }
            Console.SetCursorPosition(_vector.X, _vector.Y);
            Console.Write(_bulletFrame);
        }
    }
}
