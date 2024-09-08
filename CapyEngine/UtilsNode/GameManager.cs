using CapyEngine.CameraNode;
using CapyEngine.SceneNode;
using CapyEngine.Exemple.Dune;
using CapyEngine.TileNode;
using CapyEngine.EntityNode.GuiNode;
using System.Numerics;
using CapyEngine.WorldNode;

namespace CapyEngine.UtilsNode
{
    public static class GameManager
    {
        public static Random random = new Random();
        public static Camera currentCamera = new Camera(600, 1f);
        public static IScene currentScene = new DuneScene();
        public static Cursor currentCursor = new Cursor(5);
        public static Vector2 vecOrigin = new Vector2(0, 0);
        public static World currentWorld = null;
    }
}
