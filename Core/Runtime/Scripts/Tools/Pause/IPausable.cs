namespace UralHedgehog.Core
{
    public interface IPausable
    {
        public void OnPause();
        public void OnResume();
        public void SubscribeToPauseEvents();
        public void UnsubscribeFromPauseEvents();
    }
}