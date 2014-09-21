using UnityEngine;
using System.Collections;

public class GetCordFromGrid : MonoBehaviour {

		Gridsystem gridSystem;
		Transform obj_gridSystem;
		public Vector2 cordinates;
		public Vector3 gameObjectPosition;
	void Start () {
				obj_gridSystem = GameObject.FindGameObjectWithTag ("Grid").transform;
				gridSystem = obj_gridSystem.GetComponent<Gridsystem> ();

	}
	
	// Update is called once per frame
	void Update () {



	}
}
