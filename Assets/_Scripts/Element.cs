
using MyUnityPackage.Toolkit;

public enum EElement
{
    FIRE,
    WATER,
    ELECTRICITY,
    NULL
} 

public static class Extensions
{
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