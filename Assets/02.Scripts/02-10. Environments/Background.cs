using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // 배경 스크롤링 : 배경 이미지를 일정한 속도로 움직여, 캐릭터나 몬스터 등의 움직임을 더 동적으로
    // 만들어주는 기술, 캐릭터는 그대로 두고 배경만 움직이는 '눈속임'
    [SerializeField] private List<BackgroundData> _backgroundDatas;
    [SerializeField] private float _speedIncreaseAmount;
    public List<BackgroundData> BackgroundDatas { get => _backgroundDatas; set => _backgroundDatas = value; }

    private void Awake()
    {

    }

    private void Update()
    {
        ScrollBackGround();
    }

    private float x, y;
    private void ScrollBackGround()
    {
        foreach (BackgroundData backgroundData in BackgroundDatas)
        {
            backgroundData.BackgroundRawImage.uvRect
                = new Rect
                (backgroundData.BackgroundRawImage.uvRect.position 
                + new Vector2(backgroundData.ScrollSpeed, 0f)
                * Time.deltaTime, backgroundData.BackgroundRawImage.uvRect.size);
        }
    }

    public void ScrollSpeedUp()
    {
        foreach (BackgroundData backgroundData in BackgroundDatas)
        {
            backgroundData.ScrollSpeed *= _speedIncreaseAmount;
        }
    }
    public void ScrollSpeedDown()
    {
        foreach (BackgroundData backgroundData in BackgroundDatas)
        {
            backgroundData.ScrollSpeed /= _speedIncreaseAmount;
        }
    }
}

[System.Serializable]
public class BackgroundData
{
    [SerializeField] private RawImage _backgroundRawImage;
    [SerializeField] private float _scrollSpeed;
    private Vector2 _offset;
    public RawImage BackgroundRawImage { get => _backgroundRawImage; set => _backgroundRawImage = value; }
    public float ScrollSpeed { get => _scrollSpeed; set => _scrollSpeed = value; }
    public Vector2 Offset { get => _offset; set => _offset = value; }
}
