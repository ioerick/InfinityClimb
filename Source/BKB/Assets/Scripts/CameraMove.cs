using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	GameObject _player;
	[Range(0f,10f)]
	public float _suavidad;

	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void Update () {
		Vector2 posPlayer = new Vector2 (_player.transform.position.x, _player.transform.position.y);
		Vector2 posCamera = new Vector2 (transform.position.x, transform.position.y);

		posCamera = Vector2.Lerp (posCamera, posPlayer, _suavidad*Time.deltaTime);
		transform.position = new Vector3 (posCamera.x, posCamera.y, transform.position.z);
	}
}
