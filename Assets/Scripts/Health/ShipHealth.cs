using PirateGame.Data.Health;
using PirateGame.Utils;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace PirateGame.Health
{
    public class ShipHealth : MonoBehaviour
    {
        private float _currentHealth = 0f;
        private bool _isAlive = true;

        [SerializeField] private ShipHealthData _shipHealthData;
        [SerializeField] private SpriteRenderer _shipSpriteRenderer;
        [SerializeField] private UnityEvent _onDied;
        [SerializeField] private FloatEvent _onHealthUpdated;
        [SerializeField] private BoolEvent _onCriticalState;

        private void OnEnable()
        {
            _isAlive = true;
            _currentHealth = _shipHealthData.MaxHealth;
            UpdateHealth();
        }

        public void GetDamage(float damage)
        {
            if (_isAlive)
            {
                _currentHealth = Mathf.Clamp(_currentHealth - damage, 0f, _shipHealthData.MaxHealth);
                UpdateHealth();
                CheckHealth();
            }
        }

        private void UpdateHealth()
        {
            _onHealthUpdated.Invoke(_currentHealth / _shipHealthData.MaxHealth);
            ShipState shipState = _shipHealthData.GetCurrentState(_currentHealth);
            _shipSpriteRenderer.sprite = shipState.State;
            _onCriticalState.Invoke(shipState.IsCriticalState);
        }

        private void CheckHealth()
        {
            if (_currentHealth <= 0f)
            {
                _isAlive = false;
                _onDied.Invoke();
                StartCoroutine(SetDeath());
            }
        }

        private IEnumerator SetDeath()
        {
            yield return new WaitForSeconds(_shipHealthData.DeathDelay);
            gameObject.SetActive(false);
        }

        public void DieHimself()
        {
            GetDamage(_shipHealthData.MaxHealth);
        }
    }
}

