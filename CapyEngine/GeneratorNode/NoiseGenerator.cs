using SharpNoise.Builders;
using SharpNoise.Modules;
using SharpNoise;
using System.Runtime.InteropServices;

namespace CapyEngine.GeneratorNode
{
    internal class NoiseGenerator: Generator
    {
        private Perlin noiseSource;
        private NoiseMap noiseMap;
        private PlaneNoiseMapBuilder noiseMapBuilder;
        private float[,] grid;

        public NoiseGenerator(int width, int height, int lowerXBound, int upperXBound, int lowerZBound, int upperZBound)
        {
            noiseSource = new Perlin
            {
                Seed = new Random().Next()
            };

            var noiseMap = new NoiseMap();
            var noiseMapBuilder = new PlaneNoiseMapBuilder
            {
                DestNoiseMap = noiseMap,
                SourceModule = noiseSource
            };

            noiseMapBuilder.SetDestSize(width, height);
            noiseMapBuilder.SetBounds(lowerXBound, upperXBound, lowerZBound, upperZBound);
            noiseMapBuilder.Build();
            grid = FillGrid();
        }

        public float[,] FillGrid()
        {
            float[,] grid = new float[noiseMapBuilder.DestNoiseMap.Width, noiseMapBuilder.DestNoiseMap.Height];

            for (int i = 0; i < noiseMapBuilder.DestNoiseMap.Width; i++)
            {
                for (int j = 0; j < noiseMapBuilder.DestNoiseMap.Height; j++)
                {
                    grid[i, j] = noiseMap.GetValue(i, j);
                }
            }
            return grid;
        }

        public float[,] Get()
        {
            return grid;
        }
    }
}
