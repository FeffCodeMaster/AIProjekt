using UnityEngine;
using System.Collections;

public class Gridsystem : MonoBehaviour
{

		public Sprite gridText;
		public int a, b;
		public GameObject[,] blocks;
		public Vector2 mousePosition = new Vector2 ();

		int count;

		void Start ()
		{

				blocks = new GameObject[a, b];
				for (int x = 0; x < a; x++) {
						for (int y = 0; y < b; y++) {
								blocks [x, y] = new GameObject ("Blocks" + count.ToString ());
								SpriteRenderer sRender = (SpriteRenderer)blocks [x, y].AddComponent (typeof(SpriteRenderer)); 
								blocks [x, y].transform.position = new Vector3 (x * gridText.rect.width * 0.011f, y * gridText.rect.height * 0.011f, 0); 
								BoxCollider2D coll = (BoxCollider2D)blocks [x, y].AddComponent (typeof(BoxCollider2D));
								coll.size = new Vector2 (0.16f, 0.16f);
								sRender.transform.parent = gameObject.transform;
								sRender.sprite = gridText;
								count++;
						}
				}
		}

		void Update ()
		{
				setMousePositionOnClick ();
		}
		private void setMousePositionOnClick()
		{
				for (int x = 0; x < a; x++) {
						for (int y = 0; y < b; y++) {
								var position = Input.mousePosition;
								Vector3 MPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, blocks [x, y].transform.position.z - Camera.main.transform.position.z));
								RaycastHit2D Hit = Physics2D.Raycast (MPosition, -Vector2.up);
								if (Hit != null && Hit.collider != null) {
										if (Input.GetMouseButton (0)) {

												if (blocks [x, y].name == Hit.collider.name) {
														mousePosition = new Vector2 (x, y);
												}
										}
								}
						}
				}
		}
		public Vector2 getCordinatFromPosistion (Vector3 objectPosition)
		{
				Vector2 pos = new Vector2 ();
				for (int i = 0; i < a; i++) {
						for (int j = 0; j < b; j++) {
								if (objectPosition == blocks [i, j].transform.position) {
										pos = new Vector2 (i, j);
								}
						}
				}
				return pos;
		}

		public Vector2 getMousePosition ()
		{
				return mousePosition;
		}
}
