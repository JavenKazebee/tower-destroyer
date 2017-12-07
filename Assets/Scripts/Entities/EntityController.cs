using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class EntityController : MonoBehaviour {
	GameObject player;
	bool targetReached = true;
	public GameObject currentTarget;
	public Node currentNode;
	public float threshold = 0.05f; 
	public float speed;
	public int health = 3;
	public int cost = 15;

	GameController ourGameC;

	void Update(){
		if (Input.GetKeyDown(KeyCode.R)) {
			ActivateTarget();
		}
		EntityMove();
	}
	public void ActivateTarget(){
		GameObject startNode = GameObject.FindGameObjectWithTag ("StartPoint");
		if (startNode) {
			currentNode = startNode.GetComponent<Node>();
			if (currentNode) {
				currentTarget = currentNode.gameObject;
			}
		}
		player = gameObject;
	}

	void Start()
	{
		GameObject tempGO = GameObject.FindGameObjectWithTag ("GameController");
		if (tempGO) {
			ourGameC = tempGO.GetComponent<GameController> ();
		}
	}

	public void OnSpawn (){
		
	}

	public void EntityMove(){
		if(currentTarget)
		{
		player.transform.position = Vector2.MoveTowards(player.transform.position, currentTarget.transform.position, Time.deltaTime * speed);
		float distance = Vector2.Distance(player.transform.position, currentTarget.transform.position);
		if (distance < threshold) {
			FindNewTarget();
			}
		}
	}

	void FindNewTarget ()
	{
		if (currentNode.CompareTag( "EndPoint") ) 
		{
			ourGameC.escaped+= 1;
			Destroy(this.gameObject);
			ourGameC.LevelWin();
			//perform end point things
			return;
		} else if (currentNode.nextNodes.Count > 1) {
			int randNewNode = Random.Range(0, currentNode.nextNodes.Count);
			//Debug.Log ( "our new Node index : " + randNewNode ); 
			currentNode = currentNode.nextNodes [randNewNode];
			currentTarget = currentNode.gameObject;

		} else if(currentNode.nextNodes.Count > 0)
		{
			currentNode = currentNode.nextNodes [0];
			currentTarget = currentNode.gameObject;
		}

	}

	void OnTriggerEnter(Collider other){
		OnHit (other);
	}





	void OnDeath()
	{
		
	}

	void OnHit(Collider other) {
		if(other.CompareTag("Bullet")){
			GameObject tower = other.GetComponent<BulletController>().getTower();
			int damage = tower.GetComponent<TowerController>().getDamage();
			//tower.SendMessage("OnHitEffect", this.gameObject);
			tower.GetComponent<TowerController>().onHitEffect(this.gameObject);
			health -= damage;
			Destroy(other.gameObject);
			if(health <= 0){
				Destroy(this.gameObject);
			}
		}
	}
	public int getCost() {
		return cost;
	}
}
