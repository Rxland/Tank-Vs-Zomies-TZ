using UnityEngine;

namespace _GAME.Code.Logic.Tank
{
    public class TankWeaponChange : MonoBehaviour
    {
        [SerializeField] private Tank _tank;

        public void SetNextWeapon()
        {
            for (int i = 0; i < _tank.AllGuns.Count; i++)
            {
                Gun.Gun gun = _tank.AllGuns[i];

                if (gun.Type == _tank.SelectedGun.Type)
                {
                    if (i + 1 > _tank.AllGuns.Count - 1)
                    {
                        ChangeWeapon(_tank.AllGuns[0]);
                    }
                    else
                    {
                        ChangeWeapon(_tank.AllGuns[i + 1]);
                    }
                    break;
                }
            }
        }
        
        public void SetPrevWeapon()
        {
            for (int i = 0; i < _tank.AllGuns.Count; i++)
            {
                Gun.Gun gun = _tank.AllGuns[i];

                if (gun.Type == _tank.SelectedGun.Type)
                {
                    if (i - 1 < 0)
                    {
                        ChangeWeapon(_tank.AllGuns[_tank.AllGuns.Count - 1]);
                    }
                    else
                    {
                        ChangeWeapon(_tank.AllGuns[i - 1]);
                    }
                    break;
                }
            }
        }

        private void ChangeWeapon(Gun.Gun nextWeapon)
        {
            Gun.Gun prevWeapon = _tank.SelectedGun;
            prevWeapon.gameObject.SetActive(false);

            _tank.SelectedGun = nextWeapon;
            _tank.SelectedGun.gameObject.SetActive(true);
        }
    }
}