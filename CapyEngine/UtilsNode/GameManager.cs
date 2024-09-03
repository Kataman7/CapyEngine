using CapyEngine.CameraNode;
using CapyEngine.SceneNode;
using CapyEngine.Exemple.Dune;
using CapyEngine.TileNode;
using CapyEngine.EntityNode.GuiNode;
using System.Numerics;

namespace CapyEngine.UtilNode
{
    public static class GameManager
    {
        public static Camera currentCamera = new Camera(1000, 1f);
        public static IScene currentScene = new DuneScene();
        public static Cursor currentCursor = new Cursor(5);
        public static Vector2 vecOrigin = new Vector2(0, 0);
    }
}
