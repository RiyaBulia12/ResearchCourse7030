using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Sprite[] cardFace;
	public Sprite cardBack;
	public GameObject[] cardGameObject;
	public Text matchText;

	private bool _init = false;
	private int _matches = 1;
	
	// Update is called once per frame
	void Update () {
		if (!_init)
			initializeCards	();
		if (Input.GetMouseButtonUp (0))
			checkCards ();
	}

	void initializeCards(){
		for (int id = 0; id < 2; id++) {
			for (int i = 1; i <  27; i++) {
				bool test = false;
				int choice = 0;
				while (!test) {
					choice = Random.Range (0, cardGameObject.Length);
					test = !(cardGameObject [choice].GetComponent<cards>().initialized);
				}
				cardGameObject[choice].GetComponent<cards> ().cardValue = i;
				cardGameObject[choice].GetComponent<cards> ().initialized = true;
			}
		}
		foreach (GameObject c in cardGameObject)
			c.GetComponent<cards> ().setupGraphics ();
		if (!_init)
			_init = true;
	}

	public Sprite getCardBack(){
		return cardBack;
	}

	public Sprite getCardFace(int i ){
		return cardFace[i-1];
	}

	void checkCards(){
		List<int> c = new List<int> ();
		for (int i = 0; i < cardGameObject.Length; i++) {
			if (cardGameObject [i].GetComponent<cards> ().state == 1)
				c.Add (i);
		}
		if (c.Count == 2)
			cardComparison (c);
			
	}

	void cardComparison(List<int> c){
		cards.DO_NOT = true;

		int x = 0;
		if (cardGameObject[c[0]].GetComponent<cards>().cardValue == cardGameObject[c[1]].GetComponent<cards>().cardValue) {
			x = 2;
			_matches--;
			matchText.text = "Number of Matches:" + _matches;
			if (_matches == 0)
				SceneManager.LoadSceneAsync("Firework");
		}
		for (int i = 0; i < c.Count; i++) {
			cardGameObject [c [i]].GetComponent<cards> ().state = x;
			cardGameObject [c [i]].GetComponent<cards> ().falseCheck ();
		}
	}
}
