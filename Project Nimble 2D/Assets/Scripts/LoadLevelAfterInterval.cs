using UnityEngine;
using System.Collections;

public class LoadLevelAfterInterval : MonoBehaviour {

    public float loadTime = 3;
    public int level = 3;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(loadTime);
        Application.LoadLevel(level);
    }
}
