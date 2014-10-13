using UnityEngine;
using System.Collections;

public class MainMenuControllerScript : MonoBehaviour 
{
	public GameObject menuWindow;
	public GameObject messageWindow;

	public UILabel cardsButtonLabel;
	public UILabel messageWindowLabel;


	// Use this for initialization
	void Start () 
	{
		messageWindow.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void MessageOK()
	{
		//messageWindowLabel.text = "";
		//messageWindow.SetActive(false);
		Debug.Log("I was clicked!");
		//lastActionMessage = "Processing";
		//	TweenPosition.Begin(messageWindow, 2f, messageWindowHiddenPos);
		//StartCoroutine ( GetRandom3Cards() );
	}

	public void ButtonCards()
	{
		Application.LoadLevel("CardsScene");
	}
}
