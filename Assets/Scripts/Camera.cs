using UnityEngine;

public class Camera : MonoBehaviour {

    public float panSpeed = 30f;
    public float panBorder = 10f;
    private bool doMove = true;
    public float scrollSpeed = 5f;
    private int CamX = 100;
    private int CamZ = 100;
    private float counter = 10;
    public float minY = 10f;
    public float maxY = 80f;





    // Update is called once per frame
    void Update () {

        counter = counter + 10;

        Debug.Log(CamX);

        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            doMove = !doMove;
        }

        if (!doMove)
        {
            return;
        }

        if (Input.GetKey("w") )//&& CamZ < 150)
        {
            
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            CamZ++;
            
        }
        else if (Input.GetKey("s") )//&& CamZ > 75)
        {

            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            CamZ--;
        }
        else if (Input.GetKey("a") )//&& CamX > 75)
        {

            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            CamX--;
        }
        else if (Input.GetKey("d") )//&& CamX < 150)
        {

            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            CamX++;
        }

       
        Vector3 pos = transform.position;

        pos.y -= Input.GetAxis("Mouse ScrollWheel") * 1000 * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z += Input.GetAxis("Mouse ScrollWheel") * 10;
       
        transform.position = pos;

      

    }
}
