using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Text scoreText;
	public Text winText;

	private Rigidbody rigidBody;
	private int count= 0;

	// Use this for initialization
	void Start () 
	{
		rigidBody = GetComponent<Rigidbody> ();
		SetScoreText ();
		winText.text = "";
	}
	
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce (movement* speed);
	
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + count.ToString();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count +1;
			SetScoreText();

			if(count >=12)
			{
				winText.text = "Hurray!!! You Win!";
			}
		}
	}
}
