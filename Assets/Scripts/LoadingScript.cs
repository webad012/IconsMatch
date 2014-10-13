using UnityEngine;
using System.Collections;

public class LoadingScript : MonoBehaviour 
{
	private float loadingValue = 0f;
	private float multiplicator = 1f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		loadingValue += 0.5f * Time.deltaTime * multiplicator;
		if(loadingValue > 1 || loadingValue < 0)
		{
			multiplicator *= -1;
			//loadingValue = 0f;
		}

		//Debug.Log(loadingValue);

		renderer.material.SetFloat("_Cutoff", loadingValue); 
	}
}
