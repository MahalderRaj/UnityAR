using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour {


	public static AppManager instance;

	public int CurrentScreenIndex = 0;

	public bool ShowDetailPanel = false;


	void Awake()
	{
		instance = this;
	}


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
