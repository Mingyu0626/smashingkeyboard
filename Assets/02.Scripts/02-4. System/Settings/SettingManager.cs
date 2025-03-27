using UnityEngine;

public class SettingManager : Singleton<SettingManager>
{
    [SerializeField] private float _noteSpeed = 1f;
    private const float _minNoteSpeed = 1f;
    private const float _maxNoteSpeed = 10f;
    public float NoteSpeed 
    { 
        get => _noteSpeed; 
        set
        {
            _noteSpeed = Mathf.Clamp(value, _minNoteSpeed, _maxNoteSpeed);
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        
    }
}
