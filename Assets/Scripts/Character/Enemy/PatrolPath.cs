using UnityEngine;

namespace PirateGame.Character.Enemy
{
    public class PatrolPath : MonoBehaviour
    {
        private int _waypointIndex = 0;

        [SerializeField] private float _waypointGizmosRadius = 0.5f;

        public Vector3 CurrentWaypoint { get; private set; }

        private void Awake()
        {
            CurrentWaypoint = transform.GetChild(_waypointIndex).position;
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(GetWaypoint(i), _waypointGizmosRadius);

                int nextWaypoint = GetNextWaypointIndex(i);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(nextWaypoint));
            }
        }

        private Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }

        private int GetNextWaypointIndex(int i)
        {
            i++;
            return i % transform.childCount;
        }

        public void UpdateCurrentWaypoint()
        {
            _waypointIndex = GetNextWaypointIndex(_waypointIndex);
            CurrentWaypoint = GetWaypoint(_waypointIndex);
        }
    }
}

