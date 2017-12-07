using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public GameObject target;
	Vector2 targetPos;
	Transform trans;
	public float speed;
	GameObject tower;

	public void setTarget(GameObject pTarget) {
		this.target = pTarget;
	}
	public void setTower(GameObject theTower) {
		tower = theTower;
	}
	public GameObject getTower() {
		return tower;
	}
	public void setSpeed(float pSpeed) {

	}
	void Update() {
		if (target == null) {
			Destroy (this.gameObject);
		} else {
			targetPos = target.transform.position;
			transform.position = Vector2.MoveTowards( trans.position, targetPos, speed * Time.deltaTime);
		}

	}
	void Start() {
		trans = GetComponent<Transform>();
	}
}
