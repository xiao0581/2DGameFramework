namespace Mandatory2DGameFramework.worlds.Factory
{
    public interface IWorldObjectFactory
    {
        WorldObject CreateWorldObject(string type, string name, int value, int x, int y);
    }
}