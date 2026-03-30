using UnityEngine;

namespace UralHedgehog.Core
{
    [System.Serializable]
    public class PlayerData : IPlayerData
    {
        [SerializeField] private int _score;
        public int Score => _score;

        public PlayerData(int score)
        {
            _score = score;
        }
    }
}