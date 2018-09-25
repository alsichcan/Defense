using UnityEngine;
using UnityEngine.EventSystems;

public class FloorTiles : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughGoldColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject unit;
    

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

        if (!buildManager.CanCreate)
            return;

        // 포탑이 설치되어 있지 않은 경우
        if (unit != null)
        {
            Debug.Log("Can't build there! - TODO : Display on Screen.");
            return;
        }

        buildManager.CreateUnitOn(this);

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
