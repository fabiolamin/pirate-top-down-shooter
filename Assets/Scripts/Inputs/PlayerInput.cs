using PirateGame.Combat;
using PirateGame.Data.Combat;
using UnityEngine;
using UnityEngine.Events;

namespace PirateGame.Inputs
{
    public class PlayerInput : MonoBehaviour
    {
        private float _timeSinceLastShootingInput = 0f;
        private bool _canShootingInputBeTriggered = true;

        [SerializeField] private UnityEvent<Vector2> _onPlayerMoved;
        [SerializeField] private ShootingTriggerEvent _onFire1ButtonTriggered;
        [SerializeField] private ShootingTriggerEvent _onFire2ButtonTriggered;
        [SerializeField] private ShipCombatData _shipCombatData;
        private void Update()
        {
            GetMovementInput();
            GetAttackInput();
        }

        private void GetMovementInput()
        {
            Vector2 newPos = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _onPlayerMoved.Invoke(newPos);
        }

        private void GetAttackInput()
        {
            CheckAttackInput();

            if (_canShootingInputBeTriggered)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    _onFire1ButtonTriggered.Invoke(transform.right);
                    _canShootingInputBeTriggered = false;
                }

                if (Input.GetButtonDown("Fire2"))
                {
                    _onFire2ButtonTriggered.Invoke(transform.up);
                    _onFire2ButtonTriggered.Invoke(-transform.up);
                    _canShootingInputBeTriggered = false;
                }
            }
        }

        private void CheckAttackInput()
        {
            if (!_canShootingInputBeTriggered)
            {
                _timeSinceLastShootingInput += Time.deltaTime;

                if (_timeSinceLastShootingInput >= _shipCombatData.ReloadingTime)
                {
                    _canShootingInputBeTriggered = true;
                    _timeSinceLastShootingInput = 0f;
                }
            }
        }
    }
}

