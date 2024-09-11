using System;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSwitcher : MonoBehaviour
{
    [SerializeField] Sprite _bgEasy;
    [SerializeField] Sprite _bgMedium;
    [SerializeField] Sprite _bgHard;
    [SerializeField] Sprite _bgExtrme;

    [SerializeField] Image _bg;

    public void Switch(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.None:
            case Difficulty.Easy:
                _bg.sprite = _bgEasy;
                break;
            case Difficulty.Medium:
                _bg.sprite = _bgMedium;
                break;
            case Difficulty.Hard:
                _bg.sprite = _bgHard;
                break;
            case Difficulty.Extreme:
                _bg.sprite = _bgExtrme;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, null);
        }
    }
}