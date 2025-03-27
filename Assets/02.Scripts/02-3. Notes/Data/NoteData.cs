using UnityEngine;


[CreateAssetMenu(fileName = "NoteDataSO", menuName = "Scriptable Objects/NoteDataSO")]
public class NoteData : ScriptableObject
{
    public NoteType NoteType;
    public string CorrectInput;
    public int Score;
    public int EarnableHealthPoint;
    public int LoseableHealthPoint;
    public int EarnableFeverGauge;
    public int LoseableFeverGauge;
}
