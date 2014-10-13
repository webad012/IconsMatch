using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDataController : MonoBehaviour 
{
	//public string web_api_location = "http://alas.matf.bg.ac.rs/~mi08204/projekti/CS_History/cshistoryapi.php";
	
	public GameObject cardPrefab;
	public int numberOfStartingCards = 3;

	//public List<GameObject> playingCards;
	//public List<CardController> playingCards;
	public List<Card> playingCards;

	void Awake()
	{
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () 
	{
		/*if(playingCards == null)
		{
			playingCards = new List<CardController>();
		}*/
		//playingCards = new List<GameObject>();
		//playingCards = new List<CardController>();
		playingCards = new List<Card>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void GenerateStartingCards()
	{
		playingCards.Clear();
		
		for(int i=0; i<numberOfStartingCards; i++)
		{
			//GameObject cardObj = (GameObject)Instantiate(cardPrefab);
			//cardObj.SetActive(false);

			//CardController cc = new CardController();
			Card cc = new Card();
			
			int strength = Random.Range(100, 1000);
			int speed = Random.Range(100, 1000);
			int defense = Random.Range(100, 1000);
			int health = Random.Range(100, 1000);
			string name = "Card"+i.ToString();
			string info = "Info"+i.ToString();
			
			/*cardObj.GetComponent<CardController>().cardStrength = strength;
			cardObj.GetComponent<CardController>().cardSpeed = speed;
			cardObj.GetComponent<CardController>().cardDefense = defense;
			cardObj.GetComponent<CardController>().cardHealth = health;
			cardObj.GetComponent<CardController>().cardName = name;
			cardObj.GetComponent<CardController>().cardInfo = info;*/
			cc.cardStrength = strength;
			cc.cardSpeed = speed;
			cc.cardDefense = defense;
			cc.cardHealth = health;
			cc.cardName = name;
			cc.cardInfo = info;
			
			//playingCards.Add( cardObj );
			playingCards.Add( cc );
		}

		CardsListToPlayerPrefsArray();
	}

	public void CardsListToPlayerPrefsArray()
	{
		string[] cards_array = new string[playingCards.Count];
		
		int count = 0;
		//foreach(GameObject card in playingCards)
		//foreach(CardController cc in playingCards)
		foreach(Card cc in playingCards)
		{
			//CardController cc = card.GetComponent<CardController>();
			string cardString = "name:"+cc.cardName;
			cardString += "|info:"+cc.cardInfo;
			cardString += "|strength:"+cc.cardStrength;
			cardString += "|defense:"+cc.cardDefense;
			cardString += "|speed:"+cc.cardSpeed;
			cardString += "|health:"+cc.cardHealth;
			
			cards_array[count] = cardString;
			count++;
		}
		
		PlayerPrefsX.SetStringArray("Cards", cards_array);
	}
	
	public void PlayerPrefsArrayToCardsList(string[] cards_array)
	{
		int i = 0;
		foreach(string card in cards_array)
		{
			bool gotName = false, gotInfo = false, gotStr = false, gotDef = false, gotSpd = false, gotHlt = false;
			string cardNm = "", cardInf = "", cardStr = "", cardDef = "", cardSpd = "", cardHlt = "";

			string[] stats = card.Split('|');
			foreach(string stat in stats)
			{
				string[] splitedStat = stat.Split(':');
				if(splitedStat[0] == "name")
				{
					cardNm = splitedStat[1];
					gotName = true;
				}
				else if(splitedStat[0] == "info")
				{
					cardInf = splitedStat[1];
					gotInfo = true;
				}
				else if(splitedStat[0] == "strength")
				{
					cardStr = splitedStat[1];
					gotStr = true;
				}
				else if(splitedStat[0] == "defense")
				{
					cardDef = splitedStat[1];
					gotDef = true;
				}
				else if(splitedStat[0] == "speed")
				{
					cardSpd = splitedStat[1];
					gotSpd = true;
				}
				else if(splitedStat[0] == "health")
				{
					cardHlt = splitedStat[1];
					gotHlt = true;
				}
			}
			
			if( !gotName || !gotInfo || !gotStr || !gotDef || !gotSpd || !gotHlt )
			{
				Debug.Log("Not all stats present: " + card);
			}
			else
			{
				
				/*GameObject cardObj = (GameObject)Instantiate(cardPrefab);
				cardObj.SetActive(false);
				
				cardObj.GetComponent<CardController>().cardStrength = int.Parse(cardStr);
				cardObj.GetComponent<CardController>().cardSpeed = int.Parse(cardSpd);
				cardObj.GetComponent<CardController>().cardDefense = int.Parse(cardDef);
				cardObj.GetComponent<CardController>().cardHealth = int.Parse(cardHlt);
				cardObj.GetComponent<CardController>().cardName = cardNm;
				cardObj.GetComponent<CardController>().cardInfo = cardInf;
				
				playingCards.Add( cardObj );*/

				//CardController cc = new CardController();
				Card cc = new Card();

				cc.cardStrength = int.Parse(cardStr);
				cc.cardSpeed = int.Parse(cardSpd);
				cc.cardDefense = int.Parse(cardDef);
				cc.cardHealth = int.Parse(cardHlt);
				cc.cardName = cardNm;
				cc.cardInfo = cardInf;

				playingCards.Add( cc );
			}

			i++;
		}
	}
}
