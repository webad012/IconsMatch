using UnityEngine;
using System.Collections;

public class CardController : MonoBehaviour 
{
	public int cardStrength;
	public int cardSpeed;
	public int cardDefense;
	public int cardHealth;
	public string cardName;
	public string cardInfo;

	private UILabel nameLabel;
	private UILabel strengthLabel;
	private UILabel speedLabel;
	private UILabel defenseLabel;
	private UILabel healthLabel;

	//private int maxNameSize = 10;

	// Use this for initialization
	void Start () 
	{
		nameLabel = gameObject.transform.FindChild("Name").GetComponent<UILabel>();
		strengthLabel = gameObject.transform.FindChild("Strength").GetComponent<UILabel>();
		speedLabel = gameObject.transform.FindChild("Speed").GetComponent<UILabel>();
		defenseLabel = gameObject.transform.FindChild("Defense").GetComponent<UILabel>();
		healthLabel = gameObject.transform.FindChild("Health").GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		nameLabel.text = cardName;
		strengthLabel.text = "Strength: " + cardStrength.ToString();
		speedLabel.text = "Speed: " + cardSpeed.ToString();
		defenseLabel.text = "Defense: " + cardDefense.ToString();
		healthLabel.text = "Health: " + cardHealth.ToString();
	}
}
