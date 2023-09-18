using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Cannon Motion")]
    [SerializeField] private Transform _cannonTransform = null;
    [SerializeField] private Transform _cannonballSpawnPoint = null;
    [SerializeField] private float _rotationRate = 45.0f;
    [Header("Cannon Firing")]
    [SerializeField] private GameObject _cannonballPrefab = null;
    [SerializeField] private float _cannonballFireVelocity = 50.0f;
    [SerializeField] private float _rateOfFire = 0.33f;

    private float _timeOfLastFire = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        //FindObjectOfType<GameSession>().OnSessionEnd += () => { enabled = false; };
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            FireCannon();
        }

        if( Input.GetKey( KeyCode.LeftArrow ) )
        {
            _cannonTransform.Rotate( 0.0f, -(Time.deltaTime * _rotationRate), 0.0f, Space.World );
        }

        if( Input.GetKey( KeyCode.RightArrow ) )
        {
            _cannonTransform.Rotate( 0.0f, Time.deltaTime * _rotationRate, 0.0f, Space.World );
        }
    }

    public void FireCannon()
    {
        if( Time.timeSinceLevelLoad > _timeOfLastFire + _rateOfFire )
        {
            var spawnedBall = GameObject.Instantiate( _cannonballPrefab, _cannonballSpawnPoint.transform.position, _cannonTransform.rotation);

            spawnedBall.GetComponent<Rigidbody>().AddForce( _cannonTransform.forward * _cannonballFireVelocity, ForceMode.Impulse );
            _timeOfLastFire = Time.timeSinceLevelLoad;
        }
    }
}
