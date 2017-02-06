using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class FiringController : MonoBehaviour {

    private const float _fireRate = 1f;
    private float _nextFire = 0f, _bulletSpeed = 10;
    //private IList<GameObject> _bulletsCollection;

    public GameObject bullet;
    public Transform bulletSpawnPoint;

    // Use this for initialization
    void Start () {
        //_bulletsCollection = new List<GameObject>();

        var bulletSpawnPointObject = GameObject.FindWithTag("BulletSpawnPoint");
        bulletSpawnPoint = bulletSpawnPointObject.transform;
        bullet = Resources.Load("testprefab") as GameObject;
	}

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            var bulletShot = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            var bulletRigidBody = bulletShot.GetComponent<Rigidbody2D>();
            var currentBulletSpeed = GameDataStore.Instance.CurrentPlayerSpeed + _bulletSpeed;
            bulletRigidBody.AddForce(GameDataStore.Instance.CurrentPlayerDirection * currentBulletSpeed);
        }
    }

    private void FixedUpdate()
    {

    }
}
