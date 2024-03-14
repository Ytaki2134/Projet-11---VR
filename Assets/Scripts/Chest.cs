using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject Reward;
    [SerializeField] private Transform Pivot;
    private bool _isOpen;

    [SerializeField] private Vector3 _targetRotation;
    [SerializeField] private float _rotationSpeed;
    private float _totalRotation;

    private void Start()
    {
        _isOpen = false;

        //To Move
        Instantiate(Reward, new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z + 0.4f), Quaternion.identity);

        StartCoroutine(OpenLid());
    }

    private IEnumerator OpenLid()
    {
        if (_isOpen)
            yield break;

        _isOpen = true;
        while (_totalRotation < _targetRotation.x)
        {
            float currentAngle = Pivot.rotation.eulerAngles.x;
            Pivot.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * _rotationSpeed), Vector3.right);
            _totalRotation += Time.deltaTime * _rotationSpeed;
            yield return null;
        }
        Pivot.rotation = Quaternion.Euler(_targetRotation);
        yield break;
    }
}
