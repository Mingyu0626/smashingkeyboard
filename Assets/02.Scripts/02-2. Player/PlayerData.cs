using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _maxHealthPoint;
    [SerializeField] private int _currentHealthPoint;
    [SerializeField] private int _feverGauge;
    private const int _feverGaugeMax = 100;
    [SerializeField] private GameObject _hitSuccessVFX;
    [SerializeField] private GameObject _hitFailVFX;
    [SerializeField] private Transform _vfxTransform;
    [SerializeField] private AudioSource _audioSourceFeverReady;
    [SerializeField] private List<AudioClip> _hitClips = new List<AudioClip>();
    private int _hitClipIndex;
    public int MaxHealthPoint { get => _maxHealthPoint;}
    public int CurrentHealthPoint 
    { 
        get => _currentHealthPoint;
        set => _currentHealthPoint = Mathf.Clamp(value, 0, _maxHealthPoint);
    }
    public int FeverGauge 
    { 
        get => _feverGauge;
        set
        {
            if (value == _feverGaugeMax)
            {
                UI_Game.Instance.FeverReadyPanelOn();
                _audioSourceFeverReady.Play();
            }
            _feverGauge = Mathf.Clamp(value, 0, _feverGaugeMax);
        }
    }

    public int FeverGuageMax { get => _feverGaugeMax; }
    public GameObject HitSuccessVFX { get => _hitSuccessVFX; }
    public GameObject HitFailVFX { get => _hitFailVFX; }
    public Transform VFXTransform { get => _vfxTransform; }
    public List<AudioClip> HitClips { get => _hitClips; set => _hitClips = value; }
    public int HitClipIndex 
    { 
        get => _hitClipIndex; 
        set => _hitClipIndex = value % _hitClips.Count; 
    }
}
