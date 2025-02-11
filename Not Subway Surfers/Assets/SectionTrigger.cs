using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("ProceduralTrigger")){
            Instantiate(roadSection, new Vector3(0, 0, 9), Quaternion.identity);
        }
    }
}
