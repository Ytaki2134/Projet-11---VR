using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class RockBehaviour : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _strength = 2f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if rocher en plein grab => return et ignore les collisions

        switch (collision.gameObject.layer)
        {
            //Enemy Layer
            //case X:
            //    break;

            //Rail Layer
            case 6:
                _rb.velocity = collision.transform.up * _strength;
                Debug.Log(transform.position + " " + collision.transform.up);
                break;

            //Terrain Layer
            case 3:
                Destroy(gameObject);
                break;
            default:
                break;
        }
        //else if collision enemy => degats + trigger anim
    }

    private void OnCollisionStay(Collision collision)
    {
        //if rocher en plein grab => return et ignore les collisions

        switch (collision.gameObject.layer)
        {
            //Enemy Layer
            //case X:
            //    break;

            //Rail Layer
            case 6:
                _rb.velocity = collision.transform.up * _strength;
                Debug.Log(transform.position + " " + collision.transform.up);
                break;

            //Terrain Layer
            case 3:
                Destroy(gameObject);
                break;
            default:
                break;
        }
        //else if collision enemy => degats + trigger anim
    }
}
