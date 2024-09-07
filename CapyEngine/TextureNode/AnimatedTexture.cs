using CapyEngine.UtilNode;
using CapyEngine.TextureNode;
using Raylib_CsLo;

namespace CapyEngine.UtilNode
{
    public class AnimatedTexture: TextureNode.Texture
    {
        private List<TextureNode.Texture> frames;
        private int index;
        private Timer timer;

        public AnimatedTexture(string imagePath, int frameNumber, float interval) : base(imagePath+0)
        {
            frames = new List<TextureNode.Texture>();
            index = 0;
            for (int i = 0; i < frameNumber; i++)
            {
                frames.Add(new TextureNode.Texture(imagePath + i));
                Console.WriteLine(imagePath + i);
            }
            timer = new Timer(interval);
        }

        public override void Update()
        {
            if (timer.IsTimeUp())
            {
                texture = frames[NextIndex()].texture;
            }
        }

        public override void Unload()
        {
            foreach (TextureNode.Texture texture in frames)
            {
                texture.Unload();
            }
        }

        private int NextIndex()
        {
            index++;
            if (index >= frames.Count)
            {
                index = 0;
            }
            return index;

        }
    }
}
