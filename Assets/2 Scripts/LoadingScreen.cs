/*===============================================================================
Copyright (c) 2015-2018 PTC Inc. All Rights Reserved.

Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other
countries.
===============================================================================*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{


	public static LoadingScreen instance;

	


    #region PRIVATE_MEMBER_VARIABLES
    RawImage m_SpinnerImage;
    AsyncOperation m_AsyncOperation;
    bool m_SceneReadyToActivate;
    #endregion // PRIVATE_MEMBER_VARIABLES

    #region PUBLIC_MEMBER_VARIABLES
    public static string SceneToLoad { get; set; }
    #endregion // PUBLIC_MEMBER_VARIABLES

    public static void Run()
    {
        SceneManager.LoadSceneAsync("2-Loading");
    }


    void Awake()
    {
    	instance = this;
    }

    #region MONOBEHAVIOUR_METHODS
    void Start()
    {
        m_SpinnerImage = GetComponentInChildren<RawImage>();
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        StartCoroutine(LoadNextSceneAsync());
    }

    void Update()
    {
        if (m_SpinnerImage)
        {
            if (!m_SceneReadyToActivate)
            {
                m_SpinnerImage.rectTransform.Rotate(Vector3.forward, 90.0f * Time.deltaTime);
            }
            else
            {
                m_SpinnerImage.enabled = false;
            }
        }

        if (m_AsyncOperation != null)
        {
            if (m_AsyncOperation.progress < 0.9f)
            {
                Debug.Log("Scene Loading Progress: " + m_AsyncOperation.progress * 100 + "%");
            }
            else
            {
                m_SceneReadyToActivate = true;
                m_AsyncOperation.allowSceneActivation = true;
            }
        }
    }
    #endregion // MONOBEHAVIOUR_METHODS


    #region PRIVATE_METHODS
    IEnumerator LoadNextSceneAsync()
    {
        //int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

    	print("Current Scene "+AppManager.instance.CurrentScreenIndex);
    	
    	int CurrentScreenIndex = AppManager.instance.CurrentScreenIndex;

		int nextSceneIndex = CurrentScreenIndex +1;

/*
		if(CurrentScreenIndex == 0)
		{
			nextSceneIndex = 1;

		}else if(CurrentScreenIndex == 1)
		{
			nextSceneIndex = 2;

		}else if(CurrentScreenIndex == 2)
		{
			nextSceneIndex = 3;

		}else if(CurrentScreenIndex == 2)
		{
			nextSceneIndex = 3;
		}*/


        if (string.IsNullOrEmpty(SceneToLoad))
        {
            m_AsyncOperation = SceneManager.LoadSceneAsync(nextSceneIndex);
        }
        else
        {
            m_AsyncOperation = SceneManager.LoadSceneAsync(SceneToLoad);
        }

        m_AsyncOperation.allowSceneActivation = false;

        yield return m_AsyncOperation;
    }
    #endregion // PRIVATE_METHODS
}
