using UnityEngine;

public class Note : MonoBehaviour, IProduct
{
    [SerializeField] private NoteData _noteData;
    [SerializeField] private GameObject _noteVFX;
    public NoteData NoteData { get => _noteData; set => _noteData = value; }

    public void Init()
    {
        NoteManager.Instance.AddNote(_noteData.CorrectInput, gameObject);
    }
    public void MissNote()
    {
        Player.Instance.DecreaseStat
            (_noteData.LoseableHealthPoint, _noteData.LoseableFeverGauge);
        ScoreManager.Instance.HitFail();
        NotePool.Instance.ReturnObject(this);
    }
    public void HitNote()
    {
        ScoreManager.Instance.CurrentScore += _noteData.Score;
        Player.Instance.IncreaseStat
            (_noteData.EarnableHealthPoint, _noteData.EarnableFeverGauge);
        ScoreManager.Instance.HitSuccess(_noteData.Score);
        Instantiate(_noteVFX, transform.position, transform.rotation);
        NotePool.Instance.ReturnObject(this);
    }
}
