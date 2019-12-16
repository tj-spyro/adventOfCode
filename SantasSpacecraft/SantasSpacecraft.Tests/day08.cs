using System.IO;
using System.Linq;
using NUnit.Framework;
using SpaceImageFormat;

namespace SantasSpacecraft.Tests.Day08
{
    [TestFixture("123456789012", 3, 2)]
    public class When_intitialising_image
    {
        public When_intitialising_image(string input, int width, int height)
        {
            _input = input;
            _height = height;
            _width = width;
        }

        private readonly string _input;
        private readonly int _width;
        private readonly int _height;
        private SpaceImage _image;

        [SetUp]
        public void SetUp()
        {
            _image = new SpaceImage(_input, _width, _height);
        }

        [Test]
        public void The_number_of_layers_is_correct()
        {
            Assert.That(_image.Layers.Length, Is.EqualTo(2));
        }

        [Test]
        public void The_data_of_layer_1_row_1_is_correct()
        {
            Assume.That(_image.Layers.Length, Is.EqualTo(2));
            Assert.That(_image.Layers[0].GetJaggedArray()[0], Is.EqualTo(new[] {'1', '2', '3'}));
        }

        [Test]
        public void The_data_of_layer_1_row_2_is_correct()
        {
            Assume.That(_image.Layers.Length, Is.EqualTo(2));
            Assert.That(_image.Layers[0].GetJaggedArray()[1], Is.EqualTo(new[] {'4', '5', '6'}));
        }

        [Test]
        public void The_data_of_layer_2_row_1_is_correct()
        {
            Assume.That(_image.Layers.Length, Is.EqualTo(2));
            Assert.That(_image.Layers[1].GetJaggedArray()[0], Is.EqualTo(new[] {'7', '8', '9'}));
        }

        [Test]
        public void The_data_of_layer_2_row_2_is_correct()
        {
            Assume.That(_image.Layers.Length, Is.EqualTo(2));
            Assert.That(_image.Layers[1].GetJaggedArray()[1], Is.EqualTo(new[] {'0', '1', '2'}));
        }
    }

    [TestFixture("123456789012", 3, 2)]
    public class When_finding_zeros
    {
        public When_finding_zeros(string input, int width, int height)
        {
            _input = input;
            _height = height;
            _width = width;
        }

        private readonly string _input;
        private readonly int _width;
        private readonly int _height;
        private SpaceImage _image;

        [SetUp]
        public void SetUp()
        {
            _image = new SpaceImage(_input, _width, _height);
        }

        [Test]
        public void No_zeros_found_in_layer_1()
        {
            Assume.That(_image.Layers.Length, Is.EqualTo(2));
            Assert.That(_image.Layers[0].GetNumberOfZeros(), Is.EqualTo(0));
        }

        [Test]
        public void Zeros_found_in_layer_2()
        {
            Assume.That(_image.Layers.Length, Is.EqualTo(2));
            Assert.That(_image.Layers[1].GetNumberOfZeros(), Is.EqualTo(1));
        }
    }

    [TestFixture("122456789012", 3, 2)]
    public class When_checksumming_layers
    {
        public When_checksumming_layers(string input, int width, int height)
        {
            _input = input;
            _height = height;
            _width = width;
        }

        private readonly string _input;
        private readonly int _width;
        private readonly int _height;
        private SpaceImage _image;

        [SetUp]
        public void SetUp()
        {
            _image = new SpaceImage(_input, _width, _height);
        }

        [Test]
        public void Then_layer_1_checksum_is_correct()
        {
            Assume.That(_image.Layers.Length, Is.EqualTo(2));
            Assert.That(_image.Layers[0].ChecksumOnesAndTwos(), Is.EqualTo(2));
        }

        [Test]
        public void Then_layer_2_checksum_is_correct()
        {
            Assume.That(_image.Layers.Length, Is.EqualTo(2));
            Assert.That(_image.Layers[1].ChecksumOnesAndTwos(), Is.EqualTo(1));
        }
    }

    [TestFixture("122456789012", 3, 2)]
    public class When_layer_with_least_zeros
    {
        public When_layer_with_least_zeros(string input, int width, int height)
        {
            _input = input;
            _height = height;
            _width = width;
        }

        private readonly string _input;
        private readonly int _width;
        private readonly int _height;
        private SpaceImage _image;
        private ImageReader _imageReader;

        [SetUp]
        public void SetUp()
        {
            _image = new SpaceImage(_input, _width, _height);
            _imageReader = new ImageReader(_image);
        }

        [Test]
        public void Then_correct_layer_is_found()
        {
            Assume.That(_image.Layers.Length, Is.EqualTo(2));
            Assert.That(_imageReader.FindLayerWithFewestZeros(), Is.EqualTo(1));
        }
    }

    [TestFixture]
    public class Solve
    {
        private string _testInput;

        [OneTimeSetUp]
        public void SetUp()
        {
            const string testFilePath = "..//..//..//TestData//day08.txt";

            _testInput = File.ReadLines(testFilePath).First();
        }

        [Test]
        public void Part_1()
        {
            var image = new SpaceImage(_testInput, 25, 6);

            var imageReader = new ImageReader(image);

            var result = imageReader.Process();

            Assert.That(result, Is.EqualTo(2286));
        }

        [Test]
        public void Part_2()
        {
            
        }
    }
}
