using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TapPanel : MonoBehaviour {

	public Transform _buttonTractor, _buttonImplements,_buttonGrainHarvesting;

	public GameObject[] Tractor,Implements,GrainHarvesting, SpecialTractors;

	public Transform _content;

	public GameObject PanelDetails, PanelExit;


	public void Start()
	{

		PanelExit.SetActive(false);

		if(AppManager.instance.ShowDetailPanel)
			PanelDetails.SetActive(true);
		else
			PanelDetails.SetActive(false);

		DesableAll();
		ButtonTractor();
	}

	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape))
         {
			//PanelExit.SetActive(true);


			
         	if(PanelDetails.activeSelf)
         	{
				PanelDetails.SetActive(false);
				return;

         	}else
         	{
	         	// Go back to main Sceen
	            //AppManager.instance.ShowDetailPanel = false;
	            //AppManager.instance.CurrentScreenIndex = 1;
				//UnityEngine.SceneManagement.SceneManager.LoadScene(1);

         		PanelExit.SetActive(true);
         	}
			
            
         }

	}


	void DesableAll()
	{
		foreach(Transform item in _content)
		{
			item.gameObject.SetActive(false);
		}
	}

	public void ButtonExit()
	{
		Application.Quit();
	}

	void SetTapEnable(int index)
	{
		_buttonTractor.Find("Image").gameObject.SetActive(false);
		_buttonImplements.Find("Image").gameObject.SetActive(false);
		_buttonGrainHarvesting.Find("Image").gameObject.SetActive(false);

		if(index == 0)
		{
			_buttonTractor.Find("Image").gameObject.SetActive(true);
			
		}else if(index == 1)
		{			
			_buttonImplements.Find("Image").gameObject.SetActive(true);

		}else if(index == 2)
		{			
			_buttonGrainHarvesting.Find("Image").gameObject.SetActive(true);
		}


	}

	public void ButtonSpecialTractors()
	{
		DesableAll();
		foreach(GameObject item in SpecialTractors)
		{
			item.gameObject.SetActive(true);
		}
		SetTapEnable(0);
	}


	public void ButtonTractor()
	{
		DesableAll();
		foreach(GameObject item in Tractor)
		{
			item.gameObject.SetActive(true);
		}
		SetTapEnable(0);

	}

	public void ButtonImpements()
	{
		DesableAll();
		foreach(GameObject item in Implements)
		{
			item.gameObject.SetActive(true);
		}

		SetTapEnable(1);
	}

	public void ButtonGrainHarvesting()
	{
		DesableAll();
		foreach(GameObject item in GrainHarvesting)
		{
			item.gameObject.SetActive(true);
		}

		SetTapEnable(2);
	}

	public void Button3DView()
	{
		AppManager.instance.CurrentScreenIndex = SceneManager.GetActiveScene().buildIndex;

		UnityEngine.SceneManagement.SceneManager.LoadScene(1);

	}

	public void ButtonARView()
	{
		AppManager.instance.CurrentScreenIndex = 3;

		UnityEngine.SceneManagement.SceneManager.LoadScene(1);

	}





}
