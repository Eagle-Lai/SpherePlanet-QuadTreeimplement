﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum Quad
{
	Up = 0,
	Down = 1,
	Left = 2,
	Right = 3,
	Front = 4,
	Back = 5
}
public class QTPlanet : MonoBehaviour {
	static int Up = 0;
	static int Down = 1;
	static int Left = 2;
	static int Right = 3;
	static int Front = 4;
	static int Back = 5;
	[HideInInspector]
	public float sphereRange = 10f;
	public float sphereRadius = 10f;
	public int maxLodLevel = 4;
	public float cl = 1f;
	public int splitCount = 4;
	public Material mat;
	public List<QTTerrain> quadList;
	// Use this for initialization
	void Awake()
	{
		QTManager.Instance.Enter (this);
	}
	public void Enter()
	{
		sphereRange = sphereRadius * 2f;
		if (splitCount < 1)
			splitCount = 1;
		if (splitCount % 2 != 0&&splitCount!=1)
			splitCount--;
		GameObject go;
		QTTerrain t;
		quadList = new List<QTTerrain> ();
		for (int i = 0; i < 6; i++) {
			go = new GameObject ();
			go.transform.parent = this.transform;
			go.transform.localPosition = Vector3.zero;
			t = go.AddComponent<QTTerrain> ();
			QTManager.Instance.activeTerrain = t;
			t.Init ();
			quadList.Add (t);
		}
		quadList [Up].transform.rotation = Quaternion.Euler (new Vector3 (0f,0f,0f));
		quadList [Down].transform.rotation = Quaternion.Euler (new Vector3 (-180f,0f,0f));
		quadList [Left].transform.rotation = Quaternion.Euler (new Vector3 (0f,0f,90f));
		quadList [Right].transform.rotation = Quaternion.Euler (new Vector3 (0f,0f,-90f));
		quadList [Front].transform.rotation = Quaternion.Euler (new Vector3 (-90f,0f,0f));
		quadList [Back].transform.rotation = Quaternion.Euler (new Vector3 (90f,0f,0f));

	}
	public void Clear()
	{
		quadList = null;
	}
	// Update is called once per frame
}
