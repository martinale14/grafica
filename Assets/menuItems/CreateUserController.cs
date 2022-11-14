using Assets.Personajes.Astronaut.scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateUserController : MonoBehaviour
{
    private new string name = "";
    private string email = "";
    private string password = "";
    public GameObject alert;

    public void OnClickRegister() {
        CreateUserRequestModel request = new()
        {   
            name = name,
            email = email,
            password = password
        };
        StartCoroutine(PostRequest("http://localhost:8000/api/user", JsonUtility.ToJson(request)));
    }

    IEnumerator PostRequest(string url, string json)
    {
        UnityWebRequest uwr = new(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = new DownloadHandlerBuffer();
        uwr.SetRequestHeader("content-type", "application/json");

        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            print("Error While Sending: " + uwr.error);
        }
        else
        {
            if (uwr.responseCode == 200)
            {
                UserResponseModel response = JsonUtility.FromJson<UserResponseModel>(uwr.downloadHandler.text);
                print("Received: " + response.token);
                PlayerPrefs.SetString("token", response.token);
                AstronautEntity.user = response.user;
                if(AstronautEntity.user.type == "estudiante")
                {
                    SceneManager.LoadScene(2);
                }else
                {
                    SceneManager.LoadScene(3);
                }
            }

            if (uwr.responseCode == 401)
            {
                ErrorResponse response = JsonUtility.FromJson<ErrorResponse>(uwr.downloadHandler.text);
                alert.SetActive(true);
                GameObject.Find("ErrorText").GetComponent<Text>().text = response.mssg;
                print("Error: " + uwr.downloadHandler.text);
            }
        }
        uwr.Dispose();
    }

    public void OnChangeEmail(string email){
        this.email = email;
    }

    public void OnChangePassword(string password){
        this.password = password;
    }

    public void OnChangeName(string name)
    {
        this.name = name;
    }

    public void GoLogin()
    {
        SceneManager.LoadScene(0);
    }
}
