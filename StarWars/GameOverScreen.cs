using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    internal class GameOverScreen
    {
        private bool _isRestartInput = false;
        public bool IsRestartInput
        { 
            get { return _isRestartInput; }
            private set { _isRestartInput = value; }
        }

        public void Show()
        {
            int centerY = Console.WindowHeight / 2;
            int centerX = Console.WindowWidth / 2;

            string gameOverText = "GAME OVER";
            string restartText = "[R] 다시 시작 | [Enter] 종료";

            Console.SetCursorPosition(centerX - gameOverText.Length / 2, centerY - 1);
            Console.WriteLine(gameOverText);
            Console.SetCursorPosition(centerX - restartText.Length / 2 - 2, centerY + 1);
            Console.WriteLine(restartText);

            WaitForInput();
        }

        private void WaitForInput()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.R)
                {
                    IsRestartInput = true;
                    break;
                }
                else if (key == ConsoleKey.Enter)
                {
                    IsRestartInput = false;
                    break;
                }
            } while (true);
        }
    }
}
