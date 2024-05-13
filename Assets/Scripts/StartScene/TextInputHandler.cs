using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextInputHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameTextField;
    [SerializeField] private Button joinBtn;
    [SerializeField] private int minNameLength;

    public string NameText => nameTextField.text;
    public void TextChanged()
    {
         int textLength = nameTextField.text.Length;

        // 영어, 숫자만 가능
        nameTextField.text = Regex.Replace(nameTextField.text, @"[^a-zA-Z0-9가-힝]", "");
        
        joinBtn.interactable = textLength >= minNameLength;
    }

    // StartScene JoinBtn OnClick
    public void SetPlayerNameInLogin()
    {
        PlayerPrefs.SetString("PlayerName",nameTextField.text);
        SceneManager.LoadScene("MainScene");
    }
  
}