﻿using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour 
{
	public Transform tiro;
	public GameObject spawntiroum;
	public int vidas = 3;
	public bool lastDirection = true; // true se esquerda
	public static int score;
	public float Tirosdisponiveis = 3;
	public int tirosmaximos = 5;
	public Rigidbody2D rb;
	public bool grounded = true;
	public int time = 0;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.W) && grounded == true)
		{
			rb.AddForce(Vector2.up * 250f);
			grounded = false;
			//transform.Translate(new Vector2(0, 0.2f));
		}
		
		if (Input.GetKeyDown(KeyCode.A) && lastDirection == true)
		{
			transform.Rotate(new Vector3(0,-180,0));
			//transform.Translate(new Vector2(0.2f, 0));
			lastDirection = false;
		}
		
		if (Input.GetKeyDown(KeyCode.D) && lastDirection == false)
		{
			transform.Rotate(new Vector3(0,180,0));
			//transform.Translate(new Vector2(-0.2f, 0));
			lastDirection = true;
		}
		
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
		{
			transform.Translate(new Vector2(0.15f, 0));
		}
		

		if (Input.GetKeyDown(KeyCode.Space) && Tirosdisponiveis >= 1)
		{
			Transform newTiro;
			newTiro = Instantiate(tiro, spawntiroum.transform.position , tiro.transform.localRotation) as Transform;
			newTiro.GetComponent<direcaotiro>().shotTo = lastDirection;
			//Debug.Log(newTiro.transform.name);
			Tirosdisponiveis--;
		}

		if (Tirosdisponiveis > tirosmaximos) {
			Tirosdisponiveis = 5;
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		
		if (coll.gameObject.tag == "branca") {
			Player2.score ++;
			Debug.Log ("Player2 score: " + Player2.score);
		}
		if (coll.gameObject.tag == "chao") {
			grounded = true;
		}
	

	} 
	void OnTriggerStay2D(Collider2D coll){
		time++;
		if (time == 150 /*&& gameObject.tag == "urubuzinho"*/) {
			Tirosdisponiveis++;
			time = 0;
		}

	}
	void OnTriggerExit2D(Collider2D coll){
		time = 0;
	}
}