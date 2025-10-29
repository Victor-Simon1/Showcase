using MyUnityPackage.ProgressionSystem;
using MyUnityPackage.Toolkit;
using System;
using System.Linq;
using UnityEngine;

namespace Showcase
{
    public class VillagerTalkObjective : IQuestObjective
    {
        public string Title {get;set;}

        public string Description {get;set;}

        public bool IsCompleted {get;set;}

        public int CurrentProgression {get;set;}

        public int MaxProgression {get;set;}
        public EPNJ Pnj {get;set;}

        public event Action<int, int> OnProgress;
        public event Action OnCompleted;


        public VillagerTalkObjective(string _title, string _description, int _countRequired,EPNJ _pnj)
        {
            Title = _title;
            Description = _description;
            CurrentProgression = 0;
            MaxProgression = _countRequired;
            Pnj = _pnj;
        }
        public void Start()
        {
            //MUPLogger.Info("START TALK OBJECTIF! ");
             
           //if(InteractableVillager.OnTalkPnjIsNull())
            InteractableVillager.OnTalkPNJ += OnProgressChangePNJ;
            OnCompleted += CompletedObjectif;
        }
        public void Stop()
        {
            InteractableVillager.OnTalkPNJ -= OnProgressChangePNJ;
            OnCompleted -= CompletedObjectif;
        }
        void CompletedObjectif()
        {
            //MUPLogger.Info("Complete objectif talk");
            Villager villager = GameObject.FindObjectsByType<Villager>(FindObjectsSortMode.None).Where(c => Pnj == c.GetPNJ()).ToArray()[0];
            MUPLogger.Info("Complete objectif talk " + villager.ToString());
            villager.SetAura();
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
            MUPLogger.Info("OnProggressChange de la mission de parler au maire ! ");
            CurrentProgression++;
            OnProgress?.Invoke(CurrentProgression, MaxProgression);

            if (CheckProgress())
            {
                MUPLogger.Info("Completion de la mission de parler au maire ! ");
                OnCompleted?.Invoke();
            }
        }
        public void OnProgressChangePNJ(EPNJ pnj)
        {
            if(IsCompleted || pnj != Pnj)
                return;
            OnProgressChange();
         
        }

      
    }
}
