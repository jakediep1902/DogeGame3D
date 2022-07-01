using UnityEngine;
using System.Collections;

public class WoflController : MonoBehaviour {
    public GameObject boom;
    private float minBomTime = 2;
    private float maxBomTime = 4;
    private float bomTime = 0;
    private float lastBomTime = 0;
    private GameObject Sheep;
    private Animator anim;
    private float throwBomTime = 0.1f;
    private GameObject gameController;
   // private GameObject bom;

	// Use this for initialization
	void Start () {

        UpdateBomTime();
        Sheep = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isBom",false);
        gameController = GameObject.FindGameObjectWithTag("GameController");

	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= lastBomTime + bomTime - throwBomTime)
        {
            anim.SetBool("isBom",true);
            
        }
        if (Time.time >= lastBomTime+bomTime)
        {
            //anim.SetBool("isBom",false);
            ThrowBom();
          } 
	}
    void UpdateBomTime()
    {
        lastBomTime = Time.time;
        bomTime = Random.Range(minBomTime, maxBomTime + 1);

    }
    void ThrowBom()
    {

        //anim.SetBool("isBom", true);
         GameObject bom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject ;
        
        bom.GetComponent<BomController>().target = Sheep.transform.position ;
        UpdateBomTime();
        anim.SetBool("isBom", false );
        gameController.GetComponent<GameController>().GetPoint();
    }
}
