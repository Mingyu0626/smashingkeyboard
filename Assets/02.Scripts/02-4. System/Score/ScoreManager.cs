using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int _currentScore;
    private int _currentCombo;
    private int _maxCombo;
    private bool _isFeverState = false;
    private int _feverStack = 0;
    private const int _feverStackMax = 4;
    [SerializeField] private GameObject _comboVFX;
    [SerializeField] private AudioSource _audioSourceCombo;
    public int CurrentScore 
    { 
        get => _currentScore; 
        set
        {   
            _currentScore = value;
            if ((5000 <= _currentScore && LevelManager.Instance.CurrentLevel == 1) 
                || (30000 <= _currentScore && LevelManager.Instance.CurrentLevel == 2))
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
            if (_isFeverState && value != 0)
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
                UI_Game.Instance.ComboPanelSlide(_currentCombo);
                _audioSourceCombo.Play();
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
    protected override void Awake()
    {
        base.Awake();
    }
    public void HitSuccess(int score)
    {
        CurrentCombo++;
        MaxCombo = Mathf.Max(CurrentCombo, MaxCombo);
        if (_isFeverState) CurrentScore += score * _feverStack;
        else CurrentScore += score;

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
