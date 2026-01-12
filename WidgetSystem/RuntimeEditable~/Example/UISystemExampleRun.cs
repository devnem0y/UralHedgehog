using UnityEngine;

namespace UralHedgehog.UI
{
    /// <summary>
    /// Сцена может иметь только один UIRoot.
    /// При смене сцены в UIManager нужно передать новый UIRoot.
    /// </summary>
    public class UISystemExampleRun : MonoBehaviour
    {
        public static UISystemExampleRun Instance { get; private set; }
    
        public UIManager UIManager { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            var examplePopupModel = new ExamplePopupModel();
            
            UIManager = new UIManager(FindFirstObjectByType<UIRoot>(), examplePopupModel);
        
            UIManager.OpenViewExampleMenuEmpty();
        }

        private void Update()
        {
            //TODO: Принудительное уничтожение виджета
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIManager.CloseViewExample();
            }
        }
    }
}
