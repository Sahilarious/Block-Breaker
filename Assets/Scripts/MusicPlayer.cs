using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null; 
	
	void Awake() {
	    Debug.Log ("Music player Awake " + GetInstanceID());
		if (instance != null) {
			Destroy(gameObject);
			Debug.Log ("Duplicate Music Player self destructing " + GetInstanceID ());
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	
	}
	//Multiple ways of preventing a new instance of the class MusicPlayer from starting 
	
	 
	//----------------Method #1-----------------
	
//	static int playerCount = 0; 
//	
//	void Start () {
//		if (playerCount == 0) {
//			GameObject.DontDestroyOnLoad(gameObject);
//		} else {
//			GameObject.Destroy(gameObject);
//		}
//		playerCount++;
//	}
	
	//----------------Method #2-----------------
	
	

	void Start () {
	    Debug.Log ("Music player Start " + GetInstanceID());

	}
	
	
	// Update is called once per frame
	void Update () {
	
	
	
	
	}
}
