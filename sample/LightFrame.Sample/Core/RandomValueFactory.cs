using System;

namespace LightFrame.Sample.Core
{
    public class RandomValueFactory : IValueFactory
    {
        private readonly Random _random;
        private readonly ApplicationSettings _settings;

        public RandomValueFactory(ApplicationSettings settings)
        {
            _random = new Random();
            _settings = settings;
        }

        public string Value => $"{_settings.Name} - {_random.Next().ToString()}";
    }
}
