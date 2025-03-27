using UnityEngine;

public class Note : MonoBehaviour, IProduct
{
    [SerializeField] private string _correctStringInput;
    [SerializeField] private NoteData _noteData;
    public string CorrectStringInput { get => _correctStringInput; set => _correctStringInput = value; }
    public NoteData NoteData { get => _noteData; set => _noteData = value; }

    public void Init()
    {
        NoteManager.Instance.AddNote(_correctStringInput, gameObject);
    }
    public void MissNote()
    {
        Player.Instance.DecreaseStat
            (_noteData.LoseableHealthPoint, _noteData.LoseableFeverGauge);
        NotePool.Instance.ReturnObject(this);
    }
    public void HitNote()
    {
        ScoreManager.Instance.CurrentScore += _noteData.Score;
        Player.Instance.IncreaseStat
            (_noteData.EarnableHealthPoint, _noteData.EarnableFeverGauge);
        NotePool.Instance.ReturnObject(this);
    }
}
