using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Console.OutputEncoding = Encoding.UTF8; // 특수문자 깨짐 해결
            
            //콘솔창 지정
            int height = 60;
            int width = 80;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            //메인 루프관리
            bool exit = false;

            while (!exit)
            {
                //시작 화면
                StartScreen startScreen = new StartScreen();
                startScreen.Show();

                Console.Clear();

                //게임 실행
                Game game = new Game();
                GameResult result = game.Start(); //게임 상황 확인

                Console.Clear();
                
                //상황에 따라
                if (result == GameResult.PlayerDied)
                {
                    //게임 종료시
                    GameOverScreen gameOver = new GameOverScreen();
                    gameOver.Show();

                    if (!gameOver.IsRestartInput)
                    {
                        exit = true;
                    }
                }
                //else if (result == GameResult.BossDefeated)
                //{
                //    //보스 처치시
                //    GameWInScreen gameWin = new GameWInScreen();
                //    gameWin.Show();
                //}
                else if (result == GameResult.BossDefeated_PlayerDied)
                {
                    //보스 처치후 게임 종료시
                    GameWInScreen gamefinish = new GameWInScreen();
                    gamefinish.Show(final: true);

                    if (gamefinish.IsRestartInput)
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        exit = true;
                    }
                }

                Console.Clear();
            }
        }
    }
}
