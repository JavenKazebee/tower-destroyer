using UnityEngine;
using System.Collections;

public class FastEntityController : EntityController {

	// Use this for initialization
	void Start () {
		this.health = 2;
		this.speed = 5;
		this.cost = 10;
	}

}
