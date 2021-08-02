using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeLine : MonoBehaviour {
	static int iForFalse=3;
	public int LineIndex = 0;
	private ObjectPooler OP;
	public Transform SpawnPoint;
	public Text textScore;

	public GameObject CrashBonus;
	public GameObject ScaleBonus;
	//int countOfBonus=2;

	
	private void Start()
	{
		OP = ObjectPooler.SharedInstance;
		
	}
	// Update is called once per frame
	void FixedUpdate ()
	{

        if (!gameStates.activeMenu)
        {
			StartCoroutine("toCreateLine");
		}
       

    }

        IEnumerator toCreateLine()
	{
		yield return new WaitForSeconds(0.6f);
		LineCreating();
		gameStates.Score++;
		textScore.text =gameStates.Score.ToString();
		StopCoroutine("toCreateLine");
	}


	bool firstFlag = true;
	bool rightFlag = true;
	bool aboveFlag = false;

	void LineCreating()
	{
		Random.InitState((int)System.DateTime.Now.Ticks);

		GameObject Line = OP.GetPooledObject(LineIndex);
		//GameObject Bonus = OP.GetPooledObject(Random.Range(1,countOfBonus));
		int a = 0;
		


		Line.transform.position = SpawnPoint.transform.position;

		//здесь я всех включаю
		Line.SetActive(true);
		for (int i = 0; i < Line.transform.childCount; i++)
		{
			Line.transform.GetChild(i).gameObject.SetActive(true);
		}
	
		//здесь я выборочно буду тушить
		while (a < Line.transform.childCount)
		{
			//if (aboveFlag) firstFlag = true;

			int b = iForFals(ref iForFalse);
			
			Line.transform.GetChild(b).gameObject.SetActive(false);

			CrashBonus.transform.position = Line.transform.GetChild(b).position;

			//if (Random.Range(0f, 1f) < 0.3f)
			//{
				
			//	CrashBonus.transform.position=Line.transform.GetChild(b).position;

			//}

			//Bonus.transform.position= Line.transform.GetChild(b).;

			if (aboveFlag) { break; }
			a++;
		}
		rightFlag = !rightFlag;
		firstFlag = true;
		aboveFlag = false;
	}

	int iForFals(ref int i)
    {
        if (firstFlag)
        {
			
			firstFlag = false;
			i= Mathf.Clamp(i, 1, 5);
			return i;
        }

		if (Random.Range(0f, 1f) > 0.5f && !firstFlag)
		{

			if (rightFlag) i = Mathf.Clamp(++i, 1, 5);
			if (!rightFlag) i = Mathf.Clamp(--i, 1, 5);

			return i;
		}
		else { firstFlag = true; aboveFlag = true; return i; }
    }
}
