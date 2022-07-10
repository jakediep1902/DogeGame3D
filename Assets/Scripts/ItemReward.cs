using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemReward : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration;
    public float distance;
    private Vector3 pointPatrol;
    public Transform point_A;
    public Transform point_B;
    public Transform parent;
    private void OnEnable()
    {
        transform.SetParent(parent);
        SetPos();
    }
    void Start()
    {
        Debug.Log("Instatiate");
        pointPatrol = transform.position;
        pointPatrol.y += distance;
        transform.DOMove(pointPatrol, duration).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
        //transform.DOMove(new Vector3(0, 2, 0), duration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<ItemReward>().enabled = true;
        }
    }
    public void SetPos()
    {
        float randomX = Random.Range(point_A.localPosition.x, point_B.localPosition.x);
        float x = Mathf.Clamp(randomX, point_A.localPosition.x, point_B.localPosition.x);
        float randomZ = Random.Range(point_A.localPosition.x, point_B.localPosition.x);
        float z = Mathf.Clamp(randomZ, point_A.localPosition.z, point_B.localPosition.z);
        Vector3 rewardPos = new Vector3(x, 1.08f, z);
        transform.localPosition = rewardPos;
    }
}
