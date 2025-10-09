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
        private Boss boss;

        //충돌감지
        private CollisionManager collisionManager; //플레이어나 보스 여백 충돌 해결해야함

        public Game()
        {
            gameover = false;
            player = new Player();
            enemies = new Enemies(24, 0.2); //난이도 조절가능
            boss = new Boss();

            collisionManager = new CollisionManager(player.Weapon, enemies.EnemyList, boss, player);
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

                //충돌감지
                player.Weapon.Update();
                collisionManager.CheckAllColliding();

                boss.Move();

                Console.Clear(); // 리랜더링 보이는게 거슬림
                player.Create();
                player.Weapon.Draw();
                enemies.CreateAll();
                boss.Create();

                Thread.Sleep(30);
            }
        }
    }
}
