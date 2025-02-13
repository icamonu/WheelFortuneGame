using WheelFortune.ScriptableObjects;

namespace WheelFortune.Core
{
    public interface IZoneItemCommand
    {
        public void Execute(ZoneItems zoneItems);
    }
}