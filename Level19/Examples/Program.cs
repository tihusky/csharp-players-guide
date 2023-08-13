using InformationHiding;

var rect1 = new Rectangle(2, 3);

Console.WriteLine($"Width: {rect1.GetWidth()} Height: {rect1.GetHeight()} Area: {rect1.GetArea()}");

rect1.SetWidth(10.75f);
rect1.SetHeight(5.25f);

Console.WriteLine($"Width: {rect1.GetWidth()} Height: {rect1.GetHeight()} Area: {rect1.GetArea()}");

namespace InformationHiding {
    public class Rectangle {
        private float _width;
        private float _height;

        public Rectangle(float width, float height) {
            _width = width;
            _height = height;
        }

        public float GetWidth() => _width;
        public float GetHeight() => _height;
        public float GetArea() => _width * _height;

        public void SetWidth(float width) {
            _width = width;
        }

        public void SetHeight(float height) {
            _height = height;
        }
    }
}