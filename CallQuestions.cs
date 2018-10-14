using UnityEngine;
using System.Collections;

public class CallQuestions : MonoBehaviour {
	
	public string text; //temp text display
	private WWW dataURL; //URL that contains the questions
	private string stringURL; //The URL address
	public string[] parseQuestions; //questions that have or will be correctly parsed
	public string[] convertQuestions; //question and answers that will be converted
	public int questIndex; //Index size of the total number of questions
	
	public float loadTime;
	public float maxLoadTime;
	
	
	public ArrayList finishedQuestions;
	public bool parseTextFinished;
	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Use this for initialization
	void Start () {
		questIndex = 0; 
		loadTime = 0;
		maxLoadTime = 30;
		parseTextFinished = false;
		stringURL = "http://prairie-pals.com/trivia/trivia.txt";
		if(stringURL != null)
		{
			dataURL = new WWW(stringURL);
		}
		finishedQuestions = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		if(dataURL.isDone && parseTextFinished == false && loadTime < maxLoadTime) //Prevents parseText() being called more than once
			parseText();
		
		if(loadTime < maxLoadTime)
			loadTime += Time.deltaTime;
	}
	
	private void parseText()	{
		text = dataURL.text;  //collect the data from the internet
		parseQuestions = text.Split('\n'); //split the questions based on \n
		
		while(questIndex+1 < parseQuestions.Length) { //Keep going until all the questions are parsed
			
			convertQuestions = parseQuestions[questIndex].Split(',');
			convertQuestions[0] = convertQuestions[0] + "; ";
			
			for(int i = 1; i < 10;i++)
				convertQuestions[i] += ", ";
			
			parseQuestions[questIndex] = string.Join("",convertQuestions);
			convertQuestions = null;
			questIndex++;
		}
		for(int i = 0; i < parseQuestions.Length - 1; i++)
			finishedQuestions.Add(parseQuestions[i]);
		
		parseTextFinished = true;
		
	}
	//sends the parsed questions
	public ArrayList sendQuestions()	{return finishedQuestions;}
	public bool completedQuestions() { return parseTextFinished; } //Notifies if completed
	public float getLoadTime() { return loadTime; }
}
