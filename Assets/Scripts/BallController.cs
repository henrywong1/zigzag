using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public GameObject particle;

	[SerializeField]//makes private accessible through unity
	private float speed;
	bool started;
	bool gameOver;
	Rigidbody rb; //refers to the ball object itself

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}
	// Use this for initialization
	void Start () {
		started = false;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!started) {
			if (Input.GetMouseButtonDown(0)){
				rb.velocity = new Vector3 (speed, 0, 0);
				started = true;

				GameManager.instance.startGame();
			}
		}
		Debug.DrawRay (transform.position, Vector3.down, Color.red); //attaches a ray to the ball, indicating direction


		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {     //If no collision, can't switch direction
			gameOver = true;
			rb.velocity = new Vector3 (0,-15f,0);

			Camera.main.GetComponent<CameraFollow>().gameOver = true;     //Prevents camera from following a falling ball

			GameManager.instance.gameOver();
		}

		if (Input.GetMouseButtonDown (0) && !gameOver) {
			SwitchDirection();
		}
	}

	void SwitchDirection(){
		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0, 0);
		} else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0, 0, speed);
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Diamond") {

			GameObject part = Instantiate(particle,col.gameObject.transform.position, Quaternion.identity) as GameObject; //Instantiate particle, stores as GO

			Destroy(col.gameObject); 
			Destroy(part,1f);

		}
	}




}
