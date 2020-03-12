using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update

    public Coroutine waveForward;
    public Coroutine waveReverse;

    public Transform Waypoint1;
    public Transform StartPosition;
    public float platformSpeed;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && waveForward == null)
        {
            waveForward = StartCoroutine(PLatformWaveMotion());
        }
    }

    /*public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(wave);
        }
    }*/

    public IEnumerator PLatformWaveMotion()
    {
        while(gameObject.transform.position.x < Waypoint1.transform.position.x)
        {
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x + platformSpeed, Mathf.Sin(this.gameObject.transform.localPosition.x), 0);
            yield return new WaitForEndOfFrame();
        }
        waveReverse = StartCoroutine(PLatformWaveMotionReverse());
    }

    public IEnumerator PLatformWaveMotionReverse()
    {
        if (waveForward != null)
        {
            Debug.Log("Called");
            StopCoroutine(waveForward);
            waveForward = null;
            Debug.Log(waveForward == null);

        }
        while (gameObject.transform.position.x > StartPosition.transform.position.x)
        {
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x - platformSpeed*2, Mathf.Sin(this.gameObject.transform.localPosition.x), 0);
            yield return new WaitForEndOfFrame();
        }
        StopCoroutine(waveReverse);
    }
}
