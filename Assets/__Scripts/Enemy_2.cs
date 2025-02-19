using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy
{
    public float lifeTime = 10;
    public float sinEccentricity = 0.6f;
    public AnimationCurve rotCurve;
    [SerializeField] private float birthTime;
    [SerializeField] private Vector3 p0, p1;
    private Quaternion baseRotation;

    void Start()
    {
        p0 = Vector3.zero;
        p0.x = -bndCheck.camWidth - bndCheck.radius;
        p0.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);

        p1 = Vector3.zero;
        p1.x = bndCheck.camWidth + bndCheck.radius;
        p1.y = Random.Range(-bndCheck.camHeight, bndCheck.camHeight);

        if (Random.value > 0.5f)
        {
            p0.x *= -1;
            p1.x *= -1;
        }

        birthTime = Time.time;

        // Initial ship rotation
        transform.position = p0;
        transform.LookAt(p1, Vector3.back);
        baseRotation = transform.rotation;
    }

    public override void Move()
    {
        float u = (Time.time - birthTime) / lifeTime;
        if (u > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        float shipRot = rotCurve.Evaluate(u) * 360;
        transform.rotation = baseRotation * Quaternion.Euler(-shipRot, 0, 0);

        u += sinEccentricity * Mathf.Sin(u * 2 * Mathf.PI);

        pos = (1 - u) * p0 + u * p1;
    }
}
