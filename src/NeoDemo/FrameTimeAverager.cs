namespace Veldrid.NeoDemo
{
    public class FrameTimeAverager
    {
        public readonly double _timeLimit = 666;

        public double _accumulatedTime = 0;
        public int _frameCount = 0;
        public readonly double _decayRate = .3;

        public double CurrentAverageFrameTimeSeconds { get; set; }
        public double CurrentAverageFrameTimeMilliseconds => CurrentAverageFrameTimeSeconds * 1000.0;
        public double CurrentAverageFramesPerSecond => 1 / CurrentAverageFrameTimeSeconds;

        public FrameTimeAverager(double maxTimeSeconds)
        {
            _timeLimit = maxTimeSeconds;
        }

        public void Reset()
        {
            _accumulatedTime = 0;
            _frameCount = 0;
        }

        public void AddTime(double seconds)
        {
            _accumulatedTime += seconds;
            _frameCount++;
            if (_accumulatedTime >= _timeLimit)
            {
                Average();
            }
        }

        public void Average()
        {
            double total = _accumulatedTime;
            CurrentAverageFrameTimeSeconds =
                (CurrentAverageFrameTimeSeconds * _decayRate)
                + ((total / _frameCount) * (1 - _decayRate));

            _accumulatedTime = 0;
            _frameCount = 0;
        }
    }
}
