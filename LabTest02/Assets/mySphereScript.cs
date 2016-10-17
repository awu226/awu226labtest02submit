using UnityEngine;
using System.Collections;
public class mySphereScript : MonoBehaviour {
	public float rotateSpeed = 1.0f;
	public Vector3 spinSpeed = Vector3.zero;
	Vector3 spinAxis = new Vector3(0, 1, 0);
	public Vector3 rotateAxis = Vector3.up;
	public Material material4;
	// Use this for initialization
//	void Start () {
//		spinSpeed = new Vector3(Random.value, Random.value, Random.value);
//		spinAxis = Vector3.up;
//		spinAxis.x = (Random.value - Random.value)*0.1f;
//	}
//	void OnMouseDown() {
//		//change color on click
//		this.GetComponent<Renderer> ().material = material4;
}

