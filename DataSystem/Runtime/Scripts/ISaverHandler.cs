namespace UralHedgehog.Data
{
    public interface ISaverHandler
    {
        IData Data { get; }
        
        void Save();
    }
}