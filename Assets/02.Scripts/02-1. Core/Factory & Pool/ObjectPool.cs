using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IPoolAble
{
    public void Init();
}

public class ObjectPool<EnumType, ScriptType> : Singleton<ObjectPool<EnumType, ScriptType>> where ScriptType : MonoBehaviour, IProduct
{
    [System.Serializable]
    public class ObjectInfo
    {
        public EnumType ObjectEnumType; // ������ ������Ʈ�� �̳� Ÿ��
        public ScriptType ObjectScriptType; // ������ ������Ʈ�� ��ũ��Ʈ Ÿ��
        public int Count; // �̸� ������ ������Ʈ ����
    }

    [SerializeField] private ObjectInfo[] _objectInfos;
    public ObjectInfo[] ObjectInfos { get => _objectInfos; set => _objectInfos = value; }

    // ������Ʈ ����Ʈ Ǯ���� ���� Dictionary
    private Dictionary<EnumType, List<ScriptType>> _objectPoolDic = new Dictionary<EnumType, List<ScriptType>>();

    // ObjectType�� GO�� �����ϴ� ���丮
    [SerializeField] protected Factory<ScriptType> _factory;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    void Init()
    {
        for (int i = 0; i < _objectInfos.Length; i++)
        {
            EnumType objectEnumType = _objectInfos[i].ObjectEnumType;
            if (_objectPoolDic.ContainsKey(objectEnumType))
            {
                Debug.LogFormat("{0}�� �̹� ��ϵ� ������Ʈ�Դϴ�.", objectEnumType);
                return;
            }

            // ListPool���� ����Ʈ ��������
            List<ScriptType> objectList = ListPool<ScriptType>.Get();
            _objectPoolDic.Add(objectEnumType, objectList);

            // ������Ʈ �̸� ���� �� ����Ʈ�� �߰�
            for (int j = 0; j < _objectInfos[i].Count; j++)
            {
                ScriptType obj = _factory.GetProduct(_objectInfos[i].ObjectScriptType.gameObject, transform.position);
                obj.transform.SetParent(this.transform);
                obj.gameObject.SetActive(false);
                objectList.Add(obj);
            }
        }
    }

    public ScriptType GetObject(EnumType enumType, Vector3 position)
    {
        if (!_objectPoolDic.ContainsKey(enumType))
        {
            Debug.LogFormat("{0}�� ������ƮǮ�� ��ϵ��� ���� ������Ʈ�Դϴ�.", enumType);
            return null;
        }

        List<ScriptType> objectList = _objectPoolDic[enumType];

        // ����Ʈ���� ��Ȱ��ȭ�� ������Ʈ ã��
        foreach (ScriptType obj in objectList)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.Init();
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        // ��� ������Ʈ�� ��� ���̶��, ��ü �ϳ� ���� �� ����Ʈ�� �߰�.
        ScriptType newObj = _factory.GetProduct(_objectPoolDic[enumType][0].gameObject, transform.position);
        newObj.transform.SetParent(this.transform);
        newObj.transform.position = position;
        newObj.Init();
        newObj.gameObject.SetActive(true);
        objectList.Add(newObj);  
        return newObj;
    }

    public void ReturnObject(ScriptType obj)
    {
        obj.gameObject.SetActive(false);
    }

    public void ReturnAllActiveObjectsToPool()
    {
        foreach (var kvp in _objectPoolDic)
        {
            List<ScriptType> objectList = kvp.Value;

            foreach (ScriptType obj in objectList)
            {
                obj.gameObject.SetActive(false);
            }

            // ����Ʈ�� �ٽ� Ǯ�� ��ȯ
            objectList.Clear();
            ListPool<ScriptType>.Release(objectList);
        }

        _objectPoolDic.Clear();
    }
    public bool CheckTypeInPool(EnumType enumType)
    {
        return _objectPoolDic.ContainsKey(enumType);
    }
}
