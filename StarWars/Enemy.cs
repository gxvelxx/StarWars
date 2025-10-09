using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars
{
    internal class Enemy : Object
    {
        //적의 모양을 담을 스트링배열
        private string[] _enemyFrame;
        //적의 크기를 선언할 정수
        private const int _enemyFrameHeghit = 1;
        private const int _enemyFrameWidth = 4;        

        //적 이동에 필요한 시간
        private DateTime _lastMoveTime;

        //재생성을 위한 랜덤
        private static Random _rnd = new Random();

        //적을 만들 생성자
        public Enemy() : base(new Vector(_rnd.Next(0, Console.WindowWidth - 5), 0))
        {
            _enemyFrame = new string[1]
            {               
                "┣╸⬤┫"
            };
        }

        //충돌 크기 override
        public override int Height
        { get { return _enemyFrameHeghit; } }
        public override int Width
        {  get { return _enemyFrameWidth; } }

        //적의 모양을 출력하는 함수
        public void Create()
        {
            for (int i = 0; i < _enemyFrameHeghit; i++)
            {
                string line = _enemyFrame[i];
                for (int j = 0; j < _enemyFrameWidth; j++)
                {
                    char empty = ' ';
                    if (j < line.Length)
                    {
                        empty = line[j];
                    }
                    Console.SetCursorPosition(_vector.X + j,  _vector.Y + i);
                    Console.Write(empty);
                }
            }
        }

        //적 이동 함수
        public void MoveDown()
        {            
            if ((DateTime.Now - _lastMoveTime).TotalSeconds >= 0.1)
            {
                if (_vector.Y < Console.WindowHeight - 1)
                {
                    _vector.Y++;
                }
                else
                {
                    _vector.Y = 0;
                    _vector.X = _rnd.Next(0, Console.WindowWidth - 5);
                }
                _lastMoveTime = DateTime.Now;
            }
        }
    }
}
