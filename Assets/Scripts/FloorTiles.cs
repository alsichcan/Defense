using UnityEngine;

public class FloorTiles : MonoBehaviour {

    public Color hoverColor;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }


    // 마우스 커서가 Object의 Collider 범위에 들어올 때
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor; 

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor; 
    }
}
