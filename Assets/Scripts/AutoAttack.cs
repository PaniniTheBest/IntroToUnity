using UnityEngine;
public class AutoAttack : Attack
{
    [SerializeField]
    private float shootInterval;

    [SerializeField]
    private float shootDelay;

    private void Start()
    {
        InvokeRepeating("ShootBullet",
            shootDelay, shootInterval);
    }

    private void Update()
    {
        // Leaving this empty so
        // input is not detected
        // from base class
    }
}
