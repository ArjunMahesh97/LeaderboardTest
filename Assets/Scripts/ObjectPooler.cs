using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolClass
{
	[SerializeField] public string objectName;
	public GameObject objectPrefab;
	[SerializeField] public int size;

	public PoolClass(string objName, GameObject obj, int objSize)
	{
		objectName = objName;
		objectPrefab = obj;
		size = objSize;
	}
}


public class ObjectPooler : MonoBehaviour
{
	LoadAssetBundles bundleLoader;

	[SerializeField] public List<PoolClass> itemsToPool;
	[SerializeField] string loadAssetName;

	List<List<GameObject>> pooledObjectsList;
	List<GameObject> pooledObjects;
	List<int> positions;

	[SerializeField] Transform parentTransform;

	void Awake()
	{
		bundleLoader = FindObjectOfType<LoadAssetBundles>().GetComponent<LoadAssetBundles>();

		pooledObjectsList = new List<List<GameObject>>();
		pooledObjects = new List<GameObject>();
		positions = new List<int>();


		for (int i = 0; i < itemsToPool.Count; i++)
		{
			ObjectPoolItemToPooledObject(i);
		}

	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	public GameObject GetPooledObject(int poolIndex,int itemIndex)
	{
		return pooledObjectsList[poolIndex][itemIndex];
	}


	void ObjectPoolItemToPooledObject(int index)
	{
		PoolClass item = itemsToPool[index];
		if (item.objectPrefab == null)
		{
			item.objectPrefab = bundleLoader.GetObjectFromBundle(loadAssetName);
		}

		pooledObjects = new List<GameObject>();
		for (int i = 0; i < item.size; i++)
		{
			GameObject obj = (GameObject)Instantiate(item.objectPrefab);
			obj.SetActive(false);
			obj.transform.parent = parentTransform;
			pooledObjects.Add(obj);
		}
		pooledObjectsList.Add(pooledObjects);
		positions.Add(0);

	}

	public List<GameObject> GetAllPooledObjects(int index)
	{
		return pooledObjectsList[index];
	}	
}
