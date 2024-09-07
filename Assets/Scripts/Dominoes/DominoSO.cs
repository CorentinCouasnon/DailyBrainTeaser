using UnityEngine;

namespace Dominoes
{
    [CreateAssetMenu]
    public class DominoSO : ScriptableObject
    {
        [field: SerializeField] public DominoValue Left { get; private set; }
        [field: SerializeField] public DominoValue Right { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}