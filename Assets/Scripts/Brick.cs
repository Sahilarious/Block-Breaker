using UnityEngine;
using System.Collections;


public class Brick : MonoBehaviour {
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
    public GameObject particles;
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {

        if (this.GetComponent<SpriteRenderer>().sprite == null) {
            SpriteError();
        }

		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
		isBreakable = this.tag == "Breakable";
		if(isBreakable){
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		//audio.Play();
		if(isBreakable){
			AudioSource.PlayClipAtPoint(crack, transform.position, 0.5f);
			HandleHits();
		}
	}
		
	void HandleHits() {
		int maxHits = hitSprites.Length + 1;
		timesHit++;
		
		//SimulateWin();
		if(timesHit >= maxHits){
			breakableCount--;
            CreateParticles();

            levelManager.BrickDestroyed();
            Destroy(gameObject);
				
		}else{
			LoadSprites();
		}
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else {
            SpriteError();
        }
	}

    void SpriteError()
    {
        Debug.LogError("This object does not have a sprite.");
    }

    void CreateParticles()
    {
        GameObject particles2 = (GameObject)Instantiate((Object)particles, gameObject.transform.position, Quaternion.identity);
        particles2.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
        Destroy(particles2, 2f * particles2.GetComponent<ParticleSystem>().startLifetime);
    }
	
}
