using _GAME.Code.Configs_Data;
using _GAME.Code.Factories;
using _GAME.Code.Features;
using _GAME.Code.Logic.Tank.Gun;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Tank
{
    public class TankShoot : MonoBehaviour
    {
        [SerializeField] private Tank _tank;

        [Inject] private GameFactory _gameFactory;
        [Inject] private GunFeature _gunFeature;
        
        public void Shoot()
        {
            GunConfigData selectedGunConfigData = _gunFeature.GetGunConfig(_tank.SelectedGun.Type);
            
            Bullet bullet = _gameFactory.SpawnBullet(_tank.SelectedGun.BulletSpawnPoint.transform.position, _tank.SelectedGun.BulletSpawnPoint.transform.rotation);
            bullet.Damage = selectedGunConfigData.Damage;
            
            bullet.Init();
        }
    }
}