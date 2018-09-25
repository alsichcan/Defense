using UnityEngine;

public class BuildManager : MonoBehaviour{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        { 
            Debug.LogError("More than one BuildManager in Scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardUnitPrefab;

    private UnitBluePrint unitToCreate;

    // Unit을 생성할 수 있는지
    public bool CanCreate { get { return unitToCreate != null; } }

    public bool HasGold { get { return PlayerStats.Gold >= unitToCreate.cost; } }


    public void CreateUnitOn(FloorTiles tile)
    {
        if (PlayerStats.Gold < unitToCreate.cost)
        {
            Debug.Log("Not enough Gold");
            return;
        }

        PlayerStats.Gold -= unitToCreate.cost;

        GameObject unit = (GameObject) Instantiate(unitToCreate.prefab, tile.GetCreatePosition(), Quaternion.identity);
        tile.unit = unit;

        Debug.Log("Unit Created! Gold left: " + PlayerStats.Gold);
    }


    public void SelectUnitToCreate(UnitBluePrint unit)
    {
        unitToCreate = unit;
    }
}
