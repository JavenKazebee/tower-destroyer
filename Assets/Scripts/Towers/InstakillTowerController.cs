using UnityEngine;
using System.Collections;

public class InstakillTowerController : TowerController {

	void Start() {
		this.damage = 150;
		this.fireRate = 2;
	}
	public void onHitEffect(GameObject entity) {
		Destroy (entity);
	}
}
