using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotspotMan : MonoBehaviour {


	public Transform[] HotspotTVs;
	public Transform[] HotspotTVCanvas;


	void Start()
	{
		


		foreach(Transform tv in HotspotTVs)
		{
			tv.gameObject.SetActive(false);
		}


		foreach(Transform tvCan in HotspotTVCanvas)
		{
			tvCan.gameObject.SetActive(false);
		}
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


	public void ButtonVideoHotspotTV(int index)
	{

		foreach(Transform tv in HotspotTVs)
		{
			tv.gameObject.SetActive(false);
		}

		foreach(Transform tvCan in HotspotTVCanvas)
		{
			tvCan.gameObject.SetActive(false);
		}

		HotspotTVs[index].gameObject.SetActive(true);
		HotspotTVCanvas[index].gameObject.SetActive(true);

	}



	void Update()
	{



		if(Input.GetKeyDown(KeyCode.A))
		{
			ButtonVideoHotspotTV(1);
		}

		if(Input.GetKeyDown(KeyCode.X))
		{
			HotspotTVs[1].gameObject.SetActive(false);
		HotspotTVCanvas[1].gameObject.SetActive(false);
		}	
	}

}
