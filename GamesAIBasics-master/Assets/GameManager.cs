using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 

{
	public int AmmoCount = 10; //ammo value for shooting stored in steeringbehaviour script, reduce ammo in AttackingState script when lazer shoots.
	public int BotCount = 5;		//ammo seek when below or equal 0 in steering behaviour script update.
	public int HealthCount = 4;
	public GameObject Ammo;
	public GameObject Bot;
	public GameObject Health;

	GameObject Other;

	Vector3 StartLocation;
	Quaternion StartRotation;


	// Use this for initialization
	void Start () 
	{


		for (int i = 0; i < AmmoCount; i++)  //instantiate Ammot prefab to 10
		{
			StartLocation = new Vector3(Random.Range(-250,250),Random.Range(1,20),Random.Range (-250,250));  //limit random area
			StartRotation = new Quaternion(0,Random.Range(0,360),0,0);
			Instantiate(Ammo, StartLocation, StartRotation);

		}

		for (int i = 0; i < BotCount; i++)  //instantiate Bot prefab to 5
		{
			GameObject BlueBot;
			StartLocation = new Vector3(Random.Range(-250,250),Random.Range(1,20),Random.Range (-250,250));  //limit random area
			StartRotation = new Quaternion(0,Random.Range(0,360),0,0);
			Other = GameObject.FindGameObjectWithTag("teaser");
			BlueBot = Instantiate(Bot, StartLocation, StartRotation) as GameObject; 
			BlueBot.GetComponent<StateMachine>().SwitchState(new IdleState(BlueBot, Other));  //call idlestate on instantiate
			BlueBot.GetComponent<SteeringBehaviours>().maxSpeed = Random.Range(15,30); 
		}

		for (int i = 0; i < HealthCount; i++)  //instantiate health prefab to 4
		{
			StartLocation = new Vector3(Random.Range(-250,250),Random.Range(1,20),Random.Range (-250,250));  //limit random area
			StartRotation = new Quaternion(0,Random.Range(0,360),0,0);
			Instantiate(Health, StartLocation, StartRotation);
			
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
		//Other = GameObject.FindGameObjectWithTag("teaser");
		//Other.GetComponent<StateMachine>().SwitchState(new IdleState(Other, Other));
	}
}
