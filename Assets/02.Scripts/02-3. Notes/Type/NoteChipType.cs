using UnityEngine;

public class NoteChipType : Note
{

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 directionVector = Vector2.left;
        transform.position +=
            (Vector3)(directionVector * SettingManager.Instance.NoteSpeed
            * Time.deltaTime);
    }
}
