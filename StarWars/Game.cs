using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars
{    
    public enum GameResult
    {
        PlayerDied, BossDefeated, BossDefeated_PlayerDied
    }
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
            Initialize();
        }

        //게임 설정
        private void Initialize()
        {
            gameover = false;
            player = new Player();
            enemies = new Enemies(24, 0.2); //난이도 조절가능
            boss = new Boss();

            collisionManager = new CollisionManager(player.Weapon, enemies.EnemyList, boss, player);
        }

        //게임 시작
        public GameResult Start()
        {
            Console.CursorVisible = false;
            bool bossDefeated = false;

            //기능 추가될 때마다 순서를 매번 수정하고 신경써야해서 가장 지옥같은 구간
            while (true)
            {
                player.ReadKey();
                player.Move();

                enemies.UpdateSpawn();
                enemies.MoveAll();

                //충돌감지
                player.Weapon.Update();
                collisionManager.CheckAllColliding();
                boss.Move();

                Console.Clear();

                //보스 생존 확인
                if (!bossDefeated && !boss.IsAlive)
                {
                    bossDefeated = true;
                    GameWInScreen gameWin = new GameWInScreen(); //화면관리는 Program에서만 관리하고 싶은데
                    gameWin.Show(); //보스 처치시 문구만 출력 후 게임을 계속 진행하려니
                                    //여기서 작성해야 흐름이 이어짐, 옮길 방법을 생각해봐야함
                }

                //플레이어 생존 확인
                if (!player.IsAlive)
                {
                    if (bossDefeated)
                    {
                        return GameResult.BossDefeated_PlayerDied;
                    }
                    else
                    {
                        return GameResult.PlayerDied;
                    }
                }

                player.Create();
                player.Weapon.Draw();
                enemies.CreateAll();
                
                if (boss.IsAlive)
                {
                    boss.Create();
                }                

                Thread.Sleep(30);
            }
        }
    }
}
