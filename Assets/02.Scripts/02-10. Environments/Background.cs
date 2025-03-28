using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // ��� ��ũ�Ѹ� : ��� �̹����� ������ �ӵ��� ������, ĳ���ͳ� ���� ���� �������� �� ��������
    // ������ִ� ���, ĳ���ʹ� �״�� �ΰ� ��游 �����̴� '������'
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
