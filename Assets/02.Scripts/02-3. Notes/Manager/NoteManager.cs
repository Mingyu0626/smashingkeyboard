using System;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : Singleton<NoteManager>
{
    public delegate void NoteMissHandler();
    public NoteMissHandler OnNoteMissed;

    private SortedDictionary<string, List<GameObject>> _noteDictionary 
        = new SortedDictionary<string, List<GameObject>>();

    protected override void Awake()
    {
        base.Awake();
    }

    public void AddNote(string key, GameObject obj)
    {
        if (!_noteDictionary.ContainsKey(key))
        {
            _noteDictionary[key] = new List<GameObject>();
        }

        _noteDictionary[key].Add(obj);
    }

    public GameObject GetNearestNote(string key)
    {
        if (_noteDictionary.ContainsKey(key))
        {
            _noteDictionary[key].Sort(CompareByXPosition);
            if (_noteDictionary[key].Count == 0)
            {
                return null;
            }
            GameObject nearestNote = _noteDictionary[key][_noteDictionary[key].Count - 1];
            _noteDictionary[key].RemoveAt(_noteDictionary[key].Count - 1);
            return nearestNote;
        }
        return null;
    }

    public void DeleteNotesInList(string key)
    {
        _noteDictionary[key].Sort(CompareByXPosition);
        if (_noteDictionary[key].Count == 0)
        {
            return;
        }
        GameObject nearestNote = _noteDictionary[key][_noteDictionary[key].Count - 1];
        _noteDictionary[key].RemoveAt(_noteDictionary[key].Count - 1);
    }

    private int CompareByXPosition(GameObject a, GameObject b)
    {
        float diff = a.transform.position.x - b.transform.position.x;
        if (diff > 0) return -1;
        if (diff < 0) return 1;   
        return 0;                  
    }
}
