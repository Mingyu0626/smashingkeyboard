using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int _currentScore;
    private int _currentCombo;
    private int _maxCombo;
    private bool _isFeverState = false;
    private int _feverStack = 1;
    private const int _feverStackMax = 5;
    public int CurrentScore 
    { 
        get => _currentScore; 
        set
        {   
            _currentScore = value;
            if (_currentScore == 10000 || _currentScore == 100000)
            {
                LevelManager.Instance.LevelUp();
            }

        }
    }
    public int CurrentCombo 
    { 
        get => _currentCombo; 
        set
        {
            if (_isFeverState)
            {
                _currentCombo = value + _feverStack;
            }
            else
            {
                _currentCombo = value;
            }

            if (_currentCombo == 50 || (0 < _currentCombo && _currentCombo % 100 == 0))
            {
                // ActivateComboVFX();
                UI_Game.Instance.ComboAnimation(_currentCombo);
            }
        }
    }
    public int MaxCombo { get => _maxCombo; set => _maxCombo = value; }
    public bool IsFeverState { get => _isFeverState; set => _isFeverState = value; }
    public int FeverStack 
    { 
        get => _feverStack; 
        set
        {
            _feverStack = Mathf.Clamp(value, 1, _feverStackMax);
        }
    }
    public int FeverStackMAX { get => _feverStackMax; }

    [SerializeField] private GameObject _comboVFX;

    protected override void Awake()
    {
        base.Awake();
        _currentCombo = 49;
    }
    public void HitSuccess(int score)
    {
        CurrentCombo++;
        MaxCombo = Mathf.Max(CurrentCombo, MaxCombo);
        if (_isFeverState) _currentScore += score * _feverStack;
        else _currentScore += score;

        UI_Game.Instance.RefreshScore(_currentScore);
        UI_Game.Instance.RefreshCombo(_currentCombo);
    }
    public void HitFail()
    {
        CurrentCombo = 0;
        _feverStack = 1;
        UI_Game.Instance.RefreshCombo(_currentCombo);
    }
    public void ActivateComboVFX()
    {
        if (!ReferenceEquals(_comboVFX, null))
        {
            Instantiate(_comboVFX);
        }
    }
}
