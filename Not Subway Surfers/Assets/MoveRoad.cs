using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -3) * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("DestroyBehind")){
            Destroy(gameObject);
        }
    }
}
