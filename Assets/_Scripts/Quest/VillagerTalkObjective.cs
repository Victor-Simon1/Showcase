using MyUnityPackage.ProgressionSystem;
using MyUnityPackage.Toolkit;
using PixelCrushers.DialogueSystem.Wrappers;
using System;
using System.Collections.Generic;

namespace Showcase
{
    public class VillagerTalkObjective : IQuestObjective
    {
        public string Title {get;set;}

        public string Description {get;set;}

        public bool IsCompleted {get;set;}

        public int CurrentProgression {get;set;}

        public int MaxProgression {get;set;}

        public event Action<int, int> OnProgress;
        public event Action OnCompleted;


        public VillagerTalkObjective(string _title, string _description, int _countRequired)
        {
            Title = _title;
            Description = _description;
            CurrentProgression = 0;
            MaxProgression = _countRequired;
        }
        public void Start()
        {
            MyUnityPackage.Toolkit.Logger.LogMessageEditor("START TALK OBJECTIF! ");
             
           //if(InteractableVillager.OnTalkPnjIsNull())
            InteractableVillager.OnTalkPNJ += OnProgressChangePNJ;
        }
        public void Stop()
        {
            InteractableVillager.OnTalkPNJ -= OnProgressChangePNJ;
        }
        

        public bool CheckProgress()
        {
            return IsCompleted = CurrentProgression >= MaxProgression;
        }

        public bool IsComplete()
        {
            return IsCompleted;
        }
        public void OnProgressChange()
        {
            Logger.LogMessageEditor("OnProggressChange de la mission de parler au maire ! ");
            CurrentProgression++;
            OnProgress?.Invoke(CurrentProgression, MaxProgression);

            if (CheckProgress())
            {
                Logger.LogMessageEditor("Completion de la mission de parler au maire ! ");
                OnCompleted?.Invoke();
            }
        }
        public void OnProgressChangePNJ(PNJ pnj)
        {
            if(IsCompleted || pnj != PNJ.Mayor)
                return;
            OnProgressChange();
         
        }

      
    }
}
