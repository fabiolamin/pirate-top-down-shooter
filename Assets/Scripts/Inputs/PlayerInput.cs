using PirateGame.Combat;
using PirateGame.Movement;
using UnityEngine;

namespace PirateGame.Inputs
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private CharacterMovementEvent _onPlayerMoved;
        [SerializeField] private ShootingTriggerEvent _onShooting1Triggered;
        [SerializeField] private ShootingTriggerEvent _onShooting2Triggered;

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
            if (Input.GetButtonDown("Fire1"))
            {
                _onShooting1Triggered.Invoke(transform.right);
            }

            if (Input.GetButtonDown("Fire2"))
            {
                _onShooting2Triggered.Invoke(transform.up);
                _onShooting2Triggered.Invoke(-transform.up);
            }
        }
    }
}

