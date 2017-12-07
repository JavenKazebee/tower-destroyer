using UnityEngine;
using System.Collections;

public class PathSelector : MonoBehaviour {
	public GameObject[] startPoints;

	public void changeStartNode(int newStartPoint) {
		GameObject startNode = GameObject.FindGameObjectWithTag ("StartPoint");
		startNode.tag = "OptionalStartPoint";
		startPoints[newStartPoint].tag = "StartPoint";
	}
}
