using System;
using UnityEngine;

namespace UralHedgehog.Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private int _id;
        public int Id => _id;
        
        [SerializeField] private int _score;
        public int Score => _score;

        public PlayerData(int id, int score)
        {
            _id = id;
            _score = score;
        }
    }
}