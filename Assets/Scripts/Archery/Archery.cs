using TMPro;
using UnityEditor;
using UnityEngine;
using Utils;

public class Archery : MonoBehaviour
{
    [SerializeField] Difficulty _difficulty;
    
    [Space]

    [SerializeField] BackgroundSwitcher _backgroundSwitcher;

    [SerializeField] TextMeshProUGUI _text3_0;
    [SerializeField] TextMeshProUGUI _text3_1;
    [SerializeField] TextMeshProUGUI _text3_2;
    
    [SerializeField] TextMeshProUGUI _text4_0;
    [SerializeField] TextMeshProUGUI _text4_1;
    [SerializeField] TextMeshProUGUI _text4_2;
    [SerializeField] TextMeshProUGUI _text4_3;
    
    [SerializeField] TextMeshProUGUI _text5_0;
    [SerializeField] TextMeshProUGUI _text5_1;
    [SerializeField] TextMeshProUGUI _text5_2;
    [SerializeField] TextMeshProUGUI _text5_3;
    [SerializeField] TextMeshProUGUI _text5_4;
    
    [SerializeField] TextMeshProUGUI _scoreText;
    
    [SerializeField] GameObject _target3;
    [SerializeField] GameObject _target4;
    [SerializeField] GameObject _target5;
    
    [Space]

    [SerializeField] Transform _dartContainer;
    [SerializeField] GameObject _dartPrefab;

    public void Generate()
    {
        EditorApplication.delayCall += () =>
        {
            Clear();

            _backgroundSwitcher.Switch(_difficulty);
            
            var dartCount = GetDartCount(_difficulty);
            
            for (int i = 0; i < dartCount; i++)
            {
                Instantiate(_dartPrefab, _dartContainer);
            }
            
            _target4.SetActive(true);

            var startingValue = GetStartingValue(_difficulty);

            _text4_0.text = $"{startingValue}";
            _text4_1.text = $"{startingValue + 2}";
            _text4_2.text = $"{startingValue + 4}";
            _text4_3.text = $"{startingValue + 8}";

            _scoreText.text = $"{GetScore(dartCount, startingValue, startingValue + 2, startingValue + 4, startingValue + 8)}";
        };
    }

    int GetDartCount(Difficulty difficulty)
    {
        return difficulty switch
        {
            Difficulty.None => 3,
            Difficulty.Easy => 3,
            Difficulty.Medium => 4,
            Difficulty.Hard => 5,
            Difficulty.Extreme => 6,
        };
    }
    
    int GetStartingValue(Difficulty difficulty)
    {
        var easyStartingValues = new[]{ 3, 5, 7 };
        var mediumStartingValues = new[]{ 5, 7, 9 };
        var hardStartingValues = new[]{ 7, 9, 11 };
        var extremeStartingValues = new[]{ 9, 11, 13 };
        
        return difficulty switch
        {
            Difficulty.None => easyStartingValues.GetRandom(),
            Difficulty.Easy => easyStartingValues.GetRandom(),
            Difficulty.Medium => mediumStartingValues.GetRandom(),
            Difficulty.Hard => hardStartingValues.GetRandom(),
            Difficulty.Extreme => extremeStartingValues.GetRandom(),
        };
    }

    int GetScore(int dartCount, params int[] values)
    {
        var score = 0;
        
        for (int i = 0; i < dartCount; i++)
        {
            score += values.GetRandom();
        }

        return score;
    }

    void Clear()
    {
        _target3.SetActive(false);
        _target4.SetActive(false);
        _target5.SetActive(false);

        for (int i = _dartContainer.childCount - 2; i >= 0; i--)
        {
            DestroyImmediate(_dartContainer.GetChild(i).gameObject);
        }
    }
}

[CustomEditor(typeof(Archery))]
public class ArcheryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var obj = (Archery) target;
        
        if (GUILayout.Button("Generate"))
        {
            obj.Generate();
        }
    }
}