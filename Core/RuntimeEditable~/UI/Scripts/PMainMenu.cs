using UnityEngine;
using UnityEngine.UI;
using UralHedgehog.Core;
using UralHedgehog.UI;

public class PMainMenu : Widget<IEmptyWidget>
{
    [SerializeField] private Button _btnPlay;
    [SerializeField] private Button _btnSettings;
    [SerializeField] private Button _btnQuit;

    public override void Init(IEmptyWidget model)
    {
        base.Init(model);

        hide += OnHide;
        _btnPlay.onClick.AddListener(Hide);
        
        _btnSettings.onClick.AddListener(() =>
        {
            var ui = ServiceLocator.Get<UIRoot>();
            var settings = ServiceLocator.Get<ISettings>();
            ui.Create(nameof(WSettings), settings);
        });
        
        _btnQuit.onClick.AddListener(() =>
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        });
    }

    private static void OnHide(IWidget obj)
    {
        ServiceLocator.Get<StateMachine>().ChangeState<GameplayState>();
    }
}
