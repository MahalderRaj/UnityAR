using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotspotMan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ButtonVideo(int index)
	{
		Transform VideoCanvas = GameObject.Find("CanvasVideo").transform;

		foreach(Transform vc in VideoCanvas)
		{
			vc.gameObject.SetActive(false);
		}

		VideoCanvas.GetChild(index).gameObject.SetActive(true);

		/*
		for(int i=0; i < VideoCanvas.childCount ; i++)
		{
			if(VideoCanvas.GetChild(i).activeSelf)
			{
				VideoCanvas.GetChild(i).gameObject.SetActive(true);
			}
		}
		*/
	}

}
