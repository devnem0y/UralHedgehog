namespace UralHedgehog.UI
{
    /// <summary>
    /// В этом классе описывается модель попапа
    /// Здесь находится логика того, что должен делать попап
    /// В данном примере мы просто устанавливаем Title
    /// </summary>
    public class ExamplePopupModel : IExamplePopupModel
    {
        public string Title { get; }

        public ExamplePopupModel()
        {
            Title = "Header";
        }
    }
}