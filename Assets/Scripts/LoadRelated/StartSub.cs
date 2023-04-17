using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSub : MonoBehaviour
{
    // Start is called before the first frame update
    public void btnS1()
    {
        SceneManager.LoadScene(1);
    }
    public void btnS2()
    {
        SceneManager.LoadScene(2);
    }
    public void btnS3()
    {
        SceneManager.LoadScene(3);
    }
}
