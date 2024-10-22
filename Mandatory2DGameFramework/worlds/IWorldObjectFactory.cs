namespace Mandatory2DGameFramework.worlds
{
    public interface IWorldObjectFactory
    {
        WorldObject CreateWorldObject(string type, string name, int value, int x, int y);
    }
}