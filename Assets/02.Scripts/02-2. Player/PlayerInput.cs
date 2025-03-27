using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private Dictionary<int, string> _hitAnimations = new Dictionary<int, string>
    {
        {0, "LeftPunch"},
        {1, "Kick" }
    };
    private int animateCount;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            animateCount++;
            _animator.SetTrigger(_hitAnimations[animateCount % _hitAnimations.Count]);

            string pressedKey = Input.inputString.ToUpper();
            Debug.Log(pressedKey);
            GameObject nearestNote = NoteManager.Instance.GetNearestNote(pressedKey);
            if (!ReferenceEquals(nearestNote, null))
            {
                Note note = nearestNote.GetComponent<Note>();
                note.HitNote();
            }
        }
    }
}
