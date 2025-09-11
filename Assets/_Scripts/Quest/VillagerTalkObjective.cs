using MyUnityPackage.ProgressionSystem;
using MyUnityPackage.Toolkit;
using System;

namespace Showcase
{
    public class VillagerTalkObjective : IQuestObjective
    {
        public string Title {get;set;}

        public string Description {get;set;}

        public bool IsCompleted {get;set;}

        public int CurrentProgression {get;set;}

        public int MaxProgression {get;set;}
        public PNJ Pnj {get;set;}

        public event Action<int, int> OnProgress;
        public event Action OnCompleted;


        public VillagerTalkObjective(string _title, string _description, int _countRequired,PNJ _pnj)
        {
            Title = _title;
            Description = _description;
            CurrentProgression = 0;
            MaxProgression = _countRequired;
            Pnj = _pnj;
        }
        public void Start()
        {
            MUPLogger.LogMessageEditor("START TALK OBJECTIF! ");
             
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
            MUPLogger.LogMessageEditor("OnProggressChange de la mission de parler au maire ! ");
            CurrentProgression++;
            OnProgress?.Invoke(CurrentProgression, MaxProgression);

            if (CheckProgress())
            {
                MUPLogger.LogMessageEditor("Completion de la mission de parler au maire ! ");
                OnCompleted?.Invoke();
            }
        }
        public void OnProgressChangePNJ(PNJ pnj)
        {
            if(IsCompleted || pnj != Pnj)
                return;
            OnProgressChange();
         
        }

      
    }
}
