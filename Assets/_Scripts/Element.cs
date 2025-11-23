
using MyUnityPackage.Toolkit;
using UnityEngine;

namespace Showcase
{
    public enum EElement
    {
        FIRE,
        WATER,
        ELECTRICITY,
        NULL
    } 

    public static class ElementExtensions
    {
        public static Material[] materials = new Material[(int)EElement.NULL];
        public static void InitializationElement( )
        {
            //"Assets/Resources/Elements/M_FIRE.mat"
            string path = "Elements/";
            string prefix = "M_";
            for(int i = 0; i < (int)EElement.NULL; i++)
            {
                string materialName = path + prefix + ((EElement)i).ToString();

                materials[i] = Resources.Load(materialName) as Material;
                if(materials[i] == null)
                {
                    MUPLogger.Error("Material not found: " + materialName);
                }
            }
        }
        public static EElement GetCounterElement(this EElement element )
        {
            switch ( element )
            {
                case EElement.FIRE:
                    return EElement.WATER;
                case EElement.WATER:
                    return EElement.ELECTRICITY;
                case EElement.ELECTRICITY:
                    return EElement.FIRE;
                default:
                    MUPLogger.Error("Element not knwon");
                    return EElement.NULL;
            }
        }
            
    }
}
