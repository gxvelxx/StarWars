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
        private int _x;
        private int _y;

        //플레이어 크기
        private const int _playerFrameHeight = 4;
        private const int _playerFrameWidth = 6;

        //플레이어 위치
        private const int _posX = 0;
        private const int _posY = 1;

        public Player()
        {
            _playerFrame = new string[4]
            {
                "  ▌▐  ",
                " ▟▌▐▙ ",
                "██  ██ ",
                "▝.██.▘"
            };
            _x = _posX;
            _y = _posY;
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

                    Console.SetCursorPosition(_x + j, _y + i);
                    Console.Write(empty);
                }
            }
        }
    }
}
