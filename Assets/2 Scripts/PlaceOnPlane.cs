using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
using System.Collections;
using System.IO;

[RequireComponent(typeof(ARSessionOrigin))]
public class PlaceOnPlane : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    
    GameObject m_PlacedPrefab;

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }
    
    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedObject { get; private set; }

    ARSessionOrigin m_SessionOrigin;	
    
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    
    void Awake()
    {
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
    }

 

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (m_SessionOrigin.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = s_Hits[0].pose;

                if (spawnedObject == null)
                {
                   // spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);

                	 spawnedObject = m_PlacedPrefab;
                	 spawnedObject.transform.position = hitPose.position;
                	 spawnedObject.transform.rotation = hitPose.rotation;
                	 spawnedObject.SetActive(true);


                     //desable genarated plans
                     gameObject.GetComponent<ARPlaneManager>().OnTogglePlanes(false);
                     gameObject.GetComponent<ARPointCloudManager>().ShowPoints(false);

                }
                else if(!spawnedObject.activeSelf)
                {
                    spawnedObject.transform.position = hitPose.position;
                    spawnedObject.SetActive(true);

                    gameObject.GetComponent<ARPlaneManager>().OnTogglePlanes(false);
                    gameObject.GetComponent<ARPointCloudManager>().ShowPoints(false);
                }
            }
        }
    }


    public void Button_Replace_m_PlacedPrefab()
    {
        print("Placeing product again");
        spawnedObject.SetActive(false);
        gameObject.GetComponent<ARPlaneManager>().OnTogglePlanes(true);
        gameObject.GetComponent<ARPointCloudManager>().ShowPoints(true);
    }

    public void Button_ImageCapture()
    {
        //ScreenCapture.CaptureScreenshot("JD_Tractor_"+System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss"));

        if(!m_screenShotLock)
        {
            m_screenShotLock = true;
             StartCoroutine(TakeScreenShotCo());
        }
    }


    private bool m_screenShotLock = false;
 
     private void LateUpdate()
     {
         if (Input.GetKeyDown(KeyCode.S) && !m_screenShotLock)
         {
             m_screenShotLock = true;
             StartCoroutine(TakeScreenShotCo());
         }
     }
 
     private IEnumerator TakeScreenShotCo()
     {
         yield return new WaitForEndOfFrame();
 
         var directory = new DirectoryInfo(Application.dataPath);
         var path = Path.Combine(directory.Parent.FullName, string.Format("JD_Tractor_{0}.png", System.DateTime.Now.ToString("yyyyMMdd_Hmmss")));
         Debug.Log("Taking screenshot to " + path);
         ScreenCapture.CaptureScreenshot(path);
         m_screenShotLock = false;
     }

    public void Button_ApplicationQuit(){
    	Application.Quit();
    }



}
