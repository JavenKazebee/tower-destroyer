using UnityEngine;
using System.Collections;

public class SniperTowerController : TowerController {

	void Start() {
		this.damage = 15;
		this.fireRate = 3f;
	}
}
