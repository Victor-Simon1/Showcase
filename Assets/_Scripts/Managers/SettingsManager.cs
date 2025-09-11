using System.Collections.Generic;
using MyUnityPackage.Toolkit;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;

namespace Showcase
{
    public class SettingsManager : MonoBehaviour
    {
        private enum ELang
        {
            FR = 0,
            EN
        }
        [SerializeField] TMP_Dropdown resolutionDropdown;
        [SerializeField] TMP_Dropdown fpsDropdown;
        Resolution[] resolutionsArray;

        int[] fpsArray = {30,60,120};
        void Start()
        {
            ServiceLocator.AddService<SettingsManager>(gameObject);
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
            MUPLogger.LogMessage("" + qualityIndex);
            QualitySettings.SetQualityLevel(qualityIndex,true);
        }
        public void ChangeLangage(int langIndex)
        {
            MUPLogger.LogMessage("" + langIndex);
            string lang = Localization.GetLanguage(SystemLanguage.French);
            switch (langIndex)
            {
                case (int)ELang.FR:
                    lang = Localization.GetLanguage(SystemLanguage.French);
                    break;
                case (int)ELang.EN:
                    lang = Localization.GetLanguage(SystemLanguage.English);
                    break;
            }
            DialogueManager.SetLanguage(lang);
            I2.Loc.LocalizationManager.CurrentLanguage = lang;
        }


        public void ChangeResolution(int resolutionIndex)
        {
            MUPLogger.LogMessage("Change resolution ");
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

}
