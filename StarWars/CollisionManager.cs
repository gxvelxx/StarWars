using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    internal class CollisionManager
    {
        //충돌 검사를 해야할 것들
        private Weapon _weapon;
        private List<Enemy> _targetEnemies;

        public CollisionManager(Weapon weapon, List<Enemy> targetEnemies)
        {
            _weapon = weapon;
            _targetEnemies = targetEnemies;            
        }

        //AABB 충돌검사 함수
        private bool IsColliding(Object obj1, Object obj2)
        {
            int x1 = obj1.PositionX;
            int y1 = obj1.PositionY;
            int h1 = obj1.Height;
            int w1 = obj1.Width;

            int x2 = obj2.PositionX;
            int y2 = obj2.PositionY;
            int h2 = obj2.Height;
            int w2 = obj2.Width;

            bool xOverlap = (x1 < x2 + w2) && (x1 + w1 > x2);
            bool yOverlap = (y1 < y2 + h2) && (y1 + h1 > y2);

            return xOverlap && yOverlap;
        }

        public void CheckAllColliding()
        {
            CheckBulletEnemyCollisions();
        }

        private void CheckBulletEnemyCollisions()
        {
            //제거목록         
            List<Enemy> enemiesToRemove = new List<Enemy>();

            foreach (Bullet bullet in _weapon.Bullets) //항상 최신 Queue 정보사용해야 충돌이 감지됨
            {
                if (!bullet.isActive)
                {
                    continue;
                }
                foreach (Enemy enemy in _targetEnemies)
                {                    
                    if (IsColliding(bullet, enemy))
                    {                        
                        bullet.DeActive(); // 총알 비활성화
                        enemiesToRemove.Add(enemy);
                        break; // 원샷원킬
                    }
                }
            }
            //리스트에서 적 제거           
            foreach (Enemy enemy in enemiesToRemove)
            {
                _targetEnemies.Remove(enemy);
            }
        }
    }
}
