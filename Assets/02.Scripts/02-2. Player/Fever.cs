using UnityEngine;

public class Fever : MonoBehaviour
{
    private PlayerData _playerData;
    [SerializeField] private GameObject _feverVFX;
    private void Awake()
    {
        _playerData = GetComponent<PlayerData>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            TryActivateFever();
        }
    }
    public void TryActivateFever()
    {
        if (CanActivateFever())
        {
            Instantiate(_feverVFX);
            Player.Instance.PlayerData.FeverGauge = 0;
            UI_Game.Instance.RefreshBarUI
                (Player.Instance.PlayerData.CurrentHealthPoint,
                Player.Instance.PlayerData.FeverGauge);
            ScoreManager.Instance.FeverMultiple++;
        }
    }
    private bool CanActivateFever()
    {
        return Player.Instance.PlayerData.FeverGauge == Player.Instance.PlayerData.FeverGuageMax;
    }
}
