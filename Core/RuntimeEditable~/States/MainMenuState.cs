using UralHedgehog.UI;

namespace UralHedgehog.Core
{
    public class MainMenuState : IState
    {
        public void Enter()
        {
            var ui = ServiceLocator.Get<UIRoot>();
            ui.Create<IEmptyWidget>(nameof(PMainMenu), null);
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            
        }

        public void LateUpdate()
        {
            
        }
    }
}