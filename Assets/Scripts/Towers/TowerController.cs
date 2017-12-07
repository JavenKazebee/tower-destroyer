using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour {
	// Var for keeping track of current tower state
	int state;
	// The target
	public GameObject target = null;
	// This objects collider
	Collider coll;
	// The bullet object
	public GameObject bullet;
	// Things that can change from tower to tower:
	public float fireRate = 0.5f;
	public int damage = 5;
	// The timer
	public float timer = 0;

	void Start() {
		coll = GetComponent<Collider>();
	}


	void OnTriggerStay(Collider other) {
		// Check if it's tag is correct
		if( other.CompareTag( "Offense") ) {
			// If there is no target, set the target to the entity
			if(target == null) {
				target = other.gameObject;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		// Check if the entity that left the collider is our target
		if(other.gameObject == target) {
			target = null;
		}
	}

	public void shootAtTarget() {
		// Create and set the bullet's target
		GameObject bulletref = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
		bulletref.GetComponent<BulletController>().setTarget(target);
		bulletref.GetComponent<BulletController> ().setTower (this.gameObject);
	}

	void Update() {
		if(target != null ) {
			timer += Time.deltaTime;
			if(timer > fireRate) {
				shootAtTarget();
				timer = 0;
			}
		}
	}
	public int getDamage() {
		return damage;
	}

	public void onHitEffect(GameObject entity) {

	}
	void chooseNewtarget() {
		target = null;
	}
}
