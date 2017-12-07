using UnityEngine;
using System.Collections;

public class StrongEntityController : EntityController {

	void Start() {
		this.health = 25;
		this.speed = 1;
		this.cost = 15;
	}
}
