using HereBeDragons;

namespace TestLocation
{
    public class NormalClass
    {
        [HereBeDragons(DragonType.FireBreathing, "This is a horrible method that everyone should run away from")]
        public void DragonMethod() { }
        public void NonDragonMethod() { }
    }
}