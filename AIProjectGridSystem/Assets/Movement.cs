using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

		Gridsystem gridSystem;
		Transform obj_GridSystem;
		SpriteRenderer sRender;
		float blockSize;
		Vector3 playerPosition;

		public Sprite sprite;

		void Start ()
		{
				obj_GridSystem = GameObject.FindGameObjectWithTag ("Grid").transform;
				gridSystem = obj_GridSystem.GetComponent<Gridsystem> ();
				sRender = gameObject.GetComponent<SpriteRenderer> ();
				playerPosition = gameObject.transform.position;
				blockSize = sprite.rect.x + 0.016f;
		}
	
		// Update is called once per frame
		void Update ()
		{
				var objectPosition = gridSystem.getCordinatFromPosistion (gameObject.transform.position);
				var mousePosition = gridSystem.getMousePosition ();

				if (objectPosition != mousePosition) {
						Vector2 goal = new Vector2 (mousePosition.x - objectPosition.x, mousePosition.y - objectPosition.y);
						pathFinding (goal);

				}
	
		}

		public void pathFinding (Vector2 goal)
		{
				var endGoal = goal;
				var objectPosition = gridSystem.getCordinatFromPosistion (gameObject.transform.position);
				int xMovement = 0;
				int yMovement = 0;
				if (xMovement == 0) {
						var xPosition = gameObject.transform.position.x;
						var goalPositionX = new float ();
						if (endGoal.x > 0)
								goalPositionX = gameObject.transform.position.x + blockSize;								
						else
								goalPositionX = gameObject.transform.position.x - blockSize;
						if (gameObject.transform.position.x > goalPositionX) {
								Debug.Log (goalPositionX);
								gameObject.transform.position -= transform.right * 0.01f;
						}
						if (gameObject.transform.position.x < goalPositionX) {
								gameObject.transform.position += transform.right * 0.01f;
								Debug.Log (goalPositionX);
						}

						if (gameObject.transform.position.x == goalPositionX) {
								endGoal.x--;
								xMovement++;
						}
				}	
				if (xMovement == 1 && yMovement == 0) {
						endGoal.y--;
						yMovement++;
				}
				if(endGoal.x > 0 || endGoal.y > 0)
				{
						pathFinding(endGoal);
				}

		}
}
