using UnityEngine;

public class Note : MonoBehaviour, IProduct
{
    [SerializeField] private NoteData _noteData;
    [SerializeField] private GameObject _noteVFX;
    [SerializeField] private MoveType _noteMoveType;
    public NoteData NoteData { get => _noteData; set => _noteData = value; }
    public MoveType NoteMoveType { get => _noteMoveType; set => _noteMoveType = value; }

    public void Init()
    {
        NoteManager.Instance.AddNote(_noteData.CorrectInput, gameObject);
        MoveType[] moveTypes = (MoveType[])System.Enum.GetValues(typeof(MoveType));
        int randomIndex = Random.Range(0, moveTypes.Length);
        _noteMoveType = moveTypes[randomIndex];
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
        Player.Instance.IncreaseStat
            (_noteData.EarnableHealthPoint, _noteData.EarnableFeverGauge);
        ScoreManager.Instance.HitSuccess(_noteData.Score);
        Instantiate(_noteVFX, transform.position, transform.rotation);
        NotePool.Instance.ReturnObject(this);
    }
}
