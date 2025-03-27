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
    [SerializeField] private NoteFactory _noteFactory;

    private List<NoteSpawnProbability> _noteSpawnInfos = new List<NoteSpawnProbability>()
    {
        new NoteSpawnProbability(NoteType.Chip, 100)
    };

    private void OnEnable()
    {
        StartCoroutine(Spawn());

    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            Note note = NotePool.Instance.GetObject(GetNextSpawnNote(), transform.position);
            yield return new WaitForSeconds(GetRandomSpawnIntervalTime());
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
        foreach (NoteSpawnProbability info in _noteSpawnInfos)
        {
            probabilityPrefixSum += info.Probability;
            if (randNum < probabilityPrefixSum)
            {
                return info.NoteType;
            }
            enemyIndex++;
        }
        return NoteType.Chip;
    }
}
