using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(nameof(Tags.Note)))
        {
            Note note = other.GetComponent<Note>();
            ScoreManager.Instance.Fail();
            Player.Instance.PlayerData.CurrentHealthPoint 
                -= note.NoteData.LoseableHealthPoint;
            Player.Instance.PlayerData.FeverGage
                -= note.NoteData.LoseableFeverGauge;

            NoteManager.Instance.onNoteMissed?.Invoke();
            NotePool.Instance.ReturnObject(note);
        }
    }
}
