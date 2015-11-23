using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	void Awake() {
		instance = this;
	}

	public bool isGamePlaying = false;
	public GameObject welcomePanel;
	public GameObject gamePanel;

	void Start() {
		gamePanel.SetActive (false);
	}

	public void PlayGame() {
		isGamePlaying = true;
		welcomePanel.SetActive (false);
		gamePanel.SetActive (true);
	}
}
