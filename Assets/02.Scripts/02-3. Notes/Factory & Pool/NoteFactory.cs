using UnityEngine;

public enum NoteType
{
    Chip,
    Long,
    Trill
}

public class NoteFactory : Factory<Note>
{
    public override Note GetProduct(GameObject productGO, Vector3 position)
    {
        return Instantiate(productGO, position, Quaternion.identity)
            .GetComponent<Note> ();
    }
}
