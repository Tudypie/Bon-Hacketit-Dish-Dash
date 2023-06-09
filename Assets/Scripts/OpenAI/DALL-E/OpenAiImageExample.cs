﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using REST_API_HANDLER;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Networking;
using TMPro;
using System;
using System.IO;

public class OpenAiImageExample : MonoBehaviour
{
	public GameObject loadingpanel;
	public TMP_Text inputText;
	public TMP_Text resultText;
	public GameObject previewObjs;
	public UnityEvent onGeneratedImage;

	private string IMAGE_GENERTION_API_URL = "https://api.openai.com/v1/images/generations";

	public void SearchButtonClicked()
    {
		resultText.text = "";
		resultText.enabled = false;
		loadingpanel.SetActive(true);

		//previewObjs.GetComponent<Renderer>().material.mainTexture = null;

		string description = inputText.text;
		string resolution = "256x256"; // Possible Resolution 256x256, 512x512, or 1024x1024.

		GenerateImage(description, resolution, () => {
			loadingpanel.SetActive(false);
		});
		
	}

	public void GenerateImage(string description, string resolution, Action completationAction)
	{

		GenerateImageRequestModel reqModel = new GenerateImageRequestModel(description, 1 ,resolution);
		ApiCall.instance.PostRequest<GenerateImageResponseModel>(IMAGE_GENERTION_API_URL, reqModel.ToCustomHeader(), null, reqModel.ToBody(), (result =>
		{
			loadTexture(result.data, completationAction);
			resultText.enabled = true;
		}), (error =>
		{
			ErrorResponseModel entity = JsonUtility.FromJson<ErrorResponseModel>(error);
			completationAction.Invoke();
			resultText.enabled = true;
			resultText.text = entity.error.message;
		}));

	}




	async void loadTexture(List<UrlClass> urls, Action completationAction)
    {
		Texture2D _texture = await GetRemoteTexture(urls[0].url);
		Sprite generatedImage =  Sprite.Create(_texture, new Rect(0, 0, _texture.width, _texture.height), new Vector2(0.5f, 0.5f), 100f);
		previewObjs.GetComponent<Image>().sprite = generatedImage;
		Utility.WriteImageOnDisk(_texture, System.DateTime.Now.Millisecond + "_createImg_" + "_.jpg");

		completationAction.Invoke();
		onGeneratedImage?.Invoke();
	}

	public static async Task<Texture2D> GetRemoteTexture(string url)
	{
		using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
		{
			var asyncOp = www.SendWebRequest();

			while (asyncOp.isDone == false)
				await Task.Delay(1000 / 30);//30 hertz

			// read results:
			if (www.isNetworkError || www.isHttpError)
			{
				return null;
			}
			else
			{
				return DownloadHandlerTexture.GetContent(www);
			}
		}
	}

	private void WriteImageOnDisk(Texture2D texture, string fileName)
	{
		byte[] textureBytes = texture.EncodeToPNG();
		string path = Application.persistentDataPath + fileName;
		File.WriteAllBytes(path, textureBytes);
		Debug.Log("File Written On Disk! "  + path );
	}
}
