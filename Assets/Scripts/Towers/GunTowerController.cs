using UnityEngine;
using System.Collections;

public class GunTowerController : TowerController {

	void Start() {
		this.damage = 1;
		this.fireRate = 0.2f;
	}
}
