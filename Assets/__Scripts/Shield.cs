using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Inscribed")]
    public float rotationsPerSecond = 0.1f;

    [Header("Dynamic")]
    public int levelShown = 0;

    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel);
        if (levelShown != currLevel)
        {
            levelShown = currLevel;
            mat.mainTextureOffset = new Vector3(0.2f * levelShown, 0);
        }
        float rotZ = -(rotationsPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
