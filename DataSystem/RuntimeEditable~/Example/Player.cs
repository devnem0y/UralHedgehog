namespace UralHedgehog.Data
{
    public class Player : ISaverHandler
    {
        private readonly PlayerData _playerData;
        
        public IData Data { get; private set;}

        public Player(PlayerData data)
        {
            _playerData = data;
            Data = _playerData;
        }
        
        public void Save()
        {
            Data = new PlayerData(_playerData.Id, _playerData.Score);
        }
    }
}
