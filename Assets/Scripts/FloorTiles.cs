using UnityEngine;
using UnityEngine.EventSystems;

public class FloorTiles : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughGoldColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject unit;
    [HideInInspector]
    public UnitBluePrint unitBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetCreatePosition()
    {
        return transform.position + positionOffset;
    }

    // 마우스로 해당 Object를 누를 때
    private void OnMouseDown()
    {

        // 마우스가 UI를 누를 때 타일이 highlight가 되지 않도록 함
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // 포탑이 설치되어 있는 경우
        if (unit != null)
        {
            buildManager.SelectTile(this);
            return;
        }

        if (!buildManager.CanCreate)
            return;


        CreateUnit(buildManager.GetUnitToCreate());

    }

    void CreateUnit(UnitBluePrint blueprint)
    {
        if (PlayerStats.Gold < blueprint.cost)
        {
            Debug.Log("Not enough Gold");
            return;
        }

        PlayerStats.Gold -= blueprint.cost;

        GameObject _unit = (GameObject)Instantiate(blueprint.prefab, GetCreatePosition(), Quaternion.identity);
        this.unit = _unit;

        unitBlueprint = blueprint;

        Debug.Log("Unit Created!");
    }

    public void UpgradeUnit()
    {
        if (PlayerStats.Gold < unitBlueprint.upgradeCost)
        {
            Debug.Log("Not enough Gold to upgrade that");
            return;
        }

        PlayerStats.Gold -= unitBlueprint.upgradeCost;

        // Get rid of the old turret
        Destroy(unit);

        // Build a new one
        GameObject _unit = (GameObject)Instantiate(unitBlueprint.upgradedPrefab, GetCreatePosition(), Quaternion.identity);
        this.unit = _unit;

        isUpgraded = true;

        Debug.Log("Unit Upgraded!");
    }


    public void SellUnit()
    {
        PlayerStats.Gold += unitBlueprint.GetSellAmount();

        Destroy(unit);
        unitBlueprint = null;
    }



    // 마우스 커서가 Object의 Collider 범위에 들어올 때
    // 해당 Object의 color를 hoverColor로 변경
    private void OnMouseEnter()
    {

        // 마우스가 UI 위에 있을 때 타일이 highlight가 되지 않도록 함
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // 생성할 유닛이 있을 때만 타일이 highlight 되도록 함
        if (!buildManager.CanCreate)
            return;

        if (buildManager.HasGold)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughGoldColor; 
        }
       
    }

    // 마우스 커서가 Object의 Collider 범위에서 나갔을 때
    // 해당 Object의 color를 startColor로 변경
    private void OnMouseExit()
    {
        rend.material.color = startColor; 
    }
}
