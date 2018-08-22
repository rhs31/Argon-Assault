using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] int scorePerHit = 12;

    int score;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>(); // entire game component
        scoreText.text = score.ToString(); // change the actual text (string) piece of Text component.
	}
	public void ScoreHit()
    {
        score = score + scorePerHit;
    }
}
