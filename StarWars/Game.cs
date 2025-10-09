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
        //private Enemy _enemy;
        //여러 마리의 적들이 시간차를 두고 출몰해야함
        //리스트에 담아야할까
        private List<Enemy> enemies = new List<Enemy>();

        //직전 적 생성 시간
        private DateTime lastEnemySpawnTime;
        //적의 최대수를 정해놓고
        private const int maxEnemies = 16;           

        public Game()
        {
            gameover = false;
            player = new Player();
            lastEnemySpawnTime = DateTime.Now;
        }

        //게임 시작
        public void Start()
        {
            Console.CursorVisible = false;                                 

            while (!gameover)
            {               
                player.ReadKey();
                player.Move();

                //if문으로 돌려서 시간차로 생성하면 될듯
                if (enemies.Count < maxEnemies &&
                (DateTime.Now - lastEnemySpawnTime).TotalSeconds >= 0.8)
                {
                    enemies.Add(new Enemy());
                    lastEnemySpawnTime = DateTime.Now;
                }
                //적들 이동처리
                foreach (Enemy enemy in enemies)
                {
                    enemy.MoveDown();
                }

                Console.Clear(); // 리랜더링 보이는게 거슬림

                player.Create();
                foreach (Enemy enemy in enemies)
                {
                    enemy.Create();
                }

                Thread.Sleep(30);
            }
        }
    }
}
