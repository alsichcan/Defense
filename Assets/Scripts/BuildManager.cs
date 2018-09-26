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
    private FloorTiles selectedTile;

    public TileUI tileUI;

    // Unit을 생성할 수 있는지
    public bool CanCreate { get { return unitToCreate != null; } }

    public bool HasGold { get { return PlayerStats.Gold >= unitToCreate.cost; } }

    public void SelectTile (FloorTiles tile)
    {
        if (selectedTile == tile)
        {
            DeselectTile();
            return;
        }
        selectedTile = tile;
        unitToCreate = null;

        tileUI.SetTarget(tile);
    }

    public void DeselectTile()
    {
        selectedTile = null;
        tileUI.Hide();
    }


    public void SelectUnitToCreate(UnitBluePrint unit)
    {
        unitToCreate = unit;
        DeselectTile();

    }

    public UnitBluePrint GetUnitToCreate()
    {
        return unitToCreate;
    }
}
