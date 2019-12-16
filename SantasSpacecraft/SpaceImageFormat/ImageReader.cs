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
        
        public SpaceImage FlattenImage()
        {
            var width = _image.Layers[0].Width;
            var height = _image.Layers[0].Height;

            var data = new char[height * width];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var finalRowValue = ' ';

                    foreach (var layer in _image.Layers)
                    {
                        var rowValue = layer.GetValueAtIndex(x, y);

                        if (rowValue == '0')
                        {
                            finalRowValue = '_';
                            break;
                        }

                        if (rowValue == '1')
                        {
                            finalRowValue = '■';
                            break;
                        }
                    }

                    data[x + y * width] = finalRowValue;
                }
            }

            return new SpaceImage(new string(data), width, height);
        }
    }
}