using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    internal class Weapon
    {
        //총알을 담을 큐
        //마지막 발사 시감
        //총알 발사 간격
        //총알 최대 수
        private Queue<Bullet> _bullets = new Queue<Bullet>();
        private DateTime _lastFireTime;
        private const double FireDelay = 0.2;
        private const int MaxBullets = 6;

        //충돌검사용
        public IEnumerable<Bullet> Bullets
        {
            get { return _bullets; }
        }

        //플레이어가 쏠 때
        public void Shoot(Vector playerPosition)
        {
            //무기 딜레이
            if ((DateTime.Now - _lastFireTime).TotalSeconds < FireDelay)
            {
                return;
            }
            //탄창
            int activeCount = 0;
            foreach (Bullet bullet in _bullets)
            {
                if (bullet.isActive)
                {
                    activeCount++;
                }
            }
            if (activeCount >= MaxBullets)
            {
                return;
            }
            
            _bullets.Enqueue(new Bullet(playerPosition));
            _lastFireTime = DateTime.Now;
        }

        //총알 궤적
        public void Update()
        {
            int count = _bullets.Count;
            Queue<Bullet> temp = new Queue<Bullet>();

            for (int i = 0; i < count; i++)
            {
                Bullet bullet = _bullets.Dequeue();
                bullet.Move();

                if (bullet.isActive)
                {
                    temp.Enqueue(bullet);
                }
            }
            _bullets = temp;
        }

        public void Draw()
        {
            foreach (Bullet bullet in _bullets)
            {
                bullet.Create();
            }
        }
    }
}
