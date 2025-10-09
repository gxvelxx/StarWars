using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars
{
    internal class Enemies
    {
        //적들을 담을 리스트
        //마지막 적 생성 시간
        //최대 적의 수, 생성간격
        private List<Enemy> _enemies = new List<Enemy>();
        private DateTime _lastSpawnTime;
        private readonly int _maxEnemies;
        private readonly double _spawnInterval;

        //충돌감지용
        public List<Enemy> EnemyList
        {
            get { return _enemies; }
        }

        //생성자에서 최대수,생성시간 관리
        public Enemies(int maxEnemies, double spawnInterval)
        {
            _maxEnemies = maxEnemies;
            _spawnInterval = spawnInterval;
            _lastSpawnTime = DateTime.Now;
        }

        public void UpdateSpawn()
        {
            if (_enemies.Count <  _maxEnemies &&
                (DateTime.Now - _lastSpawnTime).TotalSeconds >= _spawnInterval)
            {
                _enemies.Add(new Enemy());
                _lastSpawnTime = DateTime.Now;
            }
        }

        public void MoveAll()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.MoveDown();
            }
        }

        public void CreateAll()
        {
            foreach(Enemy enemy in _enemies)
            {
                enemy.Create();
            }
        }
    }
}
