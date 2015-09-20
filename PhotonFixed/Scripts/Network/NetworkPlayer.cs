﻿using UnityEngine;
using System.Collections;

public class NetworkPlayer : Photon.MonoBehaviour 
{

	public GameObject myCamera;


	// Use this for initialization
	void Start () 
	{
		if( photonView.isMine)
		{
			myCamera.SetActive (true);
			GetComponent<Motor>().enabled = true;
		}
		else
		{

		}

	}



}