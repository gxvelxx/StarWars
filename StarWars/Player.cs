using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    public enum MoveType
    {
        None, Left, Right, Up, Down
    }
    internal class Player : Object
    {
        private string[] _playerFrame;
        private MoveType _MoveType;

        private Weapon _weapon;
        public Weapon Weapon { get { return _weapon; } }

        //플레이어 크기
        private const int _playerFrameHeight = 4;
        private const int _playerFrameWidth = 6;

        //시작 위치
        private static readonly Vector _initialPosition = new Vector((Console.WindowWidth / 2) - 3, 26);

        public Player() : base(_initialPosition)
        {
            _playerFrame = new string[4]
            {
                "  ▌▐  ",
                " ▟▌▐▙ ",
                "██  ██ ",
                "▝.██.▘"
            };
            _MoveType = MoveType.None;
            _weapon = new Weapon();
        }
        
        public void Create()
        {            
            for (int i = 0; i < _playerFrameHeight; i++)
            {
                string line = _playerFrame[i];
                for (int j = 0; j < _playerFrameWidth; j++)
                {
                    char empty = ' '; // 빈 공간

                    if (j < line.Length)
                    {
                        empty = line[j];
                    }                                        
                    Console.SetCursorPosition(_vector.X + j, _vector.Y + i);
                    Console.Write(empty);
                }
            }
        }

        public void ReadKey()
        {
            ConsoleKeyInfo info = new ConsoleKeyInfo();

            while (Console.KeyAvailable)
            {
                info = Console.ReadKey(true);
            }

            switch (info.Key)
            {
                case ConsoleKey.A:
                    _MoveType = MoveType.Left;
                    break;
                case ConsoleKey.D:
                    _MoveType = MoveType.Right;
                    break;
                case ConsoleKey.W:
                    _MoveType = MoveType.Up;
                    break;
                case ConsoleKey.S:
                    _MoveType = MoveType.Down;
                    break;
                case ConsoleKey.Spacebar:
                    _weapon.Shoot(_vector);
                    break;
            }
        }

        public void Move()
        {
            int posX = _vector.X;
            int posY = _vector.Y;

            // 방향에 따라 위치 계산
            switch (_MoveType)
            {
                case MoveType.Left:
                    posX--;
                    break;
                case MoveType.Right:
                    posX++;
                    break;
                case MoveType.Up:
                    posY--;
                    break;
                case MoveType.Down:
                    posY++;
                    break;
            }

            // 콘솔 창 범위를 벗어나지 않도록 경계 체크
            if (posX < 0 || posX + _playerFrameWidth > Console.WindowWidth)
                return;
            if (posY < 0 || posY + _playerFrameHeight > Console.WindowHeight)
                return;

            // 범위 안이면 위치 이동
            _vector.X = posX;
            _vector.Y = posY;
        }
    }
}