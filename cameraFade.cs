using UnityEngine;
using System.Collections;

public class cameraFade : MonoBehaviour
{
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.3f;

	public int drawDepth = -1000;
	
	private float alpha = 1.0f;

	private int fadeDir = -1;
	
	private Color fadeColor = GUI.color;

	// Use this for initialization
	void Start ()
	{
		alpha=1.0f;
   		fadeIn();
		
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnGUI(){
   
	    alpha += fadeDir * fadeSpeed * Time.deltaTime; 
	    alpha = Mathf.Clamp01(alpha);   
	   
		fadeColor.a = alpha;
	    GUI.color = fadeColor;
	   
	    GUI.depth = drawDepth;
	   
	    GUI.DrawTexture(new Rect(0, 0, Screen.width+10, Screen.height), fadeOutTexture);
	}
	
	void fadeIn(){
	    fadeDir = -1; 
	    Debug.Log("fading in");  
	}
	
	//--------------------------------------------------------------------
	
	void fadeOut(){
	    fadeDir = 1;  
	    Debug.Log("fading out"); 
	}
}

