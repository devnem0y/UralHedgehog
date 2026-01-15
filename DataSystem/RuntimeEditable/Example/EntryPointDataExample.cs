using UnityEngine;

namespace UralHedgehog.Data
{
    public class EntryPointDataExample : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        
        private Player _player;

        private void Awake()
        {
            var data = DataManager.Get<PlayerData>();
            if (data != null) _playerData = data;
            _player = new Player(_playerData);
        }

        private void OnDisable()
        {
            DataManager.Write<PlayerData>(_player);
        }
    }
}