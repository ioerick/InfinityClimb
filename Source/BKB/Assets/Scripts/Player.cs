using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Rigidbody _rb;

	float _velocidad = 9f;
	float _fuerzaDeSalto = 99f;
	bool _tocandoPiso;

	void Start () {
		_rb = GetComponent<Rigidbody> ();
		_tocandoPiso = true;
	}
	
	void Update () {
		float Horizontal = Input.GetAxis ("Horizontal");
		float velocidad = _velocidad * Horizontal * Time.deltaTime;
		bool Salto = Input.GetButton ("Jump");

		transform.Translate (velocidad, 0, 0);

		if (Salto && _tocandoPiso) {
			_rb.AddForce (new Vector3 (0, _fuerzaDeSalto, 0));
			_tocandoPiso = false;
		}
		Debug.Log (_tocandoPiso);
	}

	void OnCollisionEnter(Collision coll){
		if (coll.collider.tag == "Platform") {
			_tocandoPiso = true;
		}
	}
}
