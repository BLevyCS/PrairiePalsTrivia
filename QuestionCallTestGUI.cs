using UnityEngine;
using System.Collections;

public class QuestionCallTestGUI : MonoBehaviour {
	
	public string text;
	public bool dataLoaded;
	private WWW dataURL;
	private string stringURL;
	public string[] parseQuestions;
	public string[] convertQuestions;
	public int questIndex;
	
	private bool parseTextFinished;
	
	// Use this for initialization
	void Start () {
		text = "Test";
		questIndex = 0;
		parseTextFinished = false;
		stringURL = "http://prairie-pals.com/trivia/trivia.txt";
		dataURL = new WWW(stringURL);
	}
	
	// Update is called once per frame
	void Update () {
		if(dataURL.isDone && parseTextFinished == false)
			parseText();
		
		if(dataURL.isDone == false)
			text = "Loading Data, please wait...";
	}
	
	void OnGUI() {
		GUILayout.BeginArea(new Rect(10, 10, Screen.width,Screen.height));
		if(parseTextFinished)
			GUILayout.Label(parseQuestions[0]);
		GUILayout.EndArea();
	}
	
	private void parseText()	{
		text = dataURL.text;
		parseQuestions = text.Split('\n');
		
		while(questIndex+1 < parseQuestions.Length) {
			
			convertQuestions = parseQuestions[questIndex].Split(',');
			convertQuestions[0] = convertQuestions[0] + "; ";
			
			for(int i = 1; i < 10;i++)
				convertQuestions[i] += ", ";
			
			parseQuestions[questIndex] = string.Join("",convertQuestions);
			convertQuestions = null;
			questIndex++;
		}
		parseTextFinished = true;
		
	}
	
}
