using _GAME.Code.Configs_Data;
using _GAME.Code.UI;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace _GAME.Code.Logic.Character
{
    public class CharacterStats : MonoBehaviour
    {
        [SerializeField] private CharacterCanvas _characterCanvas;
        [Space]
        
        [ReadOnly] public float MoveSpeed;
        [ReadOnly] public float TurnSpeed;
        [ReadOnly] public ReactiveProperty<float> Health;
        [ReadOnly] public float Armor;

        private float _maxHealth;
        private bool _isKilled;
        
        public virtual void Init(StatsConfig statsConfig)
        {
            MoveSpeed = statsConfig.MoveSpeed;
            TurnSpeed = statsConfig.TurnSpeed;
            Health.Value = statsConfig.Health;
            Armor = statsConfig.Armor;

            _maxHealth = Health.Value;

            Bind();
        }

        private void Bind()
        {
            Health.Subscribe(_ => _characterCanvas.HpFilledImg.fillAmount = Health.Value / _maxHealth);
        }
        
        public virtual void TakeDamage(float Damage)
        {
            if (_isKilled) return;
            
            Health.Value = Mathf.Clamp(Health.Value - Damage * Armor, 0, _maxHealth);

            if (Health.Value <= 0)
                Die();
        }

        public virtual void Die()
        {
            
        }
    }
}