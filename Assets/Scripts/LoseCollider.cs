using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	private Ball ball;
	private Lives lives;
	
	
	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	    ball = GameObject.FindObjectOfType<Ball>();
	    lives = GameObject.FindObjectOfType<Lives>();
	}
	
	
	void OnTriggerEnter2D (Collider2D trigger){
		

		if(Lives.currentLives > 1){
			lives.LoseLife();
			ball.ResetBall();
		}else{
			levelManager.LoadLevel("Lose");
			Lives.currentLives = 0;
			
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D collision){
	

	}



}
