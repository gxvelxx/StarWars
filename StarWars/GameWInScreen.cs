using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars
{
    internal class GameWInScreen
    {
        private bool _isRestartInput = false;
        public bool IsRestartInput
        {
            get { return _isRestartInput; }
            private set { _isRestartInput = value; }
        }

        private bool _exitGame = false;
        public bool ExitGame
        {
            get { return _exitGame; }
            private set { _exitGame = value; }
        }

        public void Show(bool final = false)
        {
            int centerY = Console.WindowHeight / 2;
            int centerX = Console.WindowWidth / 2;

            string bossDefeatedText = "데스스타를 처치했습니다!!!";
            string gameKeepPlayText = "이제 남은 적들을 처치하며 기록을 갱신해보세요!";

            string gameWinText = "임무 성공!! 적들을 무찔렀습니다!!"; //처치 기록을 볼 수 있게 수정해야함
            string reStartText = "[R] 다시 시작 | [Enter] 게임 종료";

            if (!final)
            {
                //보스 처치시
                Console.SetCursorPosition(centerX - bossDefeatedText.Length / 2 - 4, centerY - 1);
                Console.WriteLine(bossDefeatedText);
                Console.SetCursorPosition(centerX - gameKeepPlayText.Length / 2 - 8, centerY + 1);
                Console.WriteLine(gameKeepPlayText);
                Thread.Sleep(1500);
                return;
            }
            else
            {
                //보스 처치후 기록경신 종료시
                Console.SetCursorPosition(centerX - gameWinText.Length / 2 - 5, centerY - 1);
                Console.WriteLine(gameWinText);
                Console.SetCursorPosition(centerX - reStartText.Length / 2 - 3, centerY + 1);
                Console.WriteLine(reStartText);

                WaitForInput();
            }            
        }
        private void WaitForInput()
        {
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.R)
                {
                    IsRestartInput = true;
                    break;
                }
                else if (key == ConsoleKey.Enter)
                {
                    ExitGame = true;
                    break;
                }
            }
        }
    }
}
