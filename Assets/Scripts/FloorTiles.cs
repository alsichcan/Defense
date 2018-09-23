using UnityEngine;

public class FloorTiles : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;
    

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    // 마우스로 해당 Object를 누를 때
    private void OnMouseDown()
    {
        // 포탑이 설치되어 있지 않은 경우
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO : Display on Screen.");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    // 마우스 커서가 Object의 Collider 범위에 들어올 때
    // 해당 Object의 color를 hoverColor로 변경
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor; 

    }

    // 마우스 커서가 Object의 Collider 범위에서 나갔을 때
    // 해당 Object의 color를 startColor로 변경
    private void OnMouseExit()
    {
        rend.material.color = startColor; 
    }
}
