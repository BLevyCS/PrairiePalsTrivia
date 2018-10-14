using UnityEngine;
using System.Collections;

public class AnswerChosen : MonoBehaviour {
	public TextMesh ansTextA;
	public TextMesh ansTextB;
	public TextMesh ansTextC;
	public TextMesh ansTextD;
	public TextMesh corrAnswer;
	public TextMesh givenAnswer;
	public TextMesh question;
	public TextMesh score;
	public TextMesh questionTrack;
	public TextMesh possibleScore;
	public bool derp;
	public Vector3 defPos;
	public GameObject settingsData;
	public GameObject saver;
	

		
	
	
	// Use this for initialization
	void Start () {
		saver= GameObject.Find("Saver");
		defPos = GameObject.Find("default").transform.position;
		derp = false;
		settingsData = GameObject.Find("gameSettings");
		ansTextA.name = "";
		ansTextB.name = "";
		ansTextC.name = "";
		ansTextD.name = "";
		corrAnswer.name = "";
		givenAnswer.name = "";
		question.name = "";
		score.name = "";
		questionTrack.name = "";
		possibleScore.name = "";
		ansTextA.text = " ";
		ansTextB.text = " ";
		ansTextC.text = " ";
		ansTextD.text = " ";
		corrAnswer.text = " ";
		givenAnswer.text = " ";
		question.text = " ";
		score.text = " ";
		questionTrack.text = " ";
		possibleScore.text = " ";
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		print("Trig enter");
		
		// GameObject buttonZ = GameObject.Find("trivia_button");
		// (buttonZ.GetComponent("C2M") as C2M).goButton = false;
		int questionsAsked = Camera.main.GetComponent<Questions>().getQuestionNum();
		string choice = this.name;
		print("ENTER "+choice);
		if(Camera.main.GetComponent<TriviaGame>().gameStart)
		{
			print("Game started is true");
			choice = this.name;
			if (choice == "ACube")
			{
				print("aaaaa" + choice);
				//print("In contact with " + choice);
				if(Answer(ansTextA.text)){
					if(questionsAsked < 10)
					{
						Question();
					}
					else
					{
						givenAnswer.text = " ";
						corrAnswer.text = " ";
						ansTextA.text = " ";
						ansTextB.text = " ";
						ansTextC.text = " ";
						ansTextD.text = " ";
						question.text = " ";
						(saver.GetComponent("saveBucks") as saveBucks).saveBuck(Camera.main.GetComponent<Questions>().getScore());
						Camera.main.GetComponent<TriviaResults>().getResultsOn(true);
						Camera.main.GetComponent<Questions>().resetScore();
						Camera.main.GetComponent<Questions>().resetQuestions();
						Camera.main.GetComponent<TriviaGame>().gameStart = false;
					}
				}
				else
				{
					ansTextA.text = "Wrong answer";
				}
				Revert(other);
			}
			else if (choice == "buttonB")
			{
				//print(choice);
				//print("In contact with " + choice);
				if(Answer(ansTextB.text)){
					if(questionsAsked < 10)
					{
						Question();
					}
					else
					{
						givenAnswer.text = " ";
						corrAnswer.text = " ";
						ansTextA.text = " ";
						ansTextB.text = " ";
						ansTextC.text = " ";
						ansTextD.text = " ";
						question.text = " ";
						(saver.GetComponent("saveBucks") as saveBucks).saveBuck(Camera.main.GetComponent<Questions>().getScore());
						Camera.main.GetComponent<TriviaResults>().getResultsOn(true);
						Camera.main.GetComponent<Questions>().resetScore();
						Camera.main.GetComponent<Questions>().resetQuestions();
						Camera.main.GetComponent<TriviaGame>().gameStart = false;
					}
				}
				else
				{
					ansTextB.text = "Wrong answer";
				}
				Revert(other);
			}
			else if (choice == "buttonC")
			{
				//print(choice);
				//print("In contact with " + choice);
				if(Answer(ansTextC.text)){
					if(questionsAsked < 10)
					{
						Question();
					}
					else
					{
						givenAnswer.text = " ";
						corrAnswer.text = " ";
						ansTextA.text = " ";
						ansTextB.text = " ";
						ansTextC.text = " ";
						ansTextD.text = " ";
						question.text = " ";
						(saver.GetComponent("saveBucks") as saveBucks).saveBuck(Camera.main.GetComponent<Questions>().getScore());
						Camera.main.GetComponent<TriviaResults>().getResultsOn(true);
						Camera.main.GetComponent<Questions>().resetScore();
						Camera.main.GetComponent<Questions>().resetQuestions();
						Camera.main.GetComponent<TriviaGame>().gameStart = false;
					}
				}
				else
				{
					ansTextC.text = "Wrong answer";
				}
				Revert(other);
			}
			else if (choice == "buttonD")
			{
				//print(choice);
				//print("In contact with " + choice);
				if(Answer(ansTextD.text)){
					if(questionsAsked < 10)
					{
						Question();
					}
					else
					{
						givenAnswer.text = " ";
						corrAnswer.text = " ";
						ansTextA.text = " ";
						ansTextB.text = " ";
						ansTextC.text = " ";
						ansTextD.text = " ";
						question.text = " ";
						(saver.GetComponent("saveBucks") as saveBucks).saveBuck(Camera.main.GetComponent<Questions>().getScore());
						Camera.main.GetComponent<TriviaResults>().getResultsOn(true);
						Camera.main.GetComponent<Questions>().resetScore();
						Camera.main.GetComponent<Questions>().resetQuestions();
						Camera.main.GetComponent<TriviaGame>().gameStart = false;
					}
				}
				else
				{
					ansTextD.text = "Wrong answer";
				}
				Revert(other);
			}
		}
		
	}
	// Update is called once per frame
	void Update () {
		if(!derp)
		{
			//if((GameObject.Find("CinematicCam").GetComponent<cinematicOptions>().levelStart == true) && (Camera.main.GetComponent<Questions>().getScore()==0))
			//{
				ansTextA.text = "Answer A";
				ansTextB.text = "Answer B";
				ansTextC.text = "Answer C";
				ansTextD.text = "Answer D";
				Camera.main.GetComponent<Questions>().resetQuestions();
				score.text = "Score: " + Camera.main.GetComponent<Questions>().getScore();
				FirstQuestion();
				derp = true;
			//}
		}
	}
	
	void Revert (Collider dude)
	{
		
		dude.transform.position = defPos;
//		dude.GetComponent<ClickMove>().SetTargetPos(defPos);
	}
	
	void FirstQuestion() {
		
		string fullQuestion = Camera.main.GetComponent<Questions>().askQuestion();
		//print("Current " +currentQuestion);
		int split = fullQuestion.IndexOf(";");
		string splitQuestion =  fullQuestion.Substring(0, split);
		string[] questionWords = splitQuestion.Split(' ');
		string parsedQuestion = "";

		for (int r = 0; r < questionWords.Length; r++)
		{
			if(r==6)
			{
				parsedQuestion = parsedQuestion + " \n";
			}
			parsedQuestion = parsedQuestion + " " +  questionWords[r];
		}
		question.text = parsedQuestion;
		string[] fullAns = fullQuestion.Substring(split+1).Split(',');
		ArrayList fullAnswers = new ArrayList();
		for(int i = 0; i < 10; i++)
		{
			fullAnswers.Add(fullAns[i]);
		}
		
		string correctAnswer = (string)fullAnswers[0];
		fullAnswers.RemoveAt(0);
		
		float wrongAnswer1 = Mathf.Ceil(Random.value * (fullAnswers.Count -2)+1);
		int wrongAnswer1Int = (int)wrongAnswer1;
		string wrongAnswer1Ans = (string)fullAnswers[wrongAnswer1Int];
		fullAnswers.RemoveAt(wrongAnswer1Int);

		float wrongAnswer2 = Mathf.Ceil(Random.value * (fullAnswers.Count -2)+1);
		int wrongAnswer2Int = (int)wrongAnswer2;
		string wrongAnswer2Ans = (string)fullAnswers[wrongAnswer2Int];
		fullAnswers.RemoveAt(wrongAnswer2Int);

		float wrongAnswer3 = Mathf.Ceil(Random.value * (fullAnswers.Count -2)+1);
		int wrongAnswer3Int = (int)wrongAnswer3;
		string wrongAnswer3Ans = (string)fullAnswers[wrongAnswer3Int];
		fullAnswers.RemoveAt(wrongAnswer3Int);
		
		string[] answers = new string[4] {correctAnswer, wrongAnswer1Ans, wrongAnswer2Ans, wrongAnswer3Ans};
		answers[0] = answers[0].Substring(0,2).ToUpper() + answers[0].Substring(2).ToLower();
		answers[1] = answers[1].Substring(0,2).ToUpper() + answers[1].Substring(2).ToLower();
		answers[2] = answers[2].Substring(0,2).ToUpper() + answers[2].Substring(2).ToLower();
		answers[3] = answers[3].Substring(0,2).ToUpper() + answers[3].Substring(2).ToLower();
		float correctAns = Mathf.Floor(Random.value * 40);
		
		if (correctAns%4 == 0){
			ansTextA.text = answers[0];
			ansTextB.text = answers[1];
			ansTextC.text = answers[2];
			ansTextD.text = answers[3];
		}
		else if (correctAns%4 == 1){
			ansTextA.text = answers[1];
			ansTextB.text = answers[0];
			ansTextC.text = answers[2];
			ansTextD.text = answers[3];
		}
		else if (correctAns%4 == 2){
			ansTextA.text = answers[2];
			ansTextB.text = answers[1];
			ansTextC.text = answers[0];
			ansTextD.text = answers[3];
		}
		else if (correctAns%4 == 3){
			ansTextA.text = answers[3];
			ansTextB.text = answers[1];
			ansTextC.text = answers[2];
			ansTextD.text = answers[0];
		}
		corrAnswer.text = "" ;
		givenAnswer.text = "";
		Camera.main.GetComponent<Questions>().incrementQuestion();
		int questionsAsked = Camera.main.GetComponent<Questions>().getQuestionNum();
		questionTrack.text = "Question # " + questionsAsked;
		Camera.main.GetComponent<Questions>().rightAnswer();
		int questionScore = Camera.main.GetComponent<Questions>().getQuestionScore();
		possibleScore.text = "Points remaining for question: " + questionScore;
		
	}
	void Question() {
		string fullQuestion = Camera.main.GetComponent<Questions>().askQuestion();
		//print("Current "+ currentQuestion);
		int split = fullQuestion.IndexOf(";");
		string splitQuestion =  fullQuestion.Substring(0, split);
		string[] questionWords = splitQuestion.Split(' ');
		string parsedQuestion = "";

		for (int r = 0; r < questionWords.Length; r++)
		{
			if(r==6)
			{
				parsedQuestion = parsedQuestion + " \n";
			}
			parsedQuestion = parsedQuestion + " " +  questionWords[r];
		}
		question.text = parsedQuestion;
		string[] fullAns = fullQuestion.Substring(split+1).Split(',');
		ArrayList fullAnswers = new ArrayList();
		for(int i = 0; i < 10; i++)
		{
			fullAnswers.Add(fullAns[i]);
		}
		
		string correctAnswer = (string)fullAnswers[0];
		fullAnswers.RemoveAt(0);
		
		float wrongAnswer1 = Mathf.Ceil(Random.value * (fullAnswers.Count -2)+1);
		int wrongAnswer1Int = (int)wrongAnswer1;
		string wrongAnswer1Ans = (string)fullAnswers[wrongAnswer1Int];
		fullAnswers.RemoveAt(wrongAnswer1Int);

		float wrongAnswer2 = Mathf.Ceil(Random.value * (fullAnswers.Count -2)+1);
		int wrongAnswer2Int = (int)wrongAnswer2;
		string wrongAnswer2Ans = (string)fullAnswers[wrongAnswer2Int];
		fullAnswers.RemoveAt(wrongAnswer2Int);

		float wrongAnswer3 = Mathf.Ceil(Random.value * (fullAnswers.Count -2)+1);
		int wrongAnswer3Int = (int)wrongAnswer3;
		string wrongAnswer3Ans = (string)fullAnswers[wrongAnswer3Int];
		fullAnswers.RemoveAt(wrongAnswer3Int);
		
		string[] answers = new string[4] {correctAnswer, wrongAnswer1Ans, wrongAnswer2Ans, wrongAnswer3Ans};
		answers[0] = answers[0].Substring(0,2).ToUpper() + answers[0].Substring(2).ToLower();
		answers[1] = answers[1].Substring(0,2).ToUpper() + answers[1].Substring(2).ToLower();
		answers[2] = answers[2].Substring(0,2).ToUpper() + answers[2].Substring(2).ToLower();
		answers[3] = answers[3].Substring(0,2).ToUpper() + answers[3].Substring(2).ToLower();
		float correctAns = Mathf.Floor(Random.value * 40);
		if (correctAns%4 == 0){
			ansTextA.text = answers[0];
			ansTextB.text = answers[1];
			ansTextC.text = answers[2];
			ansTextD.text = answers[3];
		}
		else if (correctAns%4 == 1){
			ansTextA.text = answers[1];
			ansTextB.text = answers[0];
			ansTextC.text = answers[2];
			ansTextD.text = answers[3];
		}
		else if (correctAns%4 == 2){
			ansTextA.text = answers[2];
			ansTextB.text = answers[1];
			ansTextC.text = answers[0];
			ansTextD.text = answers[3];
		}
		else if (correctAns%4 == 3){
			ansTextA.text = answers[3];
			ansTextB.text = answers[1];
			ansTextC.text = answers[2];
			ansTextD.text = answers[0];
		}
		Camera.main.GetComponent<Questions>().incrementQuestion();
		int questionsAsked = Camera.main.GetComponent<Questions>().getQuestionNum();
		questionTrack.text = "Question # " + questionsAsked;
		Camera.main.GetComponent<Questions>().rightAnswer();
		int questionScore = Camera.main.GetComponent<Questions>().getQuestionScore();
		possibleScore.text = "Points remaining for question: " + questionScore;
	}
	bool Answer(string response) {
		//print("quest "+currentQuestion + " resp " + response);
		string currentQuestion = Camera.main.GetComponent<Questions>().getQuestion();
		int split = currentQuestion.IndexOf(';');
		int sizeAns = (currentQuestion.IndexOf(", ") - 1 - split + 1);
		string theAns = currentQuestion.Substring(split+1, sizeAns-1).Trim();
		theAns = theAns.Trim();
		response = response.Trim();
		response = response.ToLower();
		int pointsLeft = Camera.main.GetComponent<Questions>().getQuestionScore();
		//print ("answer "+theAns);
		
		if(theAns.Equals(response))
		{
			settingsData.GetComponent<GameSettings>().collectBuck.Play();
			
			Camera.main.GetComponent<Questions>().incrementScore();
			score.text = "Score: " + Camera.main.GetComponent<Questions>().getScore();
			return true;
		}
		else if ((!(theAns.Equals(response))) && pointsLeft > 1)
		{
			settingsData.GetComponent<GameSettings>().wrongAnswer.Play();
			
			Camera.main.GetComponent<Questions>().wrongAnswer();
			pointsLeft = Camera.main.GetComponent<Questions>().getQuestionScore();
			possibleScore.text = "Points remaining for question: " + pointsLeft;
			return false;
		}
		else if((!(theAns.Equals(response))) && pointsLeft <= 1)
		{
			settingsData.GetComponent<GameSettings>().wrongAnswer.Play();
			return true;
		}
		else
		{
			settingsData.GetComponent<GameSettings>().wrongAnswer.Play();
			return true;
		}
	}
}
