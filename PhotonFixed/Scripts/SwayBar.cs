﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SwayBar : MonoBehaviour {

	public WheelCollider WheelL;
	public WheelCollider WheelR:
	public float AntiRoll = 5000.0f;

	Rigidbody rbody; //this is needed for Unity 5 now

	void Awake()
	{
		OnSerializeRigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		WheelHit hit;
		float travelL = 1.0f;
		float travelR = 1.0f;

		bool groundedL = WheelL.GetGroundHit(out hit);
		if(goundedL)
			travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius)/ WheelL.suspensionDistance;

		bool groundedR = WheelR.GetGroundHit(out hit);
		if(goundedR)
			travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius)/ WheelR.suspensionDistance;

		float antiRollForce = (travelL - travelR) * AntiRoll;

		if (groundedL)
			rbody.AddForceAtPosition(WheelL.transform.up * -antiRollForce, WheelL.transform.position);

		if (groundedR)
			rbody.AddForceAtPosition(WheelR.transform.up * -antiRollForce, WheelR.transform.position);

	}
}
