using System.Collections.Generic;
using System.Linq;

namespace SpaceImageFormat
{
    public class SpaceImage
    {
        public SpaceImage(string str, int width, int height)
        {
            SetLayers(str, width, height);
        }

        public ImageLayer[] Layers;

        private void SetLayers(string str, int width, int height)
        {
            var layerLength = width * height;
            var numberOfLayers = str.Length / layerLength;

            var layers = new List<ImageLayer>();
            for (var x = 0; x < numberOfLayers; x++)
            {
                layers.Add(new ImageLayer(str.Skip(x * layerLength).Take(layerLength).ToArray(), width, height));
            }

            Layers = layers.ToArray();
        }
    }
}
