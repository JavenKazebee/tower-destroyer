using UnityEngine;
using System.Collections;

public class NodeManager : MonoBehaviour {

	GameObject startNode;

	// Use this for initialization
	void Start () {
		startNode = GameObject.FindGameObjectWithTag ("StartPoint");
		if (startNode) 
		{
			for (int i = 0; i < startNode.transform.childCount; i++)
			{
		        Transform child = startNode.transform.GetChild(i);
				Debug.Log ( " child name: " + child.name );
				//if ( child.CompareTag ("SwitchPoint") )
				{
					for (int j = 0; j < child.childCount; j++)
					{
						Transform childsChild = child.GetChild(j);
						Debug.Log ( " child name: " + childsChild.name );
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
