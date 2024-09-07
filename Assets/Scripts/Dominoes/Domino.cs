using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Dominoes
{
    public class Domino : MonoBehaviour
    {
        [SerializeField] RectTransform _transform;
        [SerializeField] Image _image;
        [SerializeField] List<DominoSO> _dominoes;
        
        [Space]
        
        [SerializeField] DominoValue _left;
        [SerializeField] DominoValue _right;
        
        void OnValidate()
        {
            _image.sprite = _dominoes.Single(domino => domino.Left == _left && domino.Right == _right).Sprite;
            _transform.rotation = Quaternion.Euler(0, 0, _left >= _right ? 90f : 270f);
        }
        
        public void Switch()
        {
            (_left, _right) = (_right, _left);
            OnValidate();
        }
    }
}