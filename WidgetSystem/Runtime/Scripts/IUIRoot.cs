namespace UralHedgehog.UI
{
    public interface IUIRoot
    {
        public void Create<T>(string widgetName, T model);
        public void Kill(string widgetName);
    }
}