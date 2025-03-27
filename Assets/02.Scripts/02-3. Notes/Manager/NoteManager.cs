using UnityEngine;

public class NoteManager : Singleton<NoteManager>
{
    public delegate void NoteMissHandler();
    public NoteMissHandler onNoteMissed;
    protected override void Awake()
    {
        base.Awake();
    }
}
