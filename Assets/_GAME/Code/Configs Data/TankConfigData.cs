using System.Collections.Generic;
using _GAME.Code.Logic.Tank;
using _GAME.Code.Logic.Tank.Gun;
using UnityEngine;

namespace _GAME.Code.Configs_Data
{
    [CreateAssetMenu(fileName = "Tank Config Data", menuName = "Configs/Tank Config Data")]
    public class TankConfigData : ScriptableObject
    {
        public Tank TankPrefab;
        [Space]
        
        public float MoveSpeed;
        public float TurnSpeed;
        [Space]

        public Bullet BulletPrefab;
        [Space]
        
        public List<GunConfigData> Guns;
    }
}