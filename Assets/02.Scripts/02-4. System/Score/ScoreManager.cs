using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int _currentScore;
    private int _currentCombo;
    private int _maxCombo;
    private int _feverMultiple = 1;
    private const int _feverMultipleMax = 5;
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
            if (_currentCombo == 50 || (0 < _currentCombo && _currentCombo % 100 == 0))
            {
                ActivateComboVFX();
            }
        }
    }
    public int MaxCombo { get => _maxCombo; set => _maxCombo = value; }
    public int FeverMultiple 
    { 
        get => _feverMultiple; 
        set
        {
            _feverMultiple = Mathf.Clamp(value, 1, _feverMultipleMax);
        }
    }
    public int FeverMultipleMAX { get => _feverMultipleMax; }
    [SerializeField] private GameObject _comboVFX;

    protected override void Awake()
    {
        base.Awake();
    }

    public void HitSuccess(int score)
    {
        CurrentCombo++;
        MaxCombo = Mathf.Max(CurrentCombo, MaxCombo);
        _currentScore += score;
        UI_Game.Instance.RefreshScore(_currentScore);
        UI_Game.Instance.RefreshCombo(_currentCombo);
    }
    public void HitFail()
    {
        CurrentCombo = 0;
        _feverMultiple = 1;
        UI_Game.Instance.RefreshCombo(_currentCombo);
    }
    public void ActivateComboVFX()
    {
        Instantiate(_comboVFX);
    }
}
