using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBG : MonoBehaviour
{
	public static RandomBG instance;
	public AudioClip hit;
	public AudioClip knifesound;
	public GameObject soundControlButton;
	public Sprite audioOffSprite;
	public Sprite audioOnSprite;
	void Awake()
	{
		instance = this;
		SetRandomBgColor();
	}
	void Start()
	{
		if (AudioListener.pause == true)
		{
			soundControlButton.GetComponent<Image>().sprite = audioOffSprite;
		}
		else
		{
			soundControlButton.GetComponent<Image>().sprite = audioOnSprite;
		}
	}

	public void SoundControl()
	{
		if (AudioListener.pause == true)
		{
			AudioListener.pause = false;
			soundControlButton.GetComponent<Image>().sprite = audioOnSprite;
		}
		else
		{
			AudioListener.pause = true;
			soundControlButton.GetComponent<Image>().sprite = audioOffSprite;

		}
	}
	public void PlayOnce()
	{
		GetComponent<AudioSource>().PlayOneShot(hit); 
	}
	public void KnifeCrash()
	{
		GetComponent<AudioSource>().PlayOneShot(knifesound);
	}

	public void SetRandomBgColor()
    {
		RenderSettings.fogColor = new Color (Random.Range(0f, 1f),
											 Random.Range(0f, 1f),
											 Random.Range(0f, 1f));

		RenderSettings.fogMode = FogMode.Linear;
		RenderSettings.fogStartDistance = 80f;
		RenderSettings.fogEndDistance = 140f;
	}

}
