using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardsSceneControllerScript : MonoBehaviour 
{
	//public GameObject cardPrefab;
	public GameObject panelForCards;
	public UILabel cardInfoLabel;
	
	public float stackingPosX;
	public float stackingPosY;

	private List<GameObject> cardsList;

	private enum SceneStatus{CardSelected, Normal};
	private SceneStatus sceneStatus;

	private Vector3 selectedCardOldPosition;

	private float transitionSpeed = 0.3f;

	private GameDataController gdc;

	// Use this for initialization
	void Start () 
	{
		gdc = GameObject.FindGameObjectWithTag("GameDataController").GetComponent<GameDataController>();

		sceneStatus = SceneStatus.Normal;

		cardsList = new List<GameObject>();

		for(int i=0; i<gdc.playingCards.Count; i++)
		{
			GameObject cardObj = NGUITools.AddChild(panelForCards, gdc.cardPrefab);
			cardObj.transform.localScale = new Vector3(0.5f, 0.5f, 1f);

			cardObj.GetComponent<CardController>().cardStrength = gdc.playingCards[i].cardStrength;
			cardObj.GetComponent<CardController>().cardSpeed = gdc.playingCards[i].cardSpeed;
			cardObj.GetComponent<CardController>().cardDefense = gdc.playingCards[i].cardDefense;
			cardObj.GetComponent<CardController>().cardHealth = gdc.playingCards[i].cardHealth;
			cardObj.GetComponent<CardController>().cardName = gdc.playingCards[i].cardName;
			cardObj.GetComponent<CardController>().cardInfo = gdc.playingCards[i].cardInfo;

			cardObj.GetComponent<UIButtonMessage>().target = this.gameObject;

			cardObj.transform.localPosition = new Vector3( stackingPosX+i*250 , stackingPosY );

			cardsList.Add( cardObj );
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void CardSClicked(GameObject go)
	{
		if( sceneStatus == SceneStatus.Normal )
		{
			selectedCardOldPosition = go.transform.localPosition;

			sceneStatus = SceneStatus.CardSelected;
			TweenPosition.Begin(panelForCards, transitionSpeed, new Vector3(0f, -600f, 0f));
			TweenPosition.Begin(go, transitionSpeed, new Vector3(170f, 600f, 0f));
			TweenScale.Begin(go, transitionSpeed, Vector3.one);

			cardInfoLabel.text = go.GetComponent<CardController>().cardInfo;
			//cardInfoLabel.gameObject.SetActive(true);
		}
		else if( sceneStatus == SceneStatus.CardSelected )
		{
			//selectedCardOldPosition = Vector3.zero;

			sceneStatus = SceneStatus.Normal;
			TweenPosition.Begin(panelForCards, transitionSpeed, Vector3.zero);
			TweenPosition.Begin(go, transitionSpeed, selectedCardOldPosition);
			TweenScale.Begin(go, transitionSpeed, new Vector3(0.5f, 0.5f, 1f));

			//cardInfoLabel.gameObject.SetActive(false);
		}
	}

	public void ButtonBack()
	{
		Application.LoadLevel("MainMenuScene");
	}
}
