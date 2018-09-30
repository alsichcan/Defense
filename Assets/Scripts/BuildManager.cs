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

    public GameObject standardUnitPrefab;  // TODO : 자료구조? 

    private UnitBlueprint unitToCreate;
    private FloorTiles selectedTile;
    private FloorTiles rallyPointTile;

    public void SelectTile (FloorTiles tile)
    {
        if (selectedTile == tile)
        {
            DeselectTile();
            return;
        }
        selectedTile = tile;
        unitToCreate = null;      
    }

    public void DeselectTile()
    {
        selectedTile = null;
    }

    public void CreateUnit()
    {
   //     GameObject createdUnit = (GameObject)Instantiate(unitToCreate.prefab, selectedTile.GetCreatePosition(), selectedTile.GetCreateRotation());
   //     selectedTile.AddUnit(createdUnit);
    }

    public void SelectUnitToCreate(UnitBlueprint unit)
    {
        unitToCreate = unit;
    }
}
