using System.Collections.Generic;
using UnityEngine;

namespace _GAME.Code.Logic.Tank
{
    public class Tank : MonoBehaviour
    {
        public TankMovement Movement;
        public TankShoot Shoot;
        public Rigidbody Rigidbody;
        [Space] 
        
        public List<Gun.Gun> AllGuns;
        public Gun.Gun SelectedGun;
    }
}