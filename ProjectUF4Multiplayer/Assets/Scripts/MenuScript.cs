using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static void StartAsAHost()
    {
        ConnectionManagment.getInstance().host = true;
        SceneManager.LoadScene("SampleScene");
    }
    public static void StartAsAClient()
    {
        ConnectionManagment.getInstance().host = false;
        SceneManager.LoadScene("SampleScene");
    }
}
