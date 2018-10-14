using UnityEngine;
using System.Collections;

public class cinematicOptions : MonoBehaviour {

	public GUIStyle titleStyle;
	public GUIStyle titleStyleDark;

	public bool levelStart;
	public Camera CinematicCam;

	public string gameName;

	void Start(){
		levelStart = false;
		CinematicCam = this.camera;
	}
	void Update () {
		if(Input.anyKey && !levelStart || !CinematicCam.animation.isPlaying && !levelStart){
			levelStart = true;
			CinematicCam.SendMessage("fadeIn");
			CinematicCam.animation.Stop();
		}
		if(levelStart){
			CinematicCam.depth = -2;
		}
	}

	void OnGUI(){
		float x = Screen.width / 1280.0F;
		float y = Screen.height / 720.0F;
		Vector3 z = new Vector3(x, y, 1F);
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, z);
		if(!levelStart){
			//display name of minigame
			Rect r = new Rect(354,254,1280,720);
			GUI.Label(r, gameName, titleStyleDark);
			//GUI.Label(Rect(350,247,1280,720),gameName,titleStyleDark);
			//GUI.Label(Rect(347,250,1280,720),gameName,titleStyleDark);
			//GUI.Label(Rect(353,250,1280,720),gameName,titleStyleDark);
			Rect s = new Rect(350,250,1280,720);
			GUI.Label(s, gameName, titleStyle);
			//set depth to display over camera fades
			GUI.depth = -1001;
		}
	}
}