using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 2.0f;
	public float jumpheight = 2.0f;

	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.rotation = Quaternion.Euler(0, 180, 0);
			transform.Translate(Vector3.left * speed);
		} 

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
			transform.Translate(Vector3.left * speed);
		} 

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate(Vector3.up * jumpheight);
		} 
	}

	int curFrame = 0;
	public Sprite[] Frames = new Sprite[2];
	void Start() {
		StartCoroutine (Animation ());
	}

	IEnumerator Animation() {
		curFrame = (curFrame == 0 ? 1 : 0);

		GetComponent<SpriteRenderer> ().sprite = Frames [curFrame];

		yield return new WaitForSeconds (0.05f);
		StartCoroutine (Animation ());
	}

}
