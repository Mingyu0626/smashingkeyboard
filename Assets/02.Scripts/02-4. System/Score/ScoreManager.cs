using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int _currentScore;
    private int _currentCombo;
    private int _maxCombo;
    private int _feverMultiple = 1;
    public int CurrentScore 
    { 
        get => _currentScore; 
        set
        {
            _currentScore = (value * _feverMultiple);
        }
    }
    public int CurrentCombo 
    { 
        get => _currentCombo; 
        set
        {
            _currentCombo = (value * _feverMultiple);
        }
    }
    public int MaxCombo { get => _maxCombo; set => _maxCombo = value; }
    public int FeverMultiple { get => _feverMultiple; set => _feverMultiple = value; }

    protected override void Awake()
    {
        base.Awake();
    }

    public void HitSuccess(int score)
    {
        CurrentCombo++;
        MaxCombo = Mathf.Max(CurrentCombo, MaxCombo);
    }
    public void HitFail()
    {
        CurrentCombo = 0;
    }
}
