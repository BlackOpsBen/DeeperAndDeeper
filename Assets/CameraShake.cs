using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] Transform baseParent;
    [SerializeField] float amplitude;
    [SerializeField] float limitSmoothing;
    [SerializeField] float cooldownSpeed = 1f;
    [SerializeField] float amount = 0;
    [SerializeField] float amountLimit;
    [SerializeField] float minShakeAmount = 0.1f;

    private void Update()
    {
        amount = Mathf.Clamp(amount, minShakeAmount, amountLimit);

        if (amount > 0f)
        {
            amount -= Time.deltaTime * cooldownSpeed;
        }

        int randX = UnityEngine.Random.Range(-1, 1);
        int randY = UnityEngine.Random.Range(-1, 1);
        int randZ = UnityEngine.Random.Range(-1, 1);
        Vector3 amplifiedRand = new Vector3(randX * amplitude, randY * amplitude, randZ * amplitude);

        Vector3 offsetRandPos = new Vector3(baseParent.position.x + amplifiedRand.x, baseParent.position.y + amplifiedRand.y, baseParent.position.z + amplifiedRand.z);

        //transform.position = offsetRandPos; ;
        transform.position = Vector3.Lerp(transform.position, offsetRandPos, amount);
    }

    public void AddShake(float amount)
    {
        this.amount += amount;
    }
}
