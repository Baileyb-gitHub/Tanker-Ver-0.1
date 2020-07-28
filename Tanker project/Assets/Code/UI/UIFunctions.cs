using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    public void loadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
    }

    public void disableObject(GameObject objectToDisable)
    {
        objectToDisable.SetActive(false);
    }

    public void enableObject(GameObject objectToEnable)
    {
        objectToEnable.SetActive(true);
    }


}
