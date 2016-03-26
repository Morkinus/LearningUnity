using UnityEngine;
using System.Collections;
using System;

public class NetworkService {

	private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?id=2172797";

	private const string webImage = "http://upload.wikimedia.org/wikipedia/commons/c/c5/Moraine_Lake_17092005.jpg";

	private bool IsResponseValid(WWW www)
	{
		if (www.error != null) {
			Debug.Log ("Bad connection");
			//Debug.Log (www.error);	
			return false;	
		} else if (string.IsNullOrEmpty (www.text)) {
			Debug.Log ("Bad data");
			return false;
		} else {
			return true;
		}
	}

	private IEnumerator CallAPI(string url,Action<string> callback)
	{
		WWW www = new WWW (url);
		yield return www;

		if (!IsResponseValid (www)) {
			yield break;
		}

		callback (www.text);
	}

	public IEnumerator GetWeatherXML(Action<string> callback)
	{
		return CallAPI (xmlApi, callback);
	}

	public IEnumerator DownloadImage(Action<Texture2D> callback)
	{
		WWW www = new WWW (webImage);
		yield return www;
		callback (www.texture);
	}
}
