using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    private PlayerData _playerData;
    [SerializeField] private GameObject _feverVFX;
    [SerializeField] private float _feverDuration;
    private void Awake()
    {
        _playerData = GetComponent<PlayerData>();
    }
    private void Update()
    {
    }
    public void TryActivateFever()
    {
        if (CanActivateFever())
        {
            StartCoroutine(ActivateFever());
        }
    }
    private bool CanActivateFever()
    {
        return Player.Instance.PlayerData.FeverGauge == Player.Instance.PlayerData.FeverGuageMax;
    }
    public IEnumerator ActivateFever()
    {
        GameObject feverVFX = Instantiate(_feverVFX, transform);
        feverVFX.transform.position += new Vector3(0f, 2f, 0f);
        Player.Instance.PlayerData.FeverGauge = 0;
        UI_Game.Instance.RefreshBarUI
            (Player.Instance.PlayerData.CurrentHealthPoint,
            Player.Instance.PlayerData.FeverGauge);
        ScoreManager.Instance.FeverStack++;
        Player.Instance.PlayFeverAnimation();
        ScoreManager.Instance.IsFeverState = true;
        yield return new WaitForSeconds(_feverDuration);
        ScoreManager.Instance.IsFeverState = false;
        Player.Instance.StopFeverAnimation();
        Destroy(feverVFX);
    }
}
