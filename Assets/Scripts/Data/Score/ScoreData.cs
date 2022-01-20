using UnityEngine;

namespace PirateGame.Data.Score
{
    [CreateAssetMenu(fileName = "Score Data", menuName = "Score/new Score Data")]
    public class ScoreData : ScriptableObject
    {
        public int Score { get; private set; } = 0;

        public void AddPonints(int points)
        {
            Score += points;
        }

        public void ResetScore()
        {
            Score = 0;
        }
    }
}

