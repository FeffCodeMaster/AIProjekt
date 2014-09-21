using UnityEngine;
using System.Collections;

public class KebabellerPizza : MonoBehaviour {

		string pizze,kebab;
		Random rand;
		int decission;
		float time = 5;
	void Start () {
				pizze = "pizza";
				kebab = "kebab";
				rand = new Random ();

	}
	
	// Update is called once per frame
	void Update () {
				time -= Time.deltaTime;
				if (time > 0) {
						decission = Random.Range (0, 2);
				}
			
						if (decission == 1) {
								gameObject.guiText.text = pizze;
						} else {
								gameObject.guiText.text = kebab;
						}
			
	
	}
}
