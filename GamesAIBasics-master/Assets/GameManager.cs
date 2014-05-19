using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 

{
	public int AmmoCount = 10;
	public int BotCount = 5;
	public GameObject Ammo;
	public GameObject Bot;

	Vector3 StartLocation;
	Quaternion StartRotation;


	// Use this for initialization
	void Start () 
	{


		for (int i = 0; i < AmmoCount; i++)  //instantiate Ammot prefab to 10
		{
			StartLocation = new Vector3(Random.Range(-500,500),Random.Range(1,20),Random.Range (-500,500));
			StartRotation = new Quaternion(0,Random.Range(0,360),0,0);
			Instantiate(Ammo, StartLocation, StartRotation);

		}

		for (int i = 0; i < BotCount; i++)  //instantiate Bot prefab to 5
		{
			GameObject BlueBot;
			StartLocation = new Vector3(Random.Range(-500,500),Random.Range(1,20),Random.Range (-500,500));
			StartRotation = new Quaternion(0,Random.Range(0,360),0,0);
			BlueBot = Instantiate(Bot, StartLocation, StartRotation) as GameObject;
			//BlueBot.GetComponent<StateMachine>().SwitchState(new IdleState(Bot, Bot));
		}




        //GameObject leader = GameObject.FindGameObjectWithTag("leader");
        //GameObject teaser = GameObject.FindGameObjectWithTag("teaser");

        //leader.GetComponent<StateMachine>().SwitchState(new IdleState(leader, teaser));
        //teaser.GetComponent<StateMachine>().SwitchState(new TeaseState(teaser, leader));

        //leader.renderer.material.color = Color.red;
        //teaser.renderer.material.color = Color.blue;

        
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
