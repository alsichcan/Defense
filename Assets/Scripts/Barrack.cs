using UnityEngine;
using UnityEngine.UI;

public class Barrack : MonoBehaviour {

    BuildManager buildManager;
    public UnitBlueprint unitBlueprint;

    public GameObject BarrackProgressSlot;
    public GameObject BarrackProgressBar;


    public GameObject BarrackCommands;
    



	// Use this for initialization
	void Start () {
        buildManager = BuildManager.instance;

        BarrackProgressSlot.SetActive(false);
        BarrackProgressBar.SetActive(false);

	}
	
	public void GetUnitAll()
    {
        Debug.Log("GetUnitAll");
    }

    public void GetGold()
    {
        Debug.Log("GetGold");
    }

    public void GetLumber()
    {
        Debug.Log("GetLumber");
    }

    public void GetUnitOnly()
    {
        Debug.Log("GetUnitOnly");
    }

    public void GetSpecial()
    {
        Debug.Log("GetSpecial");
    }

    public void SetRallyPoint()
    {
        FloorTiles.CanSelectTile = true;
    }

    public void GetUnitLow()
    {
        Debug.Log("GetUnitLow");
    }

    public void GetUnitMiddle()
    {
        Debug.Log("GetUnitMiddle");
    }

    public void GetUnitHigh()
    {
        Debug.Log("GetUnitHigh");
    }
}
