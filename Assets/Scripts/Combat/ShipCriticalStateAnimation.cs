using UnityEngine;
using System.Linq;
using System.Collections;

namespace PirateGame.Combat
{
    [System.Serializable]
    public struct Pirate
    {
        public Transform Transform;
        public Vector2 EscapingDirection;
        public float EscapingSpeed;
    }

    public class ShipCriticalStateAnimation : MonoBehaviour
    {
        private bool _hasCrewLeft = false;

        [SerializeField] private Animator _animator;
        [SerializeField] private Pirate[] _pirates;
        [SerializeField] private float _crewEscapingDuration = 3f;

        private void OnEnable()
        {
            _pirates.ToList().ForEach(p => p.Transform.gameObject.SetActive(false));
            _pirates.ToList().ForEach(p => p.Transform.position = transform.position);
            _pirates.ToList().ForEach(p => p.Transform.SetParent(transform));
            _hasCrewLeft = false;
        }

        private void Update()
        {
            MovePirates();
        }

        private void MovePirates()
        {
            if (_hasCrewLeft)
            {
                foreach (Pirate pirate in _pirates)
                {
                    pirate.Transform.SetParent(null);
                    pirate.Transform.Translate(pirate.EscapingDirection * pirate.EscapingSpeed * Time.deltaTime);
                }
            }
        }

        public void SetCriticalState(bool isCriticalState)
        {
            _animator.SetBool("IsBurning", isCriticalState);
            CheckCrewEscaping(isCriticalState);
        }

        private void CheckCrewEscaping(bool isCriticalState)
        {
            if (isCriticalState && !_hasCrewLeft)
            {
                _pirates.ToList().ForEach(p => p.Transform.gameObject.SetActive(true));
                _hasCrewLeft = true;
                StartCoroutine(SetCrewEscapingDuration());
            }
        }

        private IEnumerator SetCrewEscapingDuration()
        {
            yield return new WaitForSeconds(_crewEscapingDuration);
            _pirates.ToList().ForEach(p => p.Transform.gameObject.SetActive(false));
        }
    }
}

