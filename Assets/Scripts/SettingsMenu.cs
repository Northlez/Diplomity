using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public Dropdown resolutionDropdawn;
    public Dropdown qualityDropdawn;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdawn.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(var i=0;i< resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) 
            {
                currentResolutionIndex = i;
            }
        }

        qualityDropdawn.value = QualitySettings.GetQualityLevel();
        qualityDropdawn.RefreshShownValue();

        resolutionDropdawn.AddOptions(options);
        resolutionDropdawn.value = currentResolutionIndex;
        resolutionDropdawn.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
