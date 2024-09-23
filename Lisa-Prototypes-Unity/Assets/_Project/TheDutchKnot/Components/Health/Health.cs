using UnityEngine;
using System;

namespace tdk.Components
{
    public class Health : MonoBehaviour, IHealth, IHealthEvents
    {
        public event Action OnDamage;
        public event Action OnDeath;
        public event Action OnHeal;

        [SerializeField]
        HealthConfig healthConfig;

        int currentHealth;
        public int CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            set
            {
                if (value > currentHealth)
                {
                    if (value >= healthConfig.HealthMax)
                    {
                        currentHealth = healthConfig.HealthMax;
                        return;
                    }
                    currentHealth = value;

                    OnHeal?.Invoke();
                }

                if (value < currentHealth)
                {
                    if (value <= healthConfig.HealthMin)
                    {
                        currentHealth = healthConfig.HealthMin;
                        OnDeath?.Invoke();
                        return;
                    }
                    currentHealth = value;

                    OnDamage?.Invoke();
                }
            }
        }

        void Awake() => currentHealth = healthConfig.HealthMax;

        public void HealDamage(int amount) => CurrentHealth += amount;
        public void TakeDamage(int amount) => CurrentHealth -= amount;
    }

    public interface IHealth
    {
        public int CurrentHealth { get; set; }

        public void TakeDamage(int amount);
        public void HealDamage(int amount);
    }

    public interface IHealthEvents
    {
        public event Action OnDamage;
        public event Action OnDeath;
        public event Action OnHeal;
    }
}