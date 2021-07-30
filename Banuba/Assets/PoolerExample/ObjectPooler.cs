using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{

	public GameObject objectToPool;
	public int amountToPool = 2;
	public bool shouldExpand = true;

}

public class ObjectPooler : MonoBehaviour
{
	public static ObjectPooler SharedInstance;
	public List<ObjectPoolItem> itemsToPool;//лист обьектов по сериализованному выше классу

	//public List<List<List<GameObject>>> quadrat;
	//public List<GameObject> oneQuadrat;
	public List<List<GameObject>> pooledObjectsList;
	public List<GameObject> pooledObjects;
	private List<int> positions;
	//GameObject tempObj;
	void Awake()
	{

		SharedInstance = this;

		//quadrat = new List<List<List<GameObject>>>(); //это трёхмерный массив 
		pooledObjectsList = new List<List<GameObject>>();//это как двухмерный массив объектов
		pooledObjects = new List<GameObject>(); // отвечает за кол-во обьектов LINE_1 в пуле
		foreach (ObjectPoolItem item in itemsToPool)//itemesToPool лист в инспекторе сформированный через Drag & Drop
		{
			//for (int j = 0; j < oneQuadrat.Count; j++)
			//{
			//    tempObj=item.objectToPool.transform.GetChild(0).gameObject;


				pooledObjects = new List<GameObject>();
				for (int i = 0; i < item.amountToPool; i++) //перебираю itemToPool
				{
					GameObject obj = (GameObject)Instantiate(item.objectToPool);//создаю новый объект - инициализирую его членом GameObject objectPool сериализованного выше класса ObjectPoolItem, который является типои листа itemsToPool.
					obj.SetActive(false);
					obj.transform.parent = this.transform;
					pooledObjects.Add(obj);//добавляю все элементы(изначальено 2 одинаковых создаются через код) из itemsToPool в одномерный лист
				}
				pooledObjectsList.Add(pooledObjects);// формирую двумерный лист... зачем???? - разобрался

			//}
		}
		positions = new List<int>();
		for (int i = 0; i < pooledObjectsList.Count; i++)
		{
			positions.Add(0);// создаю пустой лист нулей, он нужен будет для того чтобы поменять положение обьекта в иерархии (в инспекторе)
		}
	}



	public GameObject GetPooledObject(int index)
	{

		int curSize = pooledObjectsList[index].Count;

		//возвращает в скрипт MakeBall существующий элемент и там делает его активным
		//part 111111111
		for (int i = positions[index] + 1; i < positions[index] + pooledObjectsList[index].Count; i++)
		{

			if (!pooledObjectsList[index][i % curSize].activeInHierarchy)
			{
				positions[index] = i % curSize;
				return pooledObjectsList[index][i % curSize]; 
				//так, здесь только возвращается обьект - махинации с ним лучше делать либо перед return либо в том месте, куда он возвр.
			}
		}

		//создаёт и добавляет в пул новый объект ------ а затем возвращает его в скрипт MakeBall
		//part 222222222
		if (itemsToPool[index].shouldExpand)
		{

			GameObject obj = (GameObject)Instantiate(itemsToPool[index].objectToPool);
			obj.SetActive(false);
			obj.transform.parent = this.transform;
			pooledObjectsList[index].Add(obj);
			return obj;

		}//у меня этот метод постоянно должен возвращать полоску, и в конце обоих методов part 1 И 2 будет вызываться метод
		 //которыый делает один квадрат из Line не активным - SetActive(false) 
		 //Не активным будет квадрат в промежутке(--i,++i) для каждого Line
		return null;
	}

	public List<GameObject> GetAllPooledObjects(int index)
	{
		return pooledObjectsList[index];
	}
}
