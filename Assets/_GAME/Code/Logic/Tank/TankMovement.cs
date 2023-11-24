using UnityEngine;

namespace _GAME.Code.Logic.Tank
{
    public class TankMovement : MonoBehaviour
    {
        public void Move(Vector2 direction)
        {
            print("Move " + direction);
        }
    }
}