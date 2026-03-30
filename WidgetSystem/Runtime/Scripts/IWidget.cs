using System;

namespace UralHedgehog.UI
{
    public interface IWidget
    {
        public string Name { get; }
            
        public event Action<IWidget> hide;
            
        void Hide();
    }
}