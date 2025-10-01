using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    //현재 스테이지 확인
    //클리어 했다면 어떤 액션과 다음 스테이지 진입

    //준비물: 플레이어, 에너미
    //서로 공격할거니 무기도 별개로

    //플레이어가 적을 맞춘다면 적이 소멸되어야함
    //현재 스테이지에서 적이 없으면 다음 스테이지로

    //플레이어가 적한테 파괴된다면 목숨이 1개 소모
    //모든 목숨이 소모되면 gameover= true; bool값으로 게임진행을 관리

    //점수를 합산해서 보여주고 키입력을 받고 게임 재시작
    internal class Game
    {
        private bool _gameover;

        //플레이어
        private Player _player;

        public bool gameover
        {
            get { return _gameover; }
            set { _gameover = value; }
        }

        public Player player
        {
            get { return _player; }
            set { _player = value; }
        }

        public Game()
        {
            gameover = false;
            player = new Player();
        }

        //게임 시작
        public void Start()
        {
            player.Create();
        }
    }
}
