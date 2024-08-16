using CapyEngine.CameraNode;
using CapyEngine.SceneNode;

namespace CapyEngine
{
    public static class Game
    {
        public static Camera currentCamera = new Camera(0, 1f);
        public static IScene currentScene = new DuneScene(); 
    }
}
