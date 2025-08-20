using System;
using MyUnityPackage.ProgressionSystem;
using UnityEngine;

namespace Showcase
{
    public class WoodObjective : IQuestObjective
    {
        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public bool IsCompleted => throw new NotImplementedException();

        public int CurrentProgression => throw new NotImplementedException();

        public int MaxProgression => throw new NotImplementedException();

        public event Action<int, int> OnProgress;
        public event Action OnCompleted;

        public WoodObjective()
        {
            
        }
        public bool CheckProgress()
        {
            throw new NotImplementedException();
        }

        public bool IsComplete()
        {
            throw new NotImplementedException();
        }

        public void OnProgressChange()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}