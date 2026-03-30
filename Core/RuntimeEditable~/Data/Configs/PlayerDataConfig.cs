using UnityEngine;

namespace UralHedgehog.Core
{
    [CreateAssetMenu(fileName = "PlayerDataConfig", menuName = "Ural Hedgehog/Data/PlayerDataConfig", order = 1)]
    public class PlayerDataConfig : ScriptableObject
    {
        [SerializeField] private PlayerData _playerData;
        public PlayerData PlayerData => _playerData;
    }
}