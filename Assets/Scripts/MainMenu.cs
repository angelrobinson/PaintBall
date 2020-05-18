using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour 
{
	//UI objects
	[SerializeField] private Toggle fullscreenToggle;
	[SerializeField] private Dropdown resolutionDropdown;
	[SerializeField] private Slider musicSlider, sfxSlider;
	[SerializeField] private Button applyBtn, playBtn, exitBtn;

	//array for resolution selections
	private Resolution[] resolutions;

	private OptionsSettings options;
	[SerializeField] private AudioSource source; //clip recorded with Audacity software

	// Use this for initialization
	void OnEnable()
	{
		
		options = new OptionsSettings ();
		fullscreenToggle.onValueChanged.AddListener (delegate{OnFullScreenToggle ();});
		resolutionDropdown.onValueChanged.AddListener (delegate{OnResolutionChange ();});
		musicSlider.onValueChanged.AddListener (delegate{OnMusicVolume ();});
		sfxSlider.onValueChanged.AddListener (delegate{	OnSFXVolume ();	});
		applyBtn.onClick.AddListener (delegate{	SaveOptions ();	});
		exitBtn.onClick.AddListener (delegate{QuitGame ();});
		playBtn.onClick.AddListener (delegate {	GameManager.Instance.ChangeToPOV ();});

		resolutions = Screen.resolutions;

		foreach (Resolution res in resolutions)
		{
			resolutionDropdown.options.Add (new Dropdown.OptionData (res.ToString ()));
		}

		LoadOptions ();
	}


	public void OnFullScreenToggle()
	{
		options.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
	}

	public void OnMusicVolume()
	{
		source.volume = options.musicVolume = musicSlider.value;
	}

	public void OnResolutionChange()
	{
		Screen.SetResolution(resolutions[resolutionDropdown.value].width,resolutions[resolutionDropdown.value].height,Screen.fullScreen);
		options.resolutionIndex = resolutionDropdown.value;
	}

	public void OnSFXVolume()
	{
		source.reverbZoneMix = options.sfxVolume = sfxSlider.value;
	}

	public void SaveOptions()
	{
		string jsonData = JsonUtility.ToJson (options,true);
		File.WriteAllText (Application.persistentDataPath + "/gameSetting.json",jsonData);
	}

	public void LoadOptions()
	{
		options = JsonUtility.FromJson<OptionsSettings> (File.ReadAllText (Application.persistentDataPath + "/gameSetting.json"));
		musicSlider.value = options.musicVolume;
		resolutionDropdown.value = options.resolutionIndex;
		fullscreenToggle.isOn = options.fullscreen;
		sfxSlider.value = options.sfxVolume;

		resolutionDropdown.RefreshShownValue ();
	}

	public void QuitGame()
	{
		Application.Quit ();
	}


}
