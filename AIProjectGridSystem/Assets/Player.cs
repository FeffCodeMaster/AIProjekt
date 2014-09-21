using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

		public SpriteRenderer player_sRender;
		public Sprite sprite;

		void Start ()
		{
				player_sRender = (SpriteRenderer)gameObject.AddComponent (typeof(SpriteRenderer));
				player_sRender.sprite = sprite;
				player_sRender.sortingOrder = 1;
		}

	
		void Update ()
		{


		}
}
