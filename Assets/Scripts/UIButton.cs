using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    //���۹�ư
    public void StartButton()
    {
        Debug.Log("dsf");
        SceneLoadManager.Instance.StartButton();
    }
}
