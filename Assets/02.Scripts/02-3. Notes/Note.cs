using UnityEngine;

public class Note : MonoBehaviour, IProduct
{
    [SerializeField] private Input _correctInput;
    [SerializeField] private NoteData _noteData;
    public Input CorrectInput { get => _correctInput; set => _correctInput = value; }
    public NoteData NoteData { get => _noteData; set => _noteData = value; }

    public void Init()
    {
        
    }
    private void Awake()
    {
        
    }
}
