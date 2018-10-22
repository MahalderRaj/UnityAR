using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThreeDView : MonoBehaviour {

	public GameObject Product;
	public GameObject VideoCanvas;

	GameObject CurrentProduct = null;

	// Use this for initialization
	void Start () {
		
		if(CurrentProduct == null)
		{
			CurrentProduct = Instantiate(Product, transform);
			//CurrentProduct.transform.parent = gameObject.transform;
			//CurrentProduct.transform.position = Vector3.zero;
			GameObject video = 	Instantiate(VideoCanvas);
			video.name = "CanvasVideo";

			foreach(Transform vc in video.transform){
				vc.gameObject.SetActive(false);
			}

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
