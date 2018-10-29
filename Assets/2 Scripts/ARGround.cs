using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGround : MonoBehaviour {

	public GameObject VideoCanvas;

	// Use this for initialization
	void Start () {
		GameObject video = 	Instantiate(VideoCanvas);
			video.name = "CanvasVideo";

			foreach(Transform vc in video.transform){
				vc.gameObject.SetActive(false);
			}
	}

	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
         {
            // Go back to main Sceen
            AppManager.instance.ShowDetailPanel = true;
            AppManager.instance.CurrentScreenIndex = 1;
			UnityEngine.SceneManagement.SceneManager.LoadScene(1);
         }
	}
}
