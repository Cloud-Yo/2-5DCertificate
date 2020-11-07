using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoSignleton<UIManager>
{

    [SerializeField] private TMP_Text _scoreTxt = null;
    [SerializeField] private int _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    public void UpdateScore(int points)
    {
        _score += points;
        _scoreTxt.SetText($"SCORE: {_score}");
    }
}
