namespace UralHedgehog.Data
{
    public class Player
    {
        private PlayerData _playerData;

        public Player(PlayerData data)
        {
            _playerData = data;
        }
        
        public PlayerData Save()
        {
            _playerData = new PlayerData(_playerData.Id, _playerData.Score);
            
            return _playerData;
        }
    }
}
