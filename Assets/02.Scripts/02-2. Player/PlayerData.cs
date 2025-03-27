using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _maxHealthPoint;
    [SerializeField] private int _currentHealthPoint;
    [SerializeField] private int _feverGage;

    public int MaxHealthPoint { get => _maxHealthPoint; set => _maxHealthPoint = value; }
    public int CurrentHealthPoint { get => _currentHealthPoint; set => _currentHealthPoint = value; }
    public int FeverGage { get => _feverGage; set => _feverGage = value; }
}
