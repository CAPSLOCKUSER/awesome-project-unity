using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour {

	public Text display;

	float deltaTime = 0.0f;

	void Start() {
		
		Application.targetFrameRate = 60;
	}
	
	void Update() {
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		float fps = 1.0f / deltaTime;
		display.text = ((int)fps).ToString();
	}
}