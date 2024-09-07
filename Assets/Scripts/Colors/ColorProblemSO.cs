using System.Collections.Generic;
using UnityEngine;

namespace Colors
{
    [CreateAssetMenu]
    public class ColorProblemSO : ScriptableObject
    {
        [field: SerializeField] public List<Color> Colors { get; private set; }
        [field: SerializeField] public List<Color> Propositions { get; private set; }
    }
}