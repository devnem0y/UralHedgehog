namespace UralHedgehog.Core
{
    public class Player : IPlayer, ISubscriptionHandler
    {
        private PlayerData _data;
        
        public int Score { get; private set; } //TODO: Значение из IPlayerData, нужно для отображения в UI
        
        private readonly IProfile _profile;

        public Player()
        {
            _profile = ServiceLocator.Get<IProfile>();
            _profile.onProfileLoaded += OnProfileLoaded;
        }

        public void Unsubscribe()
        {
            _profile.onProfileLoaded -= OnProfileLoaded;
        }

        public void Save()
        {
            _data = new PlayerData(Score);
            _profile.SavePlayer(_data);
        }
        
        private void OnProfileLoaded()
        {
            _data = _profile.PlayerData;
            Score = _data.Score;
        }
    }
}