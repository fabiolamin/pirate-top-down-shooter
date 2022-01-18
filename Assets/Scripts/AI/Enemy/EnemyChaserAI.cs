using PirateGame.AI.Path;
using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public class EnemyChaserAI : EnemyAI
    {
        protected override Transform GetTarget()
        {
            return FindObjectOfType<Target>().transform;
        }
    }
}
