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

        //적
        private Enemy _enemy;

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
        public Enemy enemy
        {
            get { return _enemy; }
            set { _enemy = value; }
        }

        public Game()
        {
            gameover = false;
            player = new Player();
            enemy = new Enemy();
        }

        //게임 시작
        public void Start()
        {
            Console.CursorVisible = false;
            player.Create();
            enemy.Create();

            while (!gameover)
            {               
                player.ReadKey();
                player.Move();

                //여러 마리의 적들이 시간차를 두고 출몰해야함
                //리스트에 담아야할까
                //적의 최대수를 정해놓고
                //if문으로 돌려서 시간차로 생성하면 될듯
                enemy.MoveDown();
                
                Console.Clear(); // 리랜더링 보이는게 거슬림

                player.Create();

                enemy.Create();

                Thread.Sleep(30);
            }
        }
    }
}
