using UnityEngine;

public class CameraController : MonoBehaviour {

    // 카메라 고정 여부
    private bool doMovement = true;

    [Header("Mouse Move Attributes")]
    // 카메라 이동 속도
    public float panSpeed = 30f;

    // 마우스로 이동할 때의 Buffer 공간
    public float panBorderThickness = 10f;

    // 마우스가 움직일 수 있는 최대 범위
    public float moveMinX = 0f;
    public float moveMaxX = 90f;
    public float moveMinZ = -10f;
    public float moveMaxZ = 80f;

    [Header("Mouse Scroll Attributes") ]
    // 마우스 스크롤할 때의 속도
    public float scrollSpeed = 5f;

    // 마우스가 스크롤할 수 있는 최소/최대 범위
    public float scrollMinY = 20f;
    public float scrollMaxY = 200f;


    // Update is called once per frame
    void Update () {

        // ESC 버튼을 누르면 고정/이동 상태 변경
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        // 고정 상태인경우 return
        if (!doMovement)
            return;



        // W 키를 입력하거나 마우스가 Screen의 상단에 있을 때 시야가 앞으로 이동
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        // A 키를 입력하거나 마우스가 Screen의 하단에 있을 때 시야가 뒤로 이동
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        
        // A 키를 입력하거나 마우스가 Screen의 좌단에 있을 때 시야가 좌측으로 이동
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        } 
        
        // D 키를 입력하거나 마우스가 Screen의 우단에 있을 때 시야가 우측으로 이동
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        // 움직일 수 있는 최대 범위 기준으로 움직임
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, moveMinX, moveMaxX),
            transform.position.y,
            Mathf.Clamp(transform.position.z, moveMinZ, moveMaxZ));



        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // 카메라의 현재 위치
        Vector3 pos = transform.position;

        // 마우스 스크롤에 따라 minY~maxY 사이에서 Zoom In/Out
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, scrollMinY, scrollMaxY);
        transform.position = pos;

    }
}
