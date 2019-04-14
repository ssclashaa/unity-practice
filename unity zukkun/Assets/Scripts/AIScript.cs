using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour {

    private float changeTargetSqrDistance = 5f;

    private Vector3 targetPosition;
    private float speed = 60f;
    private float rotationSmooth = 90f;

    private void Start()
    {
        targetPosition = GetRandomPositionOnLevel();
    }

    private void Update()
    {
        // 目標地点との距離が小さければ、次のランダムな目標地点を設定する
        float sqrDistanceToTarget = Vector3.SqrMagnitude(targetPosition - transform.position);
        if (sqrDistanceToTarget < changeTargetSqrDistance)
        {
            targetPosition = GetRandomPositionOnLevel();
        }

        // 目標地点の方向を向く
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

        // 前方に進む
        transform.position += transform.forward * speed * Time.deltaTime;

        
    }

    public Vector3 GetRandomPositionOnLevel()
    {
        return new Vector3(Random.Range(-100, 580), 32, Random.Range(-100, 570));
    }
}
