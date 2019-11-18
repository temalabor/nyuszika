using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutPage : MonoBehaviour
{
    public void BackButton(){
        SceneManager.LoadScene("Scenes/Menu");
    }
}
