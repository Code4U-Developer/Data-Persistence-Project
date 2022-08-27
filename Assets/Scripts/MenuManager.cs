using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{
    public TMP_Text BestScoreText;
    public TMP_InputField NameInput;

    // Start is called before the first frame update
    void Start()
    {
    if(PersistentDataManager.Instance.BestName != ""){
    BestScoreText.text = "Best Score : " + PersistentDataManager.Instance.BestName +" "+PersistentDataManager.Instance.BestScore;
    }
    }


    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void InputFieldNameChange(){
        PersistentDataManager.Instance.Name = NameInput.text;
    }

    public void Exit(){
        PersistentDataManager.Instance.SaveBestName();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit(); // original code to quit Unity player
        #endif
    }
}
