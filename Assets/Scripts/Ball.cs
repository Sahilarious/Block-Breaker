using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool launched;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector =  this.transform.position - paddle.transform.position;
		launched = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!launched){
			// Locks the position of the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			// Waits for a mouse click for launch
			if (Input.GetMouseButtonDown(0)){
		
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 10f);
				//prevents the outer if statement from ever running again
				launched = true;
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
	
		//Vector2 tweak = new Vector2(Random.Range(-2,2)*Random.Range(0.1f,0.2f), Random.Range(0f,0.2f));
		Vector2 tweak = new Vector2(Random.Range(0f,0.2f), Random.Range(0f,0.2f));
		
		this.GetComponent<Rigidbody2D>().velocity += tweak;
		print (tweak);
		if(launched){
			GetComponent<AudioSource>().Play();
		}
	}
	
	public void ResetBall(){
		launched = false;
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		this.transform.position = paddle.transform.position + paddleToBallVector;
	}
}
