using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private PlayerData _playerData;
    public PlayerData PlayerData { get => _playerData; set => _playerData = value; }

    private void Awake()
    {
        if (Instance != null)
        {
            Instance = null;
            Destroy(Instance.gameObject);
        }
        Instance = this;
        PlayerData = GetComponent<PlayerData>();
    }
    private void Start()
    {
        
    }
    public void IncreaseStat(int earnableHealthPoint, int earnableFeverGauge)
    {
        _playerData.CurrentHealthPoint += earnableHealthPoint;
        _playerData.FeverGage += earnableFeverGauge;
    }
    public void DecreaseStat(int loseableHealthPoint, int loseableFeverGauge)
    {
        _playerData.CurrentHealthPoint += loseableHealthPoint;
        _playerData.FeverGage += loseableFeverGauge;
    }
}
