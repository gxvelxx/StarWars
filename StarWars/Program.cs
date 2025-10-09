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
           
            Console.Clear();            

            //게임 시작
            Game game = new Game();
            game.Start();
        }
    }
}
