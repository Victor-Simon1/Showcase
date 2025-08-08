using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Logger = MyUnityPackage.Toolkit.Logger;
public class SettingsManager : MonoBehaviour
{

    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] TMP_Dropdown fpsDropdown;
    Resolution[] resolutionsArray;

    int[] fpsArray = {30,60,120};
    void Start()
    {
        resolutionsArray = Screen.resolutions;

        //Add resolution in dropdown
        List<string> resStrings= new List<string>();
        foreach(Resolution res in resolutionsArray)
        {
            resStrings.Add(res.ToString());
        }   
        resolutionDropdown.AddOptions(resStrings);

        //Set default fps
        List<string> fpsStrings= new List<string>();
        foreach(int fps in fpsArray)
        {
            fpsStrings.Add(fps.ToString());
        }   
        fpsDropdown.AddOptions(fpsStrings);
    }
    public void ChangeQuality(int qualityIndex)
    {
        Logger.LogMessage("" + qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex,true);
    }

    public void ChangeResolution(int resolutionIndex)
    {
        Logger.LogMessage("Change resolution ");
        Screen.SetResolution(resolutionsArray[resolutionIndex].width,
                            resolutionsArray[resolutionIndex].height,
                            Screen.fullScreen );
    }

    public void ChangeFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void ChangeFPS(int fpsIndex)
    {
        //TO DO set les fps dans le start + le dropdown
        
        Application.targetFrameRate = fpsArray[fpsIndex];
    }
}
