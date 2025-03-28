using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UI_Game : Singleton<UI_Game>
{
    [SerializeField] private float _refreshDelay;
    [SerializeField] private GameObject _hpBarGO;
    [SerializeField] private GameObject _feverBarGO;
    private Slider _hpBarSlider;
    private Slider _feverBarSlider;
    private Image _hpBarImage;
    private Image _feverBarImage;

    [SerializeField] private TextMeshProUGUI _comboText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    [Header("Combo Animation")]
    [SerializeField] private GameObject _panelCombo;
    private Vector3 _panelComboOriginalPosition;
    [SerializeField] private float _panelMovingDistance = 1480f;
    [SerializeField] private float _animationMoveTime = 0.1f;
    [SerializeField] private float _animationCenterDelayTime = 1f;

    protected override void Awake()
    {
        base.Awake();
        _hpBarSlider = _hpBarGO.GetComponent<Slider>();
        _feverBarSlider = _feverBarGO.GetComponent<Slider>();
    }
    private void Start()
    {
        InitBarUI(Player.Instance.PlayerData.MaxHealthPoint);
        _panelComboOriginalPosition = _panelCombo.GetComponent<RectTransform>().position;
    }
    public void InitBarUI(int maxHP)
    {
        _hpBarSlider.maxValue = maxHP;
        _hpBarSlider.value = maxHP;
        _feverBarSlider.maxValue = 100;
        _feverBarSlider.value = 0;
    }
    public void RefreshBarUI(int hp, int feverGauge)
    {
        RefreshBarValue(hp, _hpBarSlider);
        RefreshBarValue(feverGauge, _feverBarSlider);
    }
    private void RefreshBarValue(int hp, Slider slider)
    {
        slider.DOValue(hp, _refreshDelay).SetEase(Ease.Linear);
    }
    public void SetBarUIEnable(bool val)
    {
        _hpBarGO.gameObject.SetActive(val);
        _feverBarGO.gameObject.SetActive(val);
    }
    public void RefreshScore(int score)
    {
        _scoreText.text = $"Score : {score:N0}";
        _scoreText.rectTransform.DOScale(new Vector3(1.4f, 1.4f, 1.4f), 0.08f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                _scoreText.rectTransform.localScale = Vector3.one;
            });
    }
    public void RefreshCombo(int combo)
    {
        _comboText.text = $"X{combo:N0}";
        _comboText.rectTransform.DOScale(new Vector3(1.4f, 1.4f, 1.4f), 0.08f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                _comboText.rectTransform.localScale = Vector3.one;
            });
    }
    public void ComboAnimation(int combo)
    {
        _panelCombo.SetActive(true);
        RectTransform rectTransform = _panelCombo.GetComponent<RectTransform>();
        rectTransform.DOAnchorPosX(rectTransform.anchoredPosition.x + _panelMovingDistance, _animationMoveTime)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                rectTransform.DOAnchorPosX(rectTransform.anchoredPosition.x + 40f, _animationCenterDelayTime)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    rectTransform.DOAnchorPosX(rectTransform.anchoredPosition.x + _panelMovingDistance, _animationMoveTime)
                    .SetEase(Ease.Linear)
                    .OnComplete(() =>
                    {
                        _panelCombo.SetActive(false);
                        rectTransform.position = _panelComboOriginalPosition;
                    });
                });

            });
    }
}
