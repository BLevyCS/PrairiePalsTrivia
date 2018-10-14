using UnityEngine;
using System.Collections;

public class Questions : MonoBehaviour {
	public string currentQuestion;
	public int score;
	public int questionNum;
	public int questionScore;
	public ArrayList questions;
	public int remainingQuestions;
	public string[] originalQuestions;
	public int numOriginQs;
	
	public bool useDefaultQuestions;
	
	private CallQuestions questionsGetter;
	// Use this for initialization
	void Start () {
		currentQuestion = "";
		useDefaultQuestions = false;
		score = 0;
		questionNum = 0;
		questionScore = 3;
		questions = new ArrayList();
		
		//Game Object is loaded from the Title Screen Menu
		if(GameObject.Find("gameQuestions") != null)
			questionsGetter = (CallQuestions)GameObject.Find("gameQuestions").GetComponent("CallQuestions");
		else
			questionsGetter = null;
		
		/////////////////////
		if(questionsGetter != null) //If question file not found
		{
			if(questionsGetter.completedQuestions() == true) //is it complete?
				{ questions = questionsGetter.sendQuestions(); }	
			else
				useDefaultQuestions = true; //not complete, use old questions
		}
		else
			useDefaultQuestions = true; //object not there, use old questions
		/////////////////////////////
		
		if(useDefaultQuestions == true)
		{
			questions.Add("Question 1 Answer Aaa?;" 		+"aaa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 2 Answer Kaa?;" 		+"kaa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 3 Answer Laa?;" 		+"laa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 4 Answer Maa?;" 		+"maa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 5 Answer Naa?;" 		+"naa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 6 Answer Oaa?;" 		+"oaa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 7 Answer Paa?;" 		+"paa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 8 Answer Qaa?;" 		+"qaa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 9 Answer Raa?;" 		+"raa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 10 Answer Saa?;" 		+"saa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 11 Answer Taa?;" 		+"taa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 12 Answer Uaa?;" 		+"uaa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 13 Answer Vaa?;" 		+"vaa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 14 Answer Waa?;" 		+"waa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 15 Answer Xaa?;" 		+"xaa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 16 Answer Yaa?;" 		+"yaa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 17 Answer Zaa?;" 		+"zaa,  baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 18 Answer ABaa?;" 	+"abaa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 19 Answer ACaa?;" 	+"acaa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
			questions.Add("Question 20 Answer ADaa?;" 	+"adaa, baa, caa, daa, eaa, faa, gaa, haa, iaa, jaa");
		}
				
		remainingQuestions = questions.Count;
		originalQuestions = new string[remainingQuestions];
		questions.CopyTo(originalQuestions);
		numOriginQs = remainingQuestions;
	}

	
	public string askQuestion () {
		//float stuff = Mathf.Floor(Random.value * 22);
		remainingQuestions = questions.Count;
		//print(remainingQuestions);
		if(remainingQuestions < 1)
		{
			//print("no questions");
			for(int i = 0; i < numOriginQs; i++)
			{
				questions.Add(originalQuestions[i]);
				//print("adding " + originalQuestions[i]);
			}
			remainingQuestions = questions.Count;
		}
		//print("After if state");
		float questAskF = Mathf.Floor(Random.value * remainingQuestions);
		int questAsk = (int)questAskF;
		currentQuestion = (string)questions[questAsk];
		//print(currentQuestion);
		questions.RemoveAt(questAsk);
		return currentQuestion;
	}
	
	public string getQuestion() {
		return currentQuestion;
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void wrongAnswer()
	{
		questionScore--;
	}
	public void rightAnswer()
	{
		questionScore = 3;
	}
	public int getQuestionScore()
	{
		return questionScore;
	}
	public void incrementScore() {
		score+=questionScore;
	}
	public int getScore() {
		return score;
	}
	public void resetScore()
	{
		score = 0;
	}
	public void incrementQuestion() {
		questionNum++;
	}
	public int getQuestionNum() {
		return questionNum;
	}
	public void resetQuestions() {
		questionNum = 0;
	}
}
