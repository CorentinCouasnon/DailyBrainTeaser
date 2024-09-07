using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Colors
{
    public class ColorProblem : MonoBehaviour
    {
        [SerializeField] Transform _container;
        [SerializeField] Image _prop1;
        [SerializeField] Image _prop2;
        [SerializeField] Image _prop3;
        [SerializeField] ColorCircle _colorCirclePrefab;
        
        [Space]
        
        [SerializeField] ColorProblemSO _problem;

        void OnValidate()
        {
            EditorApplication.delayCall += () =>
            {
                Clear();

                foreach (var color in _problem.Colors)
                {
                    var c = Instantiate(_colorCirclePrefab, _container);
                    c.SetColor(color);
                }

                _prop1.color = _problem.Propositions[0];
                _prop2.color = _problem.Propositions[1];
                _prop3.color = _problem.Propositions[2];
                
                _container.GetChild(0).SetAsLastSibling();
            };
        }

        void Clear()
        {
            for (int i = _container.childCount - 2; i >= 0; i--)
            {
                DestroyImmediate(_container.GetChild(i).gameObject);
            }
        }
    }
}