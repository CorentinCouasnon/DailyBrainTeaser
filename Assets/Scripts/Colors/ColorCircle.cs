using UnityEngine;
using UnityEngine.UI;

namespace Colors
{
    public class ColorCircle : MonoBehaviour
    {
        [SerializeField] Image _circle;

        public void SetColor(Color color)
        {
            _circle.color = color;
        }
    }
}