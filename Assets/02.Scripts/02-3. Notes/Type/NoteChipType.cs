using UnityEngine;

public class NoteChipType : Note
{

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Debug.Log("Move 메서드 호출");
        Vector2 directionVector = Vector2.left;
        transform.position +=
            (Vector3)(directionVector * SettingManager.Instance.NoteSpeed
            * Time.deltaTime);
    }
}
