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
                game.Start();

                Console.Clear();

                //게임오버 화면
                GameOverScreen gameOverScreen = new GameOverScreen();
                gameOverScreen.Show();

                if (gameOverScreen.IsRestartInput)
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    exit = true;
                }
            }
        }
    }
}
