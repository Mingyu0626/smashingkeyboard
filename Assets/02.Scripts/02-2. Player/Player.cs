using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private PlayerData _playerData;
    public PlayerData PlayerData { get => _playerData; set => _playerData = value; }
    private PlayerInput _playerInput;
    public PlayerInput PlayerInput { get => _playerInput; set => _playerInput = value; }

    private void Awake()
    {
        if (Instance != null)
        {
            Instance = null;
            Destroy(Instance.gameObject);
        }
        Instance = this;
        _playerData = GetComponent<PlayerData>();
        _playerData.CurrentHealthPoint = _playerData.MaxHealthPoint;
        _playerInput = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        
    }
    public void IncreaseStat(int earnableHealthPoint, int earnableFeverGauge)
    {
        _playerData.CurrentHealthPoint += earnableHealthPoint;
        _playerData.FeverGauge += earnableFeverGauge;
        Instantiate(_playerData.HitSuccessVFX, _playerData.VFXTransform.position,
            _playerData.VFXTransform.rotation);
        UI_Game.Instance.RefreshBarUI(_playerData.CurrentHealthPoint, _playerData.FeverGauge);
    }
    public void DecreaseStat(int loseableHealthPoint, int loseableFeverGauge)
    {
        _playerData.CurrentHealthPoint -= loseableHealthPoint;
        _playerData.FeverGauge -= loseableFeverGauge;
        Instantiate(_playerData.HitFailVFX, gameObject.transform.position + new Vector3(0f, 2f, 0f),
            gameObject.transform.rotation);
        PlayerHitFailAnimation();
        UI_Game.Instance.RefreshBarUI(_playerData.CurrentHealthPoint, _playerData.FeverGauge);
    }
    private void PlayerHitFailAnimation()
    {
        _playerInput.Animator.SetTrigger("HitFail");
    }
}
