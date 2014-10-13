using UnityEngine;
using System.Collections;

public class FirstSceneControllerScript : MonoBehaviour 
{
	public GameObject loadingObject;

	enum Status{Loading, Loaded};

	private Status currentStatus;
	private bool loadingWindowShown = true;

	private GameDataController gdc;

	// Use this for initialization
	void Start () 
	{
		gdc = GameObject.FindGameObjectWithTag("GameDataController").GetComponent<GameDataController>();

		currentStatus = Status.Loading;
		loadingObject.SetActive(true);
		loadingWindowShown = true;

		StartCoroutine ( LoadCards() );
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentStatus == Status.Loading)
		{
			if(loadingWindowShown == false)
			{
				loadingObject.SetActive(true);
				loadingWindowShown = true;
			}
		}
		else if (currentStatus == Status.Loaded)
		{
			Application.LoadLevel("MainMenuScene");
		}
	}

	private IEnumerator LoadCards()
	{
		string[] cardsPrefs = PlayerPrefsX.GetStringArray("Cards");
		
		if(cardsPrefs.Length == 0)
		{
			gdc.GenerateStartingCards();
		}
		else
		{
			gdc.PlayerPrefsArrayToCardsList(cardsPrefs);
		}
		
		currentStatus = Status.Loaded;
		
		yield return null;
	}
}
