using System.Collections.Generic;
using UnityEngine;

namespace UralHedgehog.UI
{
    [CreateAssetMenu(fileName = "WidgetStorage", menuName = "Ural Hedgehog/UI/Widget Storage", order = 0)]
    public class WidgetStorage : ScriptableObject
    {
        [SerializeField] private MonoBehaviour[] _widgets;
        public IEnumerable<MonoBehaviour> Widgets => _widgets;
    }
}