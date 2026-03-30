namespace UralHedgehog.Core
{
    public interface ISettings : ISettingsData
    {
        public void Save();
    }
}