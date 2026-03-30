namespace UralHedgehog.Core
{
    public class LaunchState : IState
    {
        public void Enter()
        {
            ServiceLocator.Get<IProfile>().Load();
            ServiceLocator.Get<StateMachine>().ChangeState<MainMenuState>();
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            
        }
    }
}