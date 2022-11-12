using System;
using UnityEngine;

namespace Assets.Scripts.PlayerLogic
{
    [RequireComponent(typeof(PlayerMovement))]
    internal class Player : MonoBehaviour
    {
        private PlayerMovement _movement;
        private AbstractGun _currentGun;

        public PlayerMovement Movement => _movement;
        public AbstractGun CurrentGun => _currentGun;

        public event Action NewGunEvent;

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            _currentGun = GetComponentInChildren<AbstractGun>();
        }

        public void PickUpGun()
        {
            // какая то логика поднятия оружия
            // _currentGun = поднятое оружие
            NewGunEvent?.Invoke();
        }
    }
}
