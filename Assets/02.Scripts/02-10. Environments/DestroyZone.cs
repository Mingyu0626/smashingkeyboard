using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(nameof(Tags.Note)))
        {
            Note note = other.GetComponent<Note>();
            note.MissNote();
            NoteManager.Instance.OnNoteMissed?.Invoke();
            NotePool.Instance.ReturnObject(note);
        }
    }
}
