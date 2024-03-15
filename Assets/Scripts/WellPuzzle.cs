using UnityEngine;

public class WellPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject Reward;

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
        Debug.Log(other.gameObject.tag);
            Instantiate(Reward, new Vector3(transform.position.x + 0.6f, transform.position.y + 1.2f, transform.position.z), Quaternion.Euler(new Vector3(-90f, -270f, 0f)));
            Destroy(other.gameObject);
        }
    }
}
