using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState:State
{
    //static Vector3 initialPos = Vector3.zero;

    GameObject enemyGameObject;

    public override string Description()
    {
        return "Idle State";
    }

    public IdleState(GameObject myGameObject, GameObject enemyGameObject)
        : base(myGameObject)
    {
        this.enemyGameObject = enemyGameObject;
    }

    public override void Enter()
    {
		GameObject enemyOther = GameObject.FindGameObjectWithTag("teaser");
		if(enemyOther != this.myGameObject)
		{
		enemyGameObject = enemyOther;
		}
		else
		{
			enemyGameObject =  GameObject.FindGameObjectWithTag("teaser");
		}

		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(UnityEngine.Random.Range(-250,250),UnityEngine.Random.Range(1,20),UnityEngine.Random.Range (-250,250)));
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(UnityEngine.Random.Range(-250,250),UnityEngine.Random.Range(1,20),UnityEngine.Random.Range (-250,250)));
        //myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(0, 0, 20));
        //myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(25, 0, -10));
        myGameObject.GetComponent<SteeringBehaviours>().path.Looped = true;            
        myGameObject.GetComponent<SteeringBehaviours>().path.draw = true;
        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
        myGameObject.GetComponent<SteeringBehaviours>().FollowPathEnabled = true;
    }
    public override void Exit()
    {
        myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Clear();
    }

    public override void Update()
    {
		GameObject enemyOther = GameObject.FindGameObjectWithTag("teaser");
		if(enemyOther != this.myGameObject)
		{
			enemyGameObject = enemyOther;
		}
        float range = 75.0f;           
        // Can I see the enemy?
        if ((enemyGameObject.transform.position - myGameObject.transform.position).magnitude < range)
        {
            // Is the leader inside my FOV
            myGameObject.GetComponent<StateMachine>().SwitchState(new AttackingState(myGameObject, enemyGameObject));
        }
    }
}
