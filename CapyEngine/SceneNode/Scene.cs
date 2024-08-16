using CapyEngine.SceneNode;

namespace CapyEngine.SceneNode
{
    public interface IScene
    {
        public void Draw();
        public void Update();
    }
    static class CurrentScene
    {
        public static IScene? scene;
    }
}