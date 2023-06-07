using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class AuthManager : MonoBehaviour
{
    public static AuthManager instance;
    //public static Root root;
    public static string Token
    {
        set
        {
            PlayerPrefs.SetString("Token", value);
            Debug.Log(Token);
        }
        get
        {
            return PlayerPrefs.GetString("Token");
        }
    }
    private void Awake()
    {
        if (instance != null)
        {
           //Destroy(gameObject);
        }
        else
        {
            instance = this;
           // DontDestroyOnLoad(this);
        }
    }


public static string BASE_URL = "http://44.236.254.142/";

    public void CreateUser(string name, string email, string password, string username, string gender, string birthday)
    {
        Debug.Log("Creating User");
        StartCoroutine(CreateUserStCoroutine(name,email,password, username, gender, birthday));
    }

    public void LoginUser(string username, string password)
    {
        Debug.Log("Login User");
        StartCoroutine(LoginUserCoroutine(username, password));
    }


    IEnumerator CreateUserStCoroutine(string name, string email, string password, string username, string gender, string birthday)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("username", username);
        form.AddField("email", email);
        form.AddField("password", password);
        form.AddField("gender", gender);
        form.AddField("birthday", birthday);

        string requestName = "api/v1/auth/sign_up";
        using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL + requestName, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleManager.instance.ShowMessage("Network Error!");
                InputUIManager.instance.LoadingPanel.SetActive(false);
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                OnSuccess(www.downloadHandler.text);
                SceneManager.LoadScene("Login");
            }
        }
    }
    IEnumerator LoginUserCoroutine(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        string requestName = "api/v1/auth/sign_in";

        using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL + requestName, form))
        {
            
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleManager.instance.ShowMessage("Network Error!");
                InputUIManager.instance.LoadingPanel.SetActive(false);
                Debug.Log(www.error);
            }
            else
            {
                OnSuccess(www.downloadHandler.text);
                SceneManager.LoadScene("VideoAR");
                //Debug.Log("token" + root.meta.token);
            }
        }
    }

    private void OnSuccess(string json)
    {
        //Debug.Log("Json "+json);
        //root = JsonUtility.FromJson<Root>(json);
        //Debug.Log("Login Success Function");
        //Debug.Log(root.meta.token);
        //Token = root.meta.token;
        
        //ProfileManager.FullName = root.user.name;
        //ProfileManager.UserName = root.user.username;
        //ProfileManager.UserID = root.user.id;
        //ProfileManager.UserEmail = root.user.email;
        //ProfileManager.UserImageUrl = root.user.image_url;
        ////DateTime Birthday = DateTimeOffset.Parse(root.user.birthday.ToString()).DateTime;
        ////ProfileManager.UserAge = GetAge(Birthday).ToString();
        //Debug.Log("ProfileManager.UserAge " + ProfileManager.UserAge);
        //Debug.Log("UserEmail " + ProfileManager.UserEmail);
    }
    public static int GetAge(DateTime birthDate)
    {
        DateTime n = DateTime.Now; // To avoid a race condition around midnight
        int age = n.Year - birthDate.Year;

        if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
            age--;

        return age;
    }
}