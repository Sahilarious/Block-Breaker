using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lives : MonoBehaviour {
	public int initialLives = 3;
	public static int currentLives;
	public GameObject heart;
	
	void Start() {
	int currentHearts;
		if(Application.loadedLevel == 1){
			currentLives = initialLives;

		}else{
			currentLives++;
;
		}
		
		for(int i = 1; i <= currentLives;i++){
			AddLife();
		}
		organizeLives();
	}

	 public void AddLife(){
		GameObject.Instantiate(heart);
		
	}
	
	public void LoseLife() {
		currentLives--;
		GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
		Destroy (hearts[hearts.Length - 1]);
		organizeLives();
	}
	
    void organizeLives() {
		GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
    	
		for(int i = 0; i < hearts.Length; i++){
			hearts[i].transform.position = new Vector2(1 + i*1f, hearts[i].transform.position.y);
    	}
    	
    }
}
