using CapyEngine.CameraNode;
using CapyEngine.SceneNode;
using CapyEngine.Exemple.Dune;

namespace CapyEngine
{
    public static class GameManager
    {
        public static Camera currentCamera = new CameraSmooth(10000, 1f, 150f, 50f);
        public static IScene currentScene = new DuneScene();
    }
}
