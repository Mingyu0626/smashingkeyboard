using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int _currentScore;
    private int _currentCombo;
    private int _maxCombo;
    public int CurrentScore { get => _currentScore; set => _currentScore = value; }
    public int CurrentCombo { get => _currentCombo; set => _currentCombo = value; }
    public int MaxCombo { get => _maxCombo; set => _maxCombo = value; }

    protected override void Awake()
    {
        base.Awake();
    }
}
