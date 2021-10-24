using SkyWorld.Player;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.HealthSystem {
    public class PlayerHealth : MonoBehaviour {
        [Inject] private HealthBar _healthBar;

        public Action OnPlayerDie;
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        private bool isInit = false;

        public void Init(int maxHealth) {
            if (isInit) return;
            isInit = true;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(int damage = 1) {
            damage = damage > 0 ? damage : -damage;
            CurrentHealth -= damage;
            _healthBar.DisplayHealth(CurrentHealth);
            if (CurrentHealth <= 0) OnPlayerDie?.Invoke();
        }

        public void TakeHeal(int heal = 1) {
            CurrentHealth 
                = CurrentHealth + heal > MaxHealth 
                ? MaxHealth 
                : CurrentHealth + heal;
            _healthBar.DisplayHealth(CurrentHealth);
        }

        void Start() {
            _healthBar.DisplayHealth(MaxHealth);
        }
    }
}