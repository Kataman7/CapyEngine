using Raylib_CsLo;

namespace CapyEngine.UtilNode
{
    public class Timer
    {
        public float interval;
        public float time;

        public Timer(float interval)
        {
            this.interval = interval;
            this.time = 0;
        }

        public bool IsTimeUp()
        {
            time += Raylib.GetFrameTime();
            if (time > interval)
            {
                time = 0;
                return true;
            }
            return false;
        }
    }
}
