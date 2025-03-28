using DG.Tweening;
using UnityEngine;

public enum MoveType
{
    Normal,
    Accel,
    Count
}

public class NoteNormalType : Note
{
    private Vector3 _targetPosition;
    [SerializeField] private float _moveDuration = 4f;

    private void OnEnable()
    {
        float targetY = Random.Range(0f, 7f);
        _targetPosition = Player.Instance.transform.position + new Vector3(0f, targetY, 0f);

        switch (NoteMoveType)
        {
            case MoveType.Normal:
                MoveNormal();
                break;
            case MoveType.Accel:
                MoveAccel();
                break;
            default:
                MoveNormal();
                break;
        }
    }
    private void Update()
    {
    }

    private void MoveNormal()
    {
        transform.DOMove(_targetPosition, _moveDuration)
            .SetEase(Ease.Linear);
    }
    private void MoveAccel()
    {
        transform.DOMove(_targetPosition, _moveDuration)
            .SetEase(Ease.InSine);
    }
}
