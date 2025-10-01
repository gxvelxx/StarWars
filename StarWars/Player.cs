using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    internal class Player
    {
        private string[] _playerFrame;
        private Vector _position; // 좌표로 관리하려고 변경

        //플레이어 크기
        private const int _playerFrameHeight = 4;
        private const int _playerFrameWidth = 6;

        //초기 위치
        private static readonly Vector _initialPosition = new Vector(10, 10);

        public Player()
        {
            _playerFrame = new string[4]
            {
                "  ▌▐  ",
                " ▟▌▐▙ ",
                "██  ██ ",
                "▝.██.▘"
            };

            _position = _initialPosition;
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

                    Console.SetCursorPosition(_position.X + j, _position.Y + i);
                    Console.Write(empty);
                }
            }
        }
    }
}
