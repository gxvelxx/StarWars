using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    internal class Boss : Object
    {
        private string[] _bossFrame;

        private int _bossFrameHeight = 18;
        private int _bossFrameWidth = 38;
        private DateTime _lastMoveTime;

        //충돌크기 override
        public override int Height
        { get { return _bossFrameHeight; } }
        public override int Width
        {  get { return _bossFrameWidth; } }

        //랜덤 이동
        private int _directionX = 1; 
        private int _directionY = 1;
        private Random _rnd = new Random();

        //보스 HP
        private bool _isAlive = true;
        private int _hp = 30;
        public bool IsAlive
        { get { return _isAlive; } }

        public Boss() : base(new Vector((Console.WindowWidth / 2) - 19, 2))
        {
            _bossFrame = new string[18]
            {
                "          .:----====+++++:          ",
                "       .::-------===++++****-       ",
                "     .::::------====+++*******=     ",
                "   ..:::::::----====+++*********.   ",
                "  .:.-=----::---===+++***********:  ",
                " .::==--=-:=:---===+++**#*********. ",
                " .:-=-+--::----===+++**###*#*#****+ ",
                " ::==-=-:::*---===++**############* ",
                ".:::---:::+---===++***#############.",
                ".::::-:+=---=====++**############## ",
                " :-:::---=-==++++**###############+ ",
                " .-------===++++**########%##%#%##. ",
                "  :----====++++**##%%%%%%%%%%%%%%:  ",
                "   :=====+++++*##%%%%%%%%%%%%%%%:   ",
                "    .=++++++**##%%%%%%%%%%%%%%+.    ",
                "      .=++**##%%%%%%%%%%%%%%+       ",
                "         .+#%%%%%%%%%%%%%=.         ",
                "             ..:---::.              "
            };
        }

        //데미지 처리
        public void TakeDamage (int damage)
        {
            if (!_isAlive)
            {
                return;
            }

            _hp -= damage;
            if (_hp <= 0)
            {
                _hp = 0;
                _isAlive = false;
            }
        }

        public void Create()
        {
            if (!_isAlive)
            {
                return;
            }
            for (int i = 0; i < _bossFrameHeight; i++)
            {
                string line = _bossFrame[i];
                for (int j = 0; j < line.Length; j++)
                {
                    char empty = line[j];

                    int drawX = _vector.X + j;
                    int drawY = _vector.Y + i;

                    // 콘솔 범위 보호
                    if (drawX < 0 || drawY < 0 ||
                        drawX >= Console.WindowWidth ||
                        drawY >= Console.WindowHeight)
                        continue;

                    Console.SetCursorPosition(drawX, drawY);
                    Console.Write(empty);
                }
            }
        }

        public void Move()
        {
            if ((DateTime.Now - _lastMoveTime).TotalSeconds >= 0.2)
            {
                if (_rnd.NextDouble() < 0.1)
                {
                    _directionX *= -1;
                }
                if (_rnd.NextDouble() < 0.1)
                {
                    _directionY *= -1;
                }

                int moveX = _rnd.Next(1, 4);
                int moveY = _rnd.Next(0, 3);
                _vector.X += _directionX * moveX;
                _vector.Y += _directionY * moveY;

                if (_vector.X <= 0)
                {
                    _directionX = 1;
                }
                else if (_vector.X + _bossFrameWidth >= Console.WindowWidth)
                {
                    _directionX = -1;
                }

                if (_vector.Y <= 0)
                {
                    _directionY = 1;
                }
                else if (_vector.Y + _bossFrameHeight >= 22)
                {
                    _directionY = -1;
                }

                _lastMoveTime = DateTime.Now;
            }
        }
    }
}
