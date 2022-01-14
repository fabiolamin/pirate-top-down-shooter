using UnityEngine;
using UnityEngine.Events;

namespace PirateGame.Inputs
{
    [System.Serializable]
    public class PlayerMovementEvent : UnityEvent<Vector2> { }

    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovementEvent _onPlayerMoved;

        private void Update()
        {
            Vector2 newPos = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _onPlayerMoved.Invoke(newPos);
        }
    }
}

