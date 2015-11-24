using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	void Awake() {
		instance = this;
	}

	public bool isGamePlaying = false;
	public GameObject welcomePanel;
	public GameObject gamePanel;

	public Transform circle;
	public Transform square;

	private int bodyCount = 0;

	public Text bodiesCountDisplay;

	void Start() {
		gamePanel.SetActive (false);
	}

	public void PlayGame() {
		isGamePlaying = true;
		welcomePanel.SetActive (false);
		gamePanel.SetActive (true);
	}

	void Update() {

		bool isTouched = (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);

		if (isGamePlaying)
		if (Input.GetMouseButtonDown (0) || isTouched) {
			var pos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
			SpawnItem (pos.x, pos.y);
		}                    
	}

	private void SpawnItem(float x, float y) {
		bool isCircle = (Random.Range (0, 2) == 0);
		Object obj = isCircle ? circle : square;
		Transform inst = Instantiate(obj, new Vector3 (x, y, 0), Quaternion.identity) as Transform;
		float scale = Random.Range (0.7f, 1.5f);
		inst.localScale = new Vector3 (
			scale,
			isCircle ? scale : 2f - scale,
			0
		);
		bodyCount++;
		bodiesCountDisplay.text = "Bodies: " + bodyCount;
	}
}
