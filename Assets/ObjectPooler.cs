﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolClass
{
	[SerializeField] public string objectName;
	[SerializeField] public GameObject objectPrefab;
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

	[SerializeField] public List<PoolClass> itemsToPool;

	List<List<GameObject>> pooledObjectsList;
	List<GameObject> pooledObjects;
	List<int> positions;

	[SerializeField] Transform parentTransform;

	void Awake()
	{

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


	public GameObject GetPooledObject(int index)
	{

		int curSize = pooledObjectsList[index].Count;
		for (int i = positions[index] + 1; i < positions[index] + pooledObjectsList[index].Count; i++)
		{

			if (!pooledObjectsList[index][i % curSize].activeInHierarchy)
			{
				positions[index] = i % curSize;
				return pooledObjectsList[index][i % curSize];
			}
		}
		return null;
	}


	void ObjectPoolItemToPooledObject(int index)
	{
		PoolClass item = itemsToPool[index];

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
	
	public GameObject GetPooledObject(int objIndex,int itemIndex)
	{
		return pooledObjectsList[objIndex][itemIndex];
	}
}
