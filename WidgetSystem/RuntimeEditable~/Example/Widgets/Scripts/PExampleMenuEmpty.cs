using UnityEngine;
using UnityEngine.UI;

namespace UralHedgehog.UI
{
    /// <summary>
    /// Для примера используем пустую модель
    /// </summary>
    public class PExampleMenuEmpty : Widget<IEmptyWidget>
    {
        [SerializeField] private Button _btnOpenPopup;
        [SerializeField] private Button _btnQuit;
        
        public override void Init(IEmptyWidget model)
        {
            base.Init(model);
            
            _btnOpenPopup.onClick.AddListener(() => UISystemExampleRun.Instance.UIManager.OpenViewExamplePopupModel());
            
            _btnQuit.onClick.AddListener(() =>
            {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
            });
        }
    }
}