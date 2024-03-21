using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform platform;
    public Transform unlitLantern;
    public Transform litLantern;
    float timer = 0f;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        while (timer < 1f)
        {
            platform.localScale = Vector3.Lerp(platform.localScale, Vector3.one, timer * speed);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0f;
        while (timer < 1f)
        {
            unlitLantern.localScale = Vector3.Lerp(unlitLantern.localScale, Vector3.one, timer * speed);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0f;
        while (timer < 1f)
        {
            litLantern.localScale = Vector3.Lerp(litLantern.localScale, Vector3.one, timer * speed);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
