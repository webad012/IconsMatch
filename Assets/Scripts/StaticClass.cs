using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaticClass
{
	public string web_api_location = "http://alas.matf.bg.ac.rs/~mi08204/projekti/CS_History/cshistoryapi.php";

	public List<GameObject> playingCards = new List<GameObject>();

	public void CardsListToPlayerPrefsArray()
	{
		string[] cards_array = new string[playingCards.Count];

		int count = 0;
		foreach(GameObject card in playingCards)
		{
			CardController cc = card.GetComponent<CardController>();
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

	/*public void PlayerPrefsArrayToCardsList(string[] cards_array, GameObject cardPrefab)
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
				
				GameObject cardObj = (GameObject)Instantiate(cardPrefab);
				cardObj.SetActive(false);
				
				cardObj.GetComponent<CardController>().cardStrength = int.Parse(cardStr);
				cardObj.GetComponent<CardController>().cardSpeed = int.Parse(cardSpd);
				cardObj.GetComponent<CardController>().cardDefense = int.Parse(cardDef);
				cardObj.GetComponent<CardController>().cardHealth = int.Parse(cardHlt);
				cardObj.GetComponent<CardController>().cardName = cardNm;
				cardObj.GetComponent<CardController>().cardInfo = cardInf;
				
				StaticClass.Instance.playingCards.Add( cardObj );
			}

			i++;
		}
	}*/

	protected StaticClass()
	{
		playingCards = new List<GameObject>();
	}
	private static StaticClass _instance = null;
	public static StaticClass Instance
	{
		get
		{
			return StaticClass._instance == null ? new StaticClass() : StaticClass._instance;
		}
	}
}
