using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;


public class VideoPlayer_ : MonoBehaviour {
 	public double time;
    public double currentTime;

    public VideoPlayer vid;

void Start(){
    
    
    
    vid.loopPointReached += CheckOver;}
 
void CheckOver(UnityEngine.Video.VideoPlayer vp)
{
     print  ("Video Is Over");

     try{

     gameObject.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("close");
     Invoke("closeVideo",1.5f);  

     }catch(Exception e){

     }

     try{

        Animation anim = transform.parent.gameObject.GetComponent<Animation>();
            
         foreach(AnimationState state in anim)
         {
             Debug.Log(state.name);
             if(state.name.Contains("close")){
                anim.Play(state.name);
                return;
             }
         }
        }catch(Exception e){

        }
     
}

public void closeVideo()
{
    gameObject.transform.parent.gameObject.SetActive(false);
}

public void ButtonPaly(bool play){

    if(!play){
        if(vid.isPlaying){
            vid.Pause ();
        }
    }else
    {
        vid.Play();
    }
    
}




/*
    void Start () {
 
		    time = gameObject.GetComponent<VideoPlayer> ().clip.length;
    }
 
   
    // Update is called once per frame
    void FixedUpdate () {
        currentTime = gameObject.GetComponent<VideoPlayer> ().time;
        if (currentTime >= time) {
            Debug.Log ("//do Stuff");
            gameObject.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("close");
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }*/
	
}
