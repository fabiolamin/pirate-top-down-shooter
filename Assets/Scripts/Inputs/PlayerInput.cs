using PirateGame.Character;
using UnityEngine;

namespace PirateGame.Inputs
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private CharacterMovementEvent _onPlayerMoved;

        private void Update()
        {
            Vector2 newPos = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _onPlayerMoved.Invoke(newPos);
        }
    }
}

