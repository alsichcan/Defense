using UnityEngine;
using UnityEngine.EventSystems;

public class FloorTiles : MonoBehaviour {

    [Header("Attributes")]
    private Renderer rend;
    private Color startColor;
    public Color hoverColor;
    public Vector3 positionOffset;

    [HideInInspector]
    BuildManager buildManager;

    public GameObject[] units;   // TODO : 자료구조?
    public static bool CanSelectTile;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
        units = new GameObject[12];
  
        CanSelectTile = true; // TODO : 어떻게 implement?
    }

    public Vector3 GetCreatePosition() { return transform.position + positionOffset; }

    public Quaternion GetCreateRotation() { return Quaternion.identity; }

    public void AddUnit(GameObject unit)
    {
        units[0] = unit;
    }

    // 마우스로 해당 Tile을 선택할 때
    private void OnMouseDown()
    {
        // 마우스가 UI를 누를 때 타일이 highlight가 되지 않도록 함
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!CanSelectTile)
            return;

        buildManager.SelectTile(this);
    }

    // 마우스 커서가 Object의 Collider 범위에 들어올 때
    // 해당 Object의 color를 hoverColor로 변경
    private void OnMouseEnter()
    {
        // 마우스가 UI 위에 있을 때 타일이 highlight가 되지 않도록 함
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // 생성할 유닛이 있을 때만 타일이 highlight 되도록 함
        if (!CanSelectTile)
            return;

        rend.material.color = hoverColor;       
    }

    // 마우스 커서가 Object의 Collider 범위에서 나갔을 때
    // 해당 Object의 color를 startColor로 변경
    private void OnMouseExit()
    {
        rend.material.color = startColor; 
    }
}
