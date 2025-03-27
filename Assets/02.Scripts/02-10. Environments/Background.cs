using System.Collections.Generic;
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
        foreach (BackgroundData backgroundData in BackgroundDatas)
        {
            backgroundData.Renderer = backgroundData.BackgroundGO.GetComponent<Renderer>();
            backgroundData.MaterialPropertyBlock = new MaterialPropertyBlock();
        }
    }

    private void Update()
    {
        ScrollBackGround();
    }

    private void ScrollBackGround()
    {
        foreach (BackgroundData backgroundData in BackgroundDatas)
        {
            // ������ ���ϰ�, �ش� �������� ��ũ�Ѹ� �Ѵ�.
            Vector2 direction = Vector2.right;
            backgroundData.Offset += direction * backgroundData.ScrollSpeed * Time.deltaTime;

            // MPB�� ���氪�� ���, Renderer�� Material�� �ش� MPB�� �����Ѵ�.
            backgroundData.MaterialPropertyBlock.SetVector("_MainTex_ST",
            new Vector4(1, 1, backgroundData.Offset.x, backgroundData.Offset.y));
            backgroundData.Renderer.SetPropertyBlock(backgroundData.MaterialPropertyBlock);
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
    [SerializeField] private GameObject _backgroundGO;
    [SerializeField] private float _scrollSpeed;
    private Vector2 _offset;
    private Renderer _renderer;
    private MaterialPropertyBlock _materialPropertyBlock;
    public GameObject BackgroundGO { get => _backgroundGO; set => _backgroundGO = value; }
    public float ScrollSpeed { get => _scrollSpeed; set => _scrollSpeed = value; }
    public Vector2 Offset { get => _offset; set => _offset = value; }
    public Renderer Renderer { get => _renderer; set => _renderer = value; }
    public MaterialPropertyBlock MaterialPropertyBlock { get => _materialPropertyBlock; set => _materialPropertyBlock = value; }
}
