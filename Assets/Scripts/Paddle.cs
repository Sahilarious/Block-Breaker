using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoPlay = true;
	
	private Vector3 paddlePos;
	private Ball ball;
	private float maxX;
	private float minX;

	// Use this for initialization
	void Start () {
		paddlePos = new Vector3(8.5f, this.transform.position.y, 0f);
		ball = GameObject.FindObjectOfType<Ball>();
		minX = 0.5f + this.GetComponent<SpriteRenderer>().sprite.bounds.max.x;
		maxX = 16.5f + this.GetComponent<SpriteRenderer>().sprite.bounds.min.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			MoveWithMouse();
		}else{
			AutoPlay();
		}
	}
	
	void AutoPlay(){
		paddlePos.x = Mathf.Clamp (ball.GetComponent<Rigidbody2D>().position.x, minX, maxX); 
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse(){
		paddlePos.x = Mathf.Clamp (16*Input.mousePosition.x/Screen.width, minX, maxX); 
		this.transform.position = paddlePos;
	}
}
