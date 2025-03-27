using UnityEngine;

public class NotePool : ObjectPool<NoteType, Note>
{
    protected override void Awake()
    {
        base.Awake();
    }
}
