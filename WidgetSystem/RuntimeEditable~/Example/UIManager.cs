namespace UralHedgehog.UI
{
    public class UIManager
    {
        private readonly UIRoot _uiRoot;
        private readonly IExamplePopupModel _examplePopupModel;
            
        public UIManager(UIRoot uiRoot, IExamplePopupModel examplePopupModel)
        {
            _uiRoot = uiRoot;
            _examplePopupModel = examplePopupModel;
        }

        #region Open

        /// <summary>
        /// Поднимает виджет с моделью IExamplePopupModel
        /// </summary>
        public void OpenViewExamplePopupModel()
        {
            _uiRoot.Create(nameof(WExamplePopupModel), _examplePopupModel);
        }
            
        /// <summary>
        /// Поднимает пустой виджет (без модели)
        /// Для этого используем данную конструкцию (IEmptyWidget, модель null)
        /// </summary>
        public void OpenViewExampleMenuEmpty()
        {
            _uiRoot.Create<IEmptyWidget>(nameof(PExampleMenuEmpty), null);
        }

        #endregion

        //TODO: Методы Close могут понадобиться для принудительного закрытия виджета, либо если виджет не имеет кнопки закрыть.
        //TODO: Его можно закрыть и уничтожить из любого места.
        #region Close

        /// <summary>
        /// Уничтожает виджет с моделью IExamplePopupModel
        /// </summary>
        public void CloseViewExample()
        {
            _uiRoot.Kill(nameof(WExamplePopupModel));
        }

        #endregion
    }
}