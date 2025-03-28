using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    private int _currentLevel = 1;
    public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
    private const int _maxLevel = 3;
    public int MaxLevel { get => _maxLevel; }

    [SerializeField] private List<NoteSpawner> _spawnerList = new List<NoteSpawner>();

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        ActivateSpawner();
    }

    public void ActivateSpawner()
    {
        foreach (NoteSpawner spawner in _spawnerList)
        {
            if (spawner.MinLevelToActivate == _currentLevel)
            {
                spawner.gameObject.SetActive(true);
            }
        }
    }
    public void LevelUp()
    {
        _currentLevel++;
    }
    
}
