//============================================================================================================
// Weili Zhi Copy right reserved.
//============================================================================================================
/// Action Base
//============================================================================================================
// Created on 18/7/2012 9:06:52 AM by Weili Zhi
//============================================================================================================
using UnityEngine;
using System;
using System.Collections.Generic;

public class AttackShipData
{
	private LinkedList<Transform> mTargets = new LinkedList<Transform>();
	
	private void FillShipTargetPosition(GameObject ship)
	{
		Transform targets = ship.transform.Find("AttackPoints");
		if( targets!= null ) {
			Transform tfTarget = targets.Find("AttackPointH");
			if( tfTarget != null ) {
				mTargets.AddFirst(tfTarget);
			}
			else return;
			
			Transform tfNext = targets.Find("AttackPointR");
			if( tfNext != null ) {
				mTargets.AddLast(tfNext);
			}
			else return;
			
			GameShip script = ship.GetComponent<GameShip>();
			if( script != null ) {
				GameObject nextShip = script.NextShip;
				if( nextShip != null )
				{
					FillShipTargetPosition(nextShip);
				}
				else {
					tfNext = targets.Find("AttackPointT");
					if( tfNext != null ) {
						mTargets.AddLast(tfNext);
					}
					else return;
				}
			}
			else {
				Debug.Log("Ship " + ship.name + " doesn't have GameShip script");
				return;
			}
			tfNext = targets.Find("AttackPointL");
			if( tfNext != null ) {
				mTargets.AddLast(tfNext);
			}
			return;
		}
	}
}

