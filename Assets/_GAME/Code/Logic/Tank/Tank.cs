using System.Collections.Generic;
using _GAME.Code.Logic.Character;
using UnityEngine;

namespace _GAME.Code.Logic.Tank
{
    public class Tank : MonoBehaviour
    {
        public Rigidbody Rigidbody;
        [Space]
        
        public TankMovement Movement;
        public TankShoot Shoot;
        public TankWeaponChange WeaponChange;
        public CharacterStats Stats;
        [Space]
        
        public List<Gun.Gun> AllGuns;
        public Gun.Gun SelectedGun;
    }
}