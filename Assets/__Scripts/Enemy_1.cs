using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    public float waveFrequency = 2;
    public float waveWidth = 4;
    public float waveRotY = 45;

    private float x0;
    private float birthTime;

    void Start()
    {
        Debug.Log("Enemy 1 spawned");
        x0 = pos.x;
        birthTime = Time.time;
    }

    public override void Move()
    {
        // Change position
        Vector3 tempPos = pos;
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;

        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);

        base.Move();

        // Change opacity
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        float freq = 2F;
        foreach (var renderer in renderers)
        {
            Color c = renderer.material.color;
            renderer.material.color = new Color(
                c.r,
                c.g,
                c.g,
                Mathf.Clamp(Mathf.Sin(freq * age), 0, 1)
            );
        }
    }
}
