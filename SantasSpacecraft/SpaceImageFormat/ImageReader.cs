namespace SpaceImageFormat
{
    public class ImageReader
    {
        public ImageReader(SpaceImage spaceImage)
        {
            _image = spaceImage;
        }

        private readonly SpaceImage _image;

        public int FindLayerWithFewestZeros()
        {
            int? leastZeroCount = null;
            var leastAddress = 0;

            for (var l = 0; l < _image.Layers.Length; l++)
            {
                var zeroCount = _image.Layers[l].GetNumberOfZeros();

                if (zeroCount == 0)
                {
                    continue;
                }

                if (!leastZeroCount.HasValue || leastZeroCount > zeroCount)
                {
                    leastZeroCount = zeroCount;
                    leastAddress = l;
                }
            }

            return leastAddress;
        }

        public int Process()
        {
            return _image.Layers[FindLayerWithFewestZeros()].ChecksumOnesAndTwos();
        }
    }
}