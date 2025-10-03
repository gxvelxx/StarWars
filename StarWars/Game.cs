using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars
{    
    internal class Game
    {
        private bool _gameover;

        //플레이어
        private Player _player;

        public bool gameover
        {
            get { return _gameover; }
            set { _gameover = value; }
        }

        public Player player
        {
            get { return _player; }
            set { _player = value; }
        }

        public Game()
        {
            gameover = false;
            player = new Player();
        }

        //게임 시작
        public void Start()
        {
            Console.CursorVisible = false;
            player.Create();

            while (!gameover)
            {               
                player.ReadKey();
                player.Move();
                
                Console.Clear(); // 리랜더링 보이는게 거슬림

                player.Create();
                Thread.Sleep(20);
            }
        }
    }
}
