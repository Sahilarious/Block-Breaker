using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelManager : MonoBehaviour {

    void Awake() {
        Debug.Log ("Level Manager Awake");       
    }
    
    void Start() {

		
    }
     
	public void LoadLevel(string name) {
		Brick.breakableCount = 0;
		
		Application.LoadLevel(name);
		Debug.Log ("New Level Load: " + name);
	}
	
	public void LoadNextLevel() {
		Brick.breakableCount = 0;
		
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void ResetLevel() {
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void QuitRequest() {
		Application.Quit();
	}
	
	public void BrickDestroyed() {
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
			/*
			System.Threading.Timer timer = null;
			timer = new System.Threading.Timer((obj) =>
				{
					LoadNextLevel();
					timer.Dispose();
				}, null, 100, 100);
			*/
		}
	}
}
