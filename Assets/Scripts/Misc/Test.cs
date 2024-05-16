using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    public IEnumerator a;

    private void Start()
    {
        //Invoke(nameof(TestFunction), 5); 
        a = TestFunction();
        StartCoroutine(a);
        StopCoroutine(a);
        StopAllCoroutines();
    }

    public void StartTest()
    {
        StartCoroutine(TestFunction());
    }

    public IEnumerator TestFunction()
    {
        Debug.Log("Hi");
        yield return new WaitForSeconds(5);
        Debug.Log("Hello");
    }
}
