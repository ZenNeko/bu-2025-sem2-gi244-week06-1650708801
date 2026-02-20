using UnityEngine;

public class CameraControlExam06 : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float offset;
    public Camera targetCamera;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 player1Pos = player1.transform.position;
        Vector3 player2Pos = player2.transform.position;
        
        // Student code ...
        Vector3 midPos =(player1Pos + player2Pos)/2;
        targetCamera.transform.position = new Vector3(midPos.x + offset, targetCamera.transform.position.y, midPos.z + offset);
     
       
       targetCamera.orthographicSize = Mathf.Max(Vector3.Distance(player1Pos, player2Pos), offset);
    }
    
}
