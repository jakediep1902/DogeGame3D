using UnityEngine;
using System.Collections;

public class SheepController : MonoBehaviour {
    //private Vector3 
    public Vector3 mousePos;
    public float moveSpeed;
    private float minX=-5.5f;
    private float maxX=5.5f;
    private float minY=-3;
    private float maxY=3;
    private GameObject gameController;
	// Use this for initialization
	void Start () {
        mousePos = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController");
	}

	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            //chuyen tu toa do the gioi ra toa do man hinh
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(Mathf.Clamp( mousePos.x,minX,maxX ),Mathf.Clamp( mousePos.y,minY,maxY ), 0);
           //giong voi dong tren
           // mousePos.Set(Mathf.Clamp(mousePos.x, minX, maxX),Mathf.Clamp(mousePos.y, minY, maxY), 0);
          
            
        }
       transform.position = Vector3.Lerp(transform.position, mousePos , moveSpeed*Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        gameController.GetComponent<GameController>().EndGame();
    }
}
