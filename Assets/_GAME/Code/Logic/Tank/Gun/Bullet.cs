using _GAME.Code.Logic.Character;
using _GAME.Code.Tools;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME.Code.Logic.Tank.Gun
{
    public class Bullet : MonoBehaviour
    {
        [ReadOnly] public float Damage;

        [Space]
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float Speed;


        public void Init()
        {
            _rb.AddForce(transform.forward * Speed, ForceMode.Impulse);
            
            Destroy(gameObject ? gameObject : null, 5f);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (!GameExtensions.IsLayerInMask(_layerMask, collision.gameObject.layer)) return;

            if (collision.gameObject.TryGetComponent(out CharacterStats characterStats))
            {
                characterStats.TakeDamage(Damage);
                
                Destroy(gameObject);
            }
        }
    }
}