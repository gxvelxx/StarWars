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
        private bool gameover;

        //플레이어
        private Player player;

        //적
        private Enemies enemies;                 

        public Game()
        {
            gameover = false;
            player = new Player();
            enemies = new Enemies(16, 0.5);
        }

        //게임 시작
        public void Start()
        {
            Console.CursorVisible = false;

            while (!gameover)
            {               
                player.ReadKey();
                player.Move();

                enemies.UpdateSpawn();
                enemies.MoveAll();

                Console.Clear(); // 리랜더링 보이는게 거슬림
                player.Create();
                enemies.CreateAll();

                Thread.Sleep(30);
            }
        }
    }
}
