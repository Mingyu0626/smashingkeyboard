using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NoteSpawnProbability
{
    private NoteType _noteType;
    private int _probability;
    public NoteType NoteType { get => _noteType; set => _noteType = value; }
    public int Probability { get => _probability; set => _probability = value; }
    public NoteSpawnProbability(NoteType noteType, int probability)
    {
        _noteType = noteType;
        _probability = probability;
    }
}

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private float _delayMin;
    [SerializeField] private float _delayMax;
    [SerializeField] private int _level;
    [SerializeField] private NoteFactory _noteFactory;

    private List<List<NoteSpawnProbability>> _noteSpawnInfos = new List<List<NoteSpawnProbability>>()
    {
        new List<NoteSpawnProbability>()
        {
            new NoteSpawnProbability(NoteType.A, 25),
            new NoteSpawnProbability(NoteType.S, 25),
            new NoteSpawnProbability(NoteType.SemiColon, 25),
            new NoteSpawnProbability(NoteType.Quote, 25),
        },
        new List<NoteSpawnProbability>()
        {
            new NoteSpawnProbability(NoteType.D, 50),
            new NoteSpawnProbability(NoteType.L, 50),
        },
        new List<NoteSpawnProbability>()
        {
            new NoteSpawnProbability(NoteType.LeftShift, 50),
            new NoteSpawnProbability(NoteType.RightShift, 50),
        },
    };

    private void OnEnable()
    {
        StartCoroutine(Spawn());

    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetRandomSpawnIntervalTime());
            Note note = NotePool.Instance.GetObject(GetNextSpawnNote(), transform.position);
        }
    }
    private float GetRandomSpawnIntervalTime()
    {
        return Random.Range(_delayMin, _delayMax);
    }
    private NoteType GetNextSpawnNote()
    {
        int randNum = Random.Range(0, 100);
        int probabilityPrefixSum = 0, enemyIndex = 0;
        foreach (NoteSpawnProbability info in _noteSpawnInfos[_level - 1])
        {
            probabilityPrefixSum += info.Probability;
            if (randNum < probabilityPrefixSum)
            {
                return info.NoteType;
            }
            enemyIndex++;
        }
        return NoteType.A;
    }
}
