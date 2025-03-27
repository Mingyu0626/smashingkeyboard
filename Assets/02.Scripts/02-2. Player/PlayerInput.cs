using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Animator _animator;
    private Dictionary<int, string> _hitAnimations = new Dictionary<int, string>
    {
        {0, "LeftPunch"},
        {1, "Kick" }
    };
    private int _animateCount;

    private HashSet<string> _validInputSet = new HashSet<string>
    {
        // Lv1.
        { "A" },
        { "S" },
        { ";" },
        { "'" },

        // Lv2.
        { "D" },
        { "L" },

        // Lv3.
        { "LeftShift" },
        { "RightShift" },
    };

    public Animator Animator { get => _animator; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _animateCount++;
            _animator.SetTrigger(_hitAnimations[_animateCount % _hitAnimations.Count]);

            string pressedKey = Input.inputString.ToUpper();
            if (_validInputSet.Contains(pressedKey))
            {
                GameObject nearestNote = NoteManager.Instance.GetNearestNote(pressedKey);
                if (!ReferenceEquals(nearestNote, null))
                {
                    Note note = nearestNote.GetComponent<Note>();
                    note.HitNote();
                }
                return;
            }
        }
    }
}
