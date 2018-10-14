using UnityEngine;
using System.Collections;

public class TriviaResults : MonoBehaviour {
	
	public bool resultsOn;
	public bool mapOn;
	public Texture resultsShadow;
	public GUISkin resultsGUI;
	public GUISkin mapGUISkin;
	public Texture mapTexture;
	public Texture behindTransparent;
	public Texture backgroundImage;
	public GameObject settingsData;
	public int tempX;
	public int tempY;
	
	//Game Specific//
	public int pointsEarned;

	void Start()	{
		settingsData = GameObject.Find("gameSettings");
		resultsOn = false;
		mapOn = false;
	}
	public void getResultsOn(bool res)
	{	
		pointsEarned = Camera.main.GetComponent<Questions>().getScore();
		resultsOn = res; 
	}
	
	void OnGUI() {
		if(resultsOn == true)	{
			ViewResults();	
		}
		
		if(mapOn == true)
			MapMenu();
	}
	
	private void ViewResults()
	{	
		GUI.skin = resultsGUI;
		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 648.0f, Screen.height / 365.0f, 1));
		GUI.DrawTexture(new Rect(174,100,300,150),resultsShadow);
		GUI.Label(new Rect(230,140,500,100),"Prairie Bucks Earned:  " + pointsEarned);
		if(GUI.Button(new Rect(189,188,126,47),"","PlayAgainButton"))	{
			Application.LoadLevel("trivia_minigame");
			settingsData.GetComponent<GameSettings>().menuClick.Play();
		}
		if(GUI.Button(new Rect(332,188,126,47),"","MapButton"))	{
			resultsOn = false;
			mapOn = true;
			settingsData.GetComponent<GameSettings>().menuClick.Play();
		}
	}
	
	private void MapMenu() {
		
		GUI.skin = mapGUISkin;
		GUI.DrawTexture(new Rect(0,0,648,365),backgroundImage);
		GUI.DrawTexture(new Rect(26,26,590,310),behindTransparent);
		GUI.DrawTexture(new Rect(162,54,375,264),mapTexture);
		
		if(GUI.Button(new Rect(32,278,126,47),"","BackButton"))	{
			mapOn = false;
			resultsOn = true;
			settingsData.GetComponent<GameSettings>().menuClick.Play();
		}
		if(GUI.Button(new Rect(32,230,126,47),"","SimButton"))	{
			Application.LoadLevel("animal_simulator");
			Time.timeScale = 1;
			settingsData.GetComponent<GameSettings>().menuClick.Play();
		}
		
		if(GUI.Button(new Rect(160,46,117,110),"","TrainButton"))	{
			Application.LoadLevel("trainRide_minigame");
			Time.timeScale = 1;
			settingsData.GetComponent<GameSettings>().menuClick.Play();
		}
		
		if(GUI.Button(new Rect(280,210,117,110),"","SlideButton"))	{
			Application.LoadLevel("Slide");
			Time.timeScale = 1;
			settingsData.GetComponent<GameSettings>().menuClick.Play();
		}
		if(GUI.Button(new Rect(447,87,117,110),"","TriviaButton"))	{
			Application.LoadLevel("trivia_minigame");
			Time.timeScale = 1;
			settingsData.GetComponent<GameSettings>().menuClick.Play();
		}
	}
}
