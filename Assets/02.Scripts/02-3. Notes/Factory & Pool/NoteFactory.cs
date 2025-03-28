using UnityEngine;

public enum NoteType
{
    A,
    S,
    SemiColon,
    Quote,
    D,
    L,
    Shift,



    Count
}

public class NoteFactory : Factory<Note>
{
    public override Note GetProduct(GameObject productGO, Vector3 position)
    {
        return Instantiate(productGO, position, Quaternion.identity)
            .GetComponent<Note> ();
    }
}
