using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    internal class StartScreen
    {
        public void Show()
        {
            Console.Clear();

            //게임 로고
            string[] logo =
            {
                "        .+++****++***++*+. =+***=   .++***+++-      ",
                "      .+@@@@@@@@@@@@@@@@%.=@@@@@@:  .%@@@@@@@@@:    ",
                "       =@@@%.   .%@@-    .@@@##@@%  :%@@%   %@@=    ",
                "        +@@@@-  .%@@-*@@@::@@@- :%@@@@@@@@#.        ",
                "-%%%%%%%%@@@@%  .%@@-   :%@@@@@@@@# .%@@%#@@@@%%%%%-",
                "-@@@@@@@@@@@@:  .%@@-*@@%:::-@@@-:%@@% :@@@@@@@@-   ",
                " .............    ...     ..............            ",
                ".@@@%:%@@@% +@@#  %@@@@@=   -@@@@@@@@@:  .#@@@@@@@@-",
                " -@@@#@@@@@*@@@- -@@@#@@%:  -@@@+:-*@@@: -@@@@*****:",
                "  #@@@@@@@@@@@#..#@@#.%@@=  -@@@#**%@@%. .#@@@#.    ",
                "  -@@@@@:@@@@@: -@@@#*%@@@  -@@@@@@@@+     -@@@@:   ",
                "  .#@@@*.+@@@* .@@@@@@@@@@+ -@@@=-@@@@@@@@@@@@@@.   ",
                "   :#%#: .#%#. =%%%.   =%%#:-%%%-  =%%%%%%%%%#=     "
            };

            //중앙 정렬
            int centerY = ((Console.WindowHeight / 2) - (logo.Length / 2));
            int centerX = Math.Max(0, (Console.WindowWidth - logo[0].Length) / 2); //음수 방지

            for (int i = 0;  i < logo.Length; i++)
            {
                Console.SetCursorPosition(centerX, centerY + i);
                Console.WriteLine(logo[i]);
            }

            Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight - 12);
            Console.Write("Press [Enter] to Start");

            WaitForEnter();
        }

        //Enter키 입력
        private void WaitForEnter()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Enter);
        }
    }
}
