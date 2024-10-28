using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBDiskEnabler : MonoBehaviour
{
    private MeshRenderer diskRenderer;
    private float projectileVisualDelay = 0.1f;

    private void Awake()
    {
        diskRenderer = GetComponent<MeshRenderer>();
        diskRenderer.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ProjectileEnabler");
    }

    IEnumerator ProjectileEnabler()
    {
        Debug.Log("DiskEnablerWorking(?)");
        yield return new WaitForSeconds(projectileVisualDelay);
        diskRenderer.enabled = true;
    }
}
