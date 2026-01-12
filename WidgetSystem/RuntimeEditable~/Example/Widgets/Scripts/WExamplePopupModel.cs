using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UralHedgehog.UI
{
    public class WExamplePopupModel : Widget<IExamplePopupModel>
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Button _btnClose;
        
        public override void Init(IExamplePopupModel model)
        {
            base.Init(model);
            
            _title.text = model.Title; // Устанавливаем заголовок из модели

            _btnClose.onClick.AddListener(Hide);
        }
    }
}