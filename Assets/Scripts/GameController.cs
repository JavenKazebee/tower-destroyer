using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour /*EntityController*/ {
	public GameObject StartNode;
	public int Energy = 80;
	public int energyRegenSpeed = 10;
	public Text energyText;
	float timeLimit = 1.0f;
	public Text escapeText;
	public int escaped;
	public int levelWinScore;
	
	// Use this for initialization
	void Start () {
		Energy += PlayerPrefs.GetInt ("MaxEnergy");
		energyRegenSpeed += PlayerPrefs.GetInt ("EnergyRegen");
		energyText.text = "Energy: " + Energy;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLimit > 0) 
		{
			timeLimit -= Time.deltaTime;
		}
		else if (Energy < 70)
		{
			Energy += energyRegenSpeed;
			timeLimit = 1.0f;
			energyText.text = "Energy: " + Energy;
		}
		escapeText.text = "Escaped: " + escaped;
	}
	
	public void EntitySpawn(GameObject playerType){
		if (Energy > 14) {
			GameObject entity = (GameObject)Instantiate (playerType, StartNode.transform.position, Quaternion.identity);
			entity.GetComponent<EntityController> ().ActivateTarget ();
			Energy -= 15;
			energyText.text = "Energy: " + Energy;
		}
	}

	public void LevelWin(){
		if (escaped >= levelWinScore) {
			finishLevel();
		}
	}

	public void energyIncrease() {
		if(PlayerPrefs.HasKey("MaxEnergy") && PlayerPrefs.HasKey("EnergyRegen")) {
			int currentMaxEnergy = PlayerPrefs.GetInt("MaxEnergy");
			PlayerPrefs.SetInt("MaxEnergy", currentMaxEnergy + 5);
			int currentEnergyRegen = PlayerPrefs.GetInt("EnergyRegen");
			PlayerPrefs.SetInt("EnergyRegen", currentEnergyRegen + 1);
		}
	}
	public void finishLevel() {
		energyIncrease ();
		Application.LoadLevel(Application.loadedLevel+1);
	}


}