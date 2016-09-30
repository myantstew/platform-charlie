using UnityEngine;
using System.Collections;

public class CanvasKill : MonoBehaviour {

	public GameObject canvas;
	// Use this for initialization
	void Start () 
	{
		DestroyImmediate (canvas, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
