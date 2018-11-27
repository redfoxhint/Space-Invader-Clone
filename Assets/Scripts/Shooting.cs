using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;

    [SerializeField] private GameObject projectilePrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            Destroy(bullet, 2.5f);
        }
    }
}
