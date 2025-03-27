using UnityEngine;

public class NotePool : ObjectPool<NoteType, Note>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public void MissNote(int loseableHealthPoint, int loseableFeverGauge)
    {
        Player.Instance.PlayerData.CurrentHealthPoint -= loseableHealthPoint;
        Player.Instance.PlayerData.FeverGage -= loseableFeverGauge;
    }

    public void HitNote(int score, int earnableHealthPoint, int earnableFeverGauge)
    {
        ScoreManager.Instance.CurrentScore += score;
        Player.Instance.PlayerData.CurrentHealthPoint += earnableHealthPoint;
        Player.Instance.PlayerData.FeverGage += earnableFeverGauge;
    }
}
