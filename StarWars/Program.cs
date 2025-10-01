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
            Console.WriteLine("Star Wars Building");

            //게임 시작
            Game game = new Game();
            game.Start();

            //빌딩중           
            Console.WriteLine();
            Console.WriteLine("에러 없음");
            Console.ReadLine();
        }
    }
}
